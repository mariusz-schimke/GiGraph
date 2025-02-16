using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[Generator]
public class DotAttributeGenerator : IIncrementalGenerator
{
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

    private void Execute(SourceProductionContext context, (Compilation compilation, ImmutableArray<ClassDeclarationSyntax> classes) input)
    {
        var (compilation, classes) = input;
        var attributeSymbol = compilation.GetTypeByMetadataName("GiGraph.Dot.Output.Metadata.DotAttributeKeyAttributeTest");

        if (attributeSymbol is null)
        {
            context.ReportDiagnostic(Diagnostic.Create(new(
                "DOT001", "Generator Error", "DotAttributeKeyAttribute not found!", "Usage",
                DiagnosticSeverity.Error, true), null));
            return;
        }

        foreach (var classDeclaration in classes)
        {
            var model = compilation.GetSemanticModel(classDeclaration.SyntaxTree);
            var classSymbol = model.GetDeclaredSymbol(classDeclaration);
            if (classSymbol == null)
            {
                continue;
            }

            context.ReportDiagnostic(Diagnostic.Create(new(
                "DOT001", "Generator Error", classSymbol.Name, "Usage",
                DiagnosticSeverity.Info, true), null));

            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine();
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
                var attrValue = propertySymbol.GetAttributes().First().ConstructorArguments[0].Value;

                sb.AppendLine($"    public virtual partial {propType} {propName}");
                sb.AppendLine("    {");
                sb.AppendLine($"        get => _attributes.GetValue(\"{attrValue}\", out {propType.TrimEnd('?')} value) ? value : null;");
                sb.AppendLine($"        set => _attributes.SetOrRemove(\"{attrValue}\", value);");
                sb.AppendLine("    }");
                sb.AppendLine();
            }

            sb.AppendLine("}");

            if (added)
            {
                context.ReportDiagnostic(Diagnostic.Create(new(
                    "DOT005", "Generator Error", sb.ToString().Replace("\n", ""), "Usage",
                    DiagnosticSeverity.Warning, true), null));

                context.AddSource($"{classSymbol.Name}_AttributeProperties.g.cs", sb.ToString());
            }
        }
    }
}