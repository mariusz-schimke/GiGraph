using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Extensions;

/// <summary>
///     Provides extension methods for <see cref="DotGraph"/>.
/// </summary>
public static partial class DotGraphExtension
{
    /// <summary>
    ///     Converts the graph to its DOT format representation.
    /// </summary>
    /// <param name="graph">
    ///     The graph to convert to the DOT format.
    /// </param>
    /// <param name="formattingOptions">
    ///     The formatting options to use.
    /// </param>
    /// <param name="syntaxOptions">
    ///     The generation options to use.
    /// </param>
    /// <param name="syntaxRules">
    ///     The syntax rules to use.
    /// </param>
    [Pure]
    public static string ToDot(
        this DotGraph graph,
        DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null,
        DotSyntaxRules? syntaxRules = null
    )
    {
        using var stringWriter = new StringWriter();
        graph.Save(stringWriter, formattingOptions, syntaxOptions, syntaxRules);

        stringWriter.Flush();
        return stringWriter.ToString();
    }
}