using System.Collections.Immutable;
using System.Text;
using GiGraph.Dot.SourceGenerators.Extensions;
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
            GenerateClassWithProperties(context, classSymbol, properties, classDeclaration.SyntaxTree.FilePath);
        }
    }

    private static void GenerateClassWithProperties(SourceProductionContext context, INamedTypeSymbol classSymbol,
        AttributePropertyDeclaration[] properties, string filePath)
    {
        if (properties.Length == 0)
        {
            return;
        }

        var classBuilder = new StringBuilder();

        var classModifiers = string.Join(" ",
        [
            classSymbol.DeclaredAccessibility.GetAsString(),
            ..classSymbol.GetModifiersAsString()
        ]);

        // todo: ignore non-partial classes and non-partial properties?

        classBuilder.AppendLine("#nullable enable");
        classBuilder.AppendLine();
        classBuilder.AppendLine($"namespace {classSymbol.ContainingNamespace.ToDisplayString()};");
        classBuilder.AppendLine();
        classBuilder.AppendLine($"{classModifiers} partial class {classSymbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)}");
        classBuilder.AppendLine("{");

        foreach (var property in properties)
        {
            var propertyModifiers = string.Join(" ", property.Modifiers);
            classBuilder.AppendLine($"    {propertyModifiers} {property.ReturnType} {property.Name}");
            classBuilder.AppendLine("    {");
            classBuilder.AppendLine($"        get => _attributes.GetValueAs(\"{property.DotKey}\", out {property.ReturnType} value) ? value : null;");
            classBuilder.AppendLine($"        set => _attributes.SetOrRemove(\"{property.DotKey}\", value);");
            classBuilder.AppendLine("    }");
            classBuilder.AppendLine();
        }

        classBuilder.AppendLine("}");

        // context.WriteWarning(fileName);
        var fileName = Path.GetFileNameWithoutExtension(filePath);
        context.AddSource($"{fileName}.g.cs", classBuilder.ToString());
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
            .Where(propertySymbol => true == propertySymbol.PropertySymbol?.IsPartialDefinition)
            .Where(propertySymbol => propertySymbol.DotKeyAttribute is not null)
            .Select(metadata =>
            {
                string[] modifiers =
                [
                    metadata.PropertySymbol!.DeclaredAccessibility.GetAsString(),
                    ..metadata.PropertySymbol.GetModifiersAsString(),
                    "partial"
                ];

                return new AttributePropertyDeclaration(
                    modifiers.ToArray(),
                    metadata.PropertySymbol!.Name,
                    metadata.PropertySymbol.Type.ToDisplayString(),
                    metadata.DotKeyAttribute!.ConstructorArguments.Single().Value!.ToString()
                );
            })
            .ToArray();
    }
}