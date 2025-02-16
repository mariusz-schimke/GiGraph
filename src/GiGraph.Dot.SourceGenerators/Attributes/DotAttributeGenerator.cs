using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GiGraph.Dot.SourceGenerators.Attributes;

[Generator]
public class DotAttributeGenerator : IIncrementalGenerator
{
    private const string AttributeKeyAttributeType = "GiGraph.Dot.Output.Metadata.DotAttributeKeyAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var classes = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (s, _) => s is ClassDeclarationSyntax,
                transform: static (ctx, _) => (ClassDeclarationSyntax) ctx.Node)
            .Where(static c => c is not null);

        IncrementalValueProvider<(Compilation, ImmutableArray<ClassDeclarationSyntax>)> compilationAndClasses =
            context.CompilationProvider.Combine(classes.Collect());

        context.RegisterSourceOutput(compilationAndClasses, Execute);
    }

    private static void Execute(SourceProductionContext context, (Compilation compilation, ImmutableArray<ClassDeclarationSyntax> classes) input)
    {
        var (compilation, classes) = input;
        var attributeSymbol = compilation.GetTypeByMetadataName(AttributeKeyAttributeType);

        if (attributeSymbol is null)
        {
            context.WriteError($"{AttributeKeyAttributeType} not found!");
            return;
        }

        foreach (var classDeclaration in classes)
        {
            var model = compilation.GetSemanticModel(classDeclaration.SyntaxTree);
            var classSymbol = model.GetDeclaredSymbol(classDeclaration);
            if (classSymbol is null)
            {
                continue;
            }

            var properties = GetAttributeProperties(classDeclaration, model, attributeSymbol);
            GenerateClassWithProperties(context, classSymbol, properties);
        }
    }

    private static void GenerateClassWithProperties(SourceProductionContext context, INamedTypeSymbol classSymbol, AttributePropertyDeclaration[] properties)
    {
        if (properties.Length == 0)
        {
            return;
        }

        var sb = new StringBuilder();

        sb.AppendLine("#nullable enable");
        sb.AppendLine($"namespace {classSymbol.ContainingNamespace.ToDisplayString()};");
        sb.AppendLine();
        sb.AppendLine($"public partial class {classSymbol.Name}");
        sb.AppendLine("{");

        foreach (var property in properties)
        {
            sb.AppendLine($"    public virtual partial {property.ReturnType} {property.Name}");
            sb.AppendLine("    {");
            sb.AppendLine($"        get => _attributes.GetValue(\"{property.DotKey}\", out {property.ReturnType.TrimEnd('?')} value) ? value : null;");
            sb.AppendLine($"        set => _attributes.SetOrRemove(\"{property.DotKey}\", value);");
            sb.AppendLine("    }");
            sb.AppendLine();
        }

        sb.AppendLine("}");

        // context.WriteWarning(sb.ToString().Replace("\n", " "));
        context.AddSource($"{classSymbol.Name}_AttributeProperties.g.cs", sb.ToString());
    }

    private static AttributePropertyDeclaration[] GetAttributeProperties(ClassDeclarationSyntax classDeclaration, SemanticModel model, INamedTypeSymbol attributeSymbol)
    {
        return classDeclaration.Members
            .OfType<PropertyDeclarationSyntax>()
            .Select(property => model.GetDeclaredSymbol(property))
            .Select(propertySymbol => new
            {
                PropertySymbol = propertySymbol,
                DotKeyAttribute = propertySymbol?
                    .GetAttributes()
                    .FirstOrDefault(attr => SymbolEqualityComparer.Default.Equals(attr.AttributeClass, attributeSymbol))
            })
            .Where(propertySymbol => propertySymbol.DotKeyAttribute is not null)
            .Select(metadata => new AttributePropertyDeclaration(
                metadata.PropertySymbol!.Name,
                metadata.PropertySymbol.Type.ToDisplayString(),
                metadata.DotKeyAttribute!.ConstructorArguments.Single().Value!.ToString()
            ))
            .ToArray();
    }
}