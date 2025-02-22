using System.Collections.Immutable;
using System.Text;
using GiGraph.Dot.SourceGenerators.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GiGraph.Dot.SourceGenerators.Attributes;

[Generator]
public class DotAttributePropertiesGenerator : IIncrementalGenerator
{
    private const string DotAttributeKeyAttributeTypeMetadataName = "GiGraph.Dot.Output.Metadata.DotAttributeKeyAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var classes = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (s, _) => s is ClassDeclarationSyntax cds &&
                    cds.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword)),
                transform: static (ctx, _) => (ClassDeclarationSyntax) ctx.Node)
            .Where(static c => c is not null);

        IncrementalValueProvider<(Compilation, ImmutableArray<ClassDeclarationSyntax>)> compilationAndClasses =
            context.CompilationProvider.Combine(classes.Collect());

        context.RegisterSourceOutput(compilationAndClasses, Execute);
    }

    private static void Execute(SourceProductionContext context, (Compilation compilation, ImmutableArray<ClassDeclarationSyntax> classes) input)
    {
        var (compilation, classes) = input;
        var attributeSymbol = compilation.GetTypeByMetadataName(DotAttributeKeyAttributeTypeMetadataName);

        if (attributeSymbol is null)
        {
            context.WriteError($"{DotAttributeKeyAttributeTypeMetadataName} type not found!");
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

        classBuilder.AppendLine("#nullable enable");
        classBuilder.AppendLine();
        classBuilder.AppendLine($"namespace {classSymbol.ContainingNamespace.ToDisplayString()};");
        classBuilder.AppendLine();
        classBuilder.AppendLine($"{classModifiers} partial class {classSymbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)}");
        classBuilder.AppendLine("{");

        for (var index = 0; index < properties.Length; index++)
        {
            var property = properties[index];

            classBuilder.AppendLine($"    {string.Join(" ", [..property.Modifiers, property.ReturnType, property.Name])}");
            classBuilder.AppendLine("    {");
            classBuilder.AppendLine($"        get => _attributes.GetValueAs(\"{property.DotKey}\", out {property.ReturnType} value) ? value : null;");
            classBuilder.AppendLine($"        set => _attributes.SetOrRemove(\"{property.DotKey}\", value);");
            classBuilder.AppendLine("    }");

            if (index < properties.Length - 1)
            {
                classBuilder.AppendLine();
            }
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
            .Where(propertySymbol => propertySymbol.PropertySymbol?.IsPartialDefinition is true)
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