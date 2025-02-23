using Microsoft.CodeAnalysis;

namespace GiGraph.Dot.SourceGenerators.Extensions;

internal static class BuildMessageWriterExtension
{
    public static void WriteWarning(this SourceProductionContext context, string message)
    {
        context.Write(DiagnosticSeverity.Error, message);
    }

    public static void WriteError(this SourceProductionContext context, string message)
    {
        context.Write(DiagnosticSeverity.Error, message);
    }

    private static void Write(this SourceProductionContext context, DiagnosticSeverity severity, string message)
    {
        var descriptor = new DiagnosticDescriptor(
            "DOT001",
            "Generator",
            message,
            "Usage",
            severity,
            true
        );

        context.ReportDiagnostic(Diagnostic.Create(descriptor, null));
    }
}