using Microsoft.CodeAnalysis;

namespace GiGraph.Dot.SourceGenerators.Extensions;

internal static class SymbolExtensions
{
    public static string[] GetModifiersAsString(this ISymbol symbol)
    {
        var modifiers = new List<string>();
        if (symbol.IsStatic)
        {
            modifiers.Add("static");
        }

        if (symbol.IsAbstract)
        {
            modifiers.Add("abstract");
        }

        if (symbol.IsSealed)
        {
            modifiers.Add("sealed");
        }

        if (symbol.IsOverride)
        {
            modifiers.Add("override");
        }

        if (symbol.IsVirtual)
        {
            modifiers.Add("virtual");
        }

        return modifiers.ToArray();
    }
}