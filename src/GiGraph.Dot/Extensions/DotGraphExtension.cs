using System.Diagnostics.Contracts;
using System.Text;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Output.Generators.Graphs;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Graphs;
using GiGraph.Dot.Output.Writers.Options;
using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Extensions;

/// <summary>
///     Provides extension methods for <see cref="DotGraph"/>.
/// </summary>
public static class DotGraphExtension
{
    /// <summary>
    ///     Converts the specified graph to its DOT format representation.
    /// </summary>
    /// <param name="graph">
    ///     The graph to convert.
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
    public static string ToDotString(
        this DotGraph graph,
        DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null,
        DotSyntaxRules? syntaxRules = null
    )
    {
        using var stringWriter = new StringWriter();
        graph.WriteTo(stringWriter, formattingOptions, syntaxOptions, syntaxRules);

        stringWriter.Flush();
        return stringWriter.ToString();
    }

    /// <summary>
    ///     Converts the specified graph to its DOT format representation and writes it to the provided text writer.
    /// </summary>
    /// <param name="graph">
    ///     The graph to convert.
    /// </param>
    /// <param name="writer">
    ///     The writer to write the DOT string to.
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
    public static void WriteTo(
        this DotGraph graph,
        TextWriter writer,
        DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null,
        DotSyntaxRules? syntaxRules = null
    )
    {
        var generatorsProviderBuilder = new DotEntityGeneratorsProviderBuilder();
        var graphGeneratorBuilder = new DotGraphGeneratorBuilder(generatorsProviderBuilder);

        graph.WriteTo(writer, graphGeneratorBuilder, formattingOptions, syntaxOptions, syntaxRules);
    }

    /// <summary>
    ///     Converts the specified graph to its DOT format representation and writes it to the provided text writer.
    /// </summary>
    /// <param name="graph">
    ///     The graph to convert.
    /// </param>
    /// <param name="writer">
    ///     The writer to write the DOT string to.
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
    /// <param name="graphGeneratorBuilder">
    ///     The graph generator builder to use in order to get the graph builder to generate the DOT output with.
    /// </param>
    public static void WriteTo(
        this DotGraph graph,
        TextWriter writer,
        IDotGraphGeneratorBuilder graphGeneratorBuilder,
        DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null,
        DotSyntaxRules? syntaxRules = null
    )
    {
        syntaxRules ??= DotSyntaxRules.Default;
        syntaxOptions ??= DotSyntaxOptions.Default;
        formattingOptions ??= DotFormattingOptions.Default;

        var tokenWriterOptions = new DotTokenWriterOptions(
            formattingOptions.IndentationLevel,
            formattingOptions.IndentationSize,
            formattingOptions.IndentationChar,
            formattingOptions.LineBreak,
            formattingOptions.SingleLine,
            syntaxOptions.Comments.PreferHashForSingleLineComments,
            formattingOptions.TextEncoder
        );

        var tokenWriter = new DotTokenWriter(writer, tokenWriterOptions);
        var graphWriterRoot = new DotGraphWriterRoot(tokenWriter, formattingOptions);

        var graphBuilder = graphGeneratorBuilder.Build(syntaxRules, syntaxOptions);
        graphBuilder.Generate(graph, graphWriterRoot);
    }

    /// <summary>
    ///     Converts the specified graph to its DOT format representation and writes it to the specified file (the file will be
    ///     overwritten if it already exists).
    /// </summary>
    /// <param name="graph">
    ///     The graph to convert.
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
    public static void Save(
        this DotGraph graph,
        string filePath,
        DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null,
        DotSyntaxRules? syntaxRules = null,
        Encoding? encoding = null
    )
    {
        using var streamWriter = CreateFileStreamWriter(filePath, encoding);
        graph.WriteTo(streamWriter, formattingOptions, syntaxOptions, syntaxRules);
        streamWriter.Flush();
    }

    /// <summary>
    ///     Converts the specified graph to its DOT format representation and writes it to the specified file (the file will be
    ///     overwritten if it already exists).
    /// </summary>
    /// <param name="graph">
    ///     The graph to convert.
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
    public static async Task SaveAsync(
        this DotGraph graph,
        string filePath,
        DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null,
        DotSyntaxRules? syntaxRules = null,
        Encoding? encoding = null
    )
    {
        using var streamWriter = CreateFileStreamWriter(filePath, encoding);
        await WriteAsyncInternal(graph, streamWriter, formattingOptions, syntaxOptions, syntaxRules);
    }

    /// <summary>
    ///     Converts the specified graph to its DOT format representation and writes it to the provided stream.
    /// </summary>
    /// <param name="graph">
    ///     The graph to convert.
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
    public static void Save(
        this DotGraph graph,
        Stream stream,
        DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null,
        DotSyntaxRules? syntaxRules = null,
        Encoding? encoding = null
    )
    {
        using var streamWriter = CreateStreamWriter(stream, encoding);
        graph.WriteTo(streamWriter, formattingOptions, syntaxOptions, syntaxRules);
        streamWriter.Flush();
    }

    /// <summary>
    ///     Converts the specified graph to its DOT format representation and writes it to the provided stream.
    /// </summary>
    /// <param name="graph">
    ///     The graph to convert.
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
        await WriteAsyncInternal(graph, streamWriter, formattingOptions, syntaxOptions, syntaxRules);
    }

    private static async Task WriteAsyncInternal(
        DotGraph graph,
        StreamWriter streamWriter,
        DotFormattingOptions? formattingOptions,
        DotSyntaxOptions? syntaxOptions,
        DotSyntaxRules? syntaxRules
    )
    {
        // it would be better to build the graph directly to stream, but the solution does not support async building
        var output = graph.ToDotString(formattingOptions, syntaxOptions, syntaxRules);
        await streamWriter.WriteAsync(output);
        await streamWriter.FlushAsync();
    }

    private static StreamWriter CreateStreamWriter(Stream stream, Encoding? encoding)
    {
        // this is for compatibility with .NET Standard where encoding has to be specified if you want to set leaveOpen
        encoding ??= new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
        return new StreamWriter(stream, encoding, bufferSize: -1, leaveOpen: true);
    }

    private static StreamWriter CreateFileStreamWriter(string filePath, Encoding? encoding) =>
        encoding is not null
            ? new StreamWriter(filePath, append: false, encoding)
            : new StreamWriter(filePath, append: false);
}