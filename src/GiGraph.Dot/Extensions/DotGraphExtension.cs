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
    public static void Save(
        this DotGraph graph,
        TextWriter writer,
        DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null,
        DotSyntaxRules? syntaxRules = null
    )
    {
        var generatorsProviderBuilder = new DotEntityGeneratorsProviderBuilder();
        var graphGeneratorBuilder = new DotGraphGeneratorBuilder(generatorsProviderBuilder);

        graph.Save(writer, graphGeneratorBuilder, formattingOptions, syntaxOptions, syntaxRules);
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
    public static void Save(
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
        using var fileStream = File.Create(filePath);
        graph.Save(fileStream, formattingOptions, syntaxOptions, syntaxRules, encoding);
        fileStream.Flush();
    }

    /// <summary>
    ///     Converts the specified graph to its DOT format representation and writes it to the specified file (the file will be
    ///     overwritten if it already exists). The content is generated synchronously, but written asynchronously.
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
        using var fileStream = File.Create(filePath);
        await graph.SaveAsync(fileStream, formattingOptions, syntaxOptions, syntaxRules, encoding);
        await fileStream.FlushAsync();
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
        graph.Save(streamWriter, formattingOptions, syntaxOptions, syntaxRules);
        streamWriter.Flush();
    }

    /// <summary>
    ///     Converts the specified graph to its DOT format representation and writes it to the provided stream. The content is generated
    ///     synchronously, but written asynchronously.
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

        // it would be better to build the graph directly to stream, but the solution does not support async building
        var output = graph.ToDot(formattingOptions, syntaxOptions, syntaxRules);
        await streamWriter.WriteAsync(output);
        await streamWriter.FlushAsync();
    }

    private static StreamWriter CreateStreamWriter(Stream stream, Encoding? encoding)
    {
        // this is for compatibility with .NET Standard where encoding has to be specified if you want to set leaveOpen
        encoding ??= new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
        return new StreamWriter(stream, encoding, bufferSize: -1, leaveOpen: true);
    }
}