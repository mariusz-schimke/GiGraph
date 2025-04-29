using System.Text;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Extensions;

/// <summary>
///     Provides extension methods for <see cref="DotGraph"/>.
/// </summary>
public static partial class DotGraphExtension
{
    /// <summary>
    ///     Writes the DOT format representation of the graph to the specified file (the file will be overwritten if it already exists).
    ///     The complete output is generated synchronously in memory and then written asynchronously to the specified file.
    /// </summary>
    /// <param name="graph">
    ///     The graph to convert to the DOT format.
    /// </param>
    /// <param name="filePath">
    ///     The path to the file to save the graph to.
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
    /// <param name="encoding">
    ///     The encoding to use for the output text.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token.
    /// </param>
    public static async Task SaveAsync(
        this DotGraph graph,
        string filePath,
        DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null,
        DotSyntaxRules? syntaxRules = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    )
    {
#if !NETSTANDARD2_0
        await
#endif
            using var fileStream = File.Create(filePath);
        await graph.SaveAsync(fileStream, formattingOptions, syntaxOptions, syntaxRules, encoding);
        await fileStream.FlushAsync(cancellationToken);
    }

    /// <summary>
    ///     Converts the specified graph to its DOT format representation and writes it to the provided stream. The complete output is
    ///     generated synchronously in memory and then written asynchronously to the specified stream.
    /// </summary>
    /// <param name="graph">
    ///     The graph to convert to the DOT format.
    /// </param>
    /// <param name="stream">
    ///     The stream to write the graph to.
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
    /// <param name="encoding">
    ///     The encoding to use for the output text.
    /// </param>
    public static async Task SaveAsync(
        this DotGraph graph,
        Stream stream,
        DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null,
        DotSyntaxRules? syntaxRules = null,
        Encoding? encoding = null
    )
    {
        using var streamWriter = CreateStreamWriter(stream, encoding);

        // it would be better to build the graph directly to stream, but the solution does not support async building
        var output = graph.ToDot(formattingOptions, syntaxOptions, syntaxRules);
        await streamWriter.WriteAsync(output);
        await streamWriter.FlushAsync();
    }
}