using System.Collections.Immutable;
using System.Text;
using GiGraph.Dot.SourceGenerators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[Generator]
public class DotAttributeGenerator : IIncrementalGenerator
{
    private const string AttributeKeyAttributeType = "GiGraph.Dot.Output.Metadata.DotAttributeKeyAttributeTest";

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

            var sb = new StringBuilder();
            sb.AppendLine($"namespace {classSymbol.ContainingNamespace.ToDisplayString()};");
            sb.AppendLine();
            sb.AppendLine($"public partial class {classSymbol.Name}");
            sb.AppendLine("{");

            var added = false;

            foreach (var property in classDeclaration.Members.OfType<PropertyDeclarationSyntax>())
            {
                var propertySymbol = model.GetDeclaredSymbol(property);
                if (propertySymbol is null || !propertySymbol.GetAttributes().Any(attr => SymbolEqualityComparer.Default.Equals(attr.AttributeClass, attributeSymbol)))
                {
                    continue;
                }

                added = true;
                var propName = propertySymbol.Name;

                var propType = propertySymbol.Type.ToDisplayString();
                var attrKey = propertySymbol.GetAttributes().First().ConstructorArguments.First().Value;

                sb.AppendLine($"    public virtual partial {propType} {propName}");
                sb.AppendLine("    {");
                sb.AppendLine($"        get => _attributes.GetValue(\"{attrKey}\", out {propType.TrimEnd('?')} value) ? value : null;");
                sb.AppendLine($"        set => _attributes.SetOrRemove(\"{attrKey}\", value);");
                sb.AppendLine("    }");
                sb.AppendLine();
            }

            sb.AppendLine("}");

            if (added)
            {
                // context.WriteWarning(sb.ToString().Replace("\n", " "));

                context.AddSource($"{classSymbol.Name}_AttributeProperties.g.cs", sb.ToString());
            }
        }
    }
}