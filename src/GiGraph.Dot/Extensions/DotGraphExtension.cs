﻿using System.IO;
using System.Text;
using System.Threading.Tasks;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Output.Generators.Graphs;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Graphs;
using GiGraph.Dot.Output.Writers.Options;
using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Extensions;

/// <summary>
///     Provides extension methods for <see cref="DotGraph" />.
/// </summary>
public static class DotGraphExtension
{
    /// <summary>
    ///     Stringifies the specified graph to the DOT format.
    /// </summary>
    /// <param name="graph">
    ///     The graph to stringify.
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
    public static string Build(this DotGraph graph, DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null, DotSyntaxRules? syntaxRules = null)
    {
        using var stringWriter = new StringWriter();
        graph.Build(stringWriter, formattingOptions, syntaxOptions, syntaxRules);

        return stringWriter.ToString();
    }

    /// <summary>
    ///     Stringifies the specified graph to the DOT format into a stream writer.
    /// </summary>
    /// <param name="graph">
    ///     The graph to stringify.
    /// </param>
    /// <param name="outputWriter">
    ///     The output to write the DOT string to.
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
    public static void Build(this DotGraph graph, TextWriter outputWriter, DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null, DotSyntaxRules? syntaxRules = null)
    {
        var generatorsProviderBuilder = new DotEntityGeneratorsProviderBuilder();
        var graphGeneratorBuilder = new DotGraphGeneratorBuilder(generatorsProviderBuilder);

        graph.Build(outputWriter, graphGeneratorBuilder, formattingOptions, syntaxOptions, syntaxRules);
    }

    /// <summary>
    ///     Stringifies the specified graph to the DOT format into a stream writer.
    /// </summary>
    /// <param name="graph">
    ///     The graph to stringify.
    /// </param>
    /// <param name="outputWriter">
    ///     The output to write the DOT string to.
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
    public static void Build(this DotGraph graph, TextWriter outputWriter, IDotGraphGeneratorBuilder graphGeneratorBuilder,
        DotFormattingOptions? formattingOptions = null, DotSyntaxOptions? syntaxOptions = null, DotSyntaxRules? syntaxRules = null)
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

        var tokenWriter = new DotTokenWriter(outputWriter, tokenWriterOptions);
        var graphWriterRoot = new DotGraphWriterRoot(tokenWriter, formattingOptions);

        var graphBuilder = graphGeneratorBuilder.Build(syntaxRules, syntaxOptions);
        graphBuilder.Generate(graph, graphWriterRoot);
    }

    /// <summary>
    ///     Stringifies the specified graph to the DOT format and saves it to the specified file (the file will be overwritten if it
    ///     already exists). Provide a custom encoding if you want a BOM (Byte Order Mark) to be written to the file.
    /// </summary>
    /// <param name="graph">
    ///     The graph to stringify.
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
    public static void SaveToFile(this DotGraph graph, string filePath, DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null, DotSyntaxRules? syntaxRules = null, Encoding? encoding = null)
    {
        using var streamWriter = CreateFileStreamWriter(filePath, encoding);
        graph.Build(streamWriter, formattingOptions, syntaxOptions, syntaxRules);
    }

    /// <summary>
    ///     Stringifies the specified graph to the DOT format and saves it to the specified file (the file will be overwritten if it
    ///     already exists). Provide a custom encoding if you want a BOM (Byte Order Mark) to be written to the file.
    /// </summary>
    /// <param name="graph">
    ///     The graph to stringify.
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
    public static async Task SaveToFileAsync(this DotGraph graph, string filePath, DotFormattingOptions? formattingOptions = null,
        DotSyntaxOptions? syntaxOptions = null, DotSyntaxRules? syntaxRules = null, Encoding? encoding = null)
    {
        var output = graph.Build(formattingOptions, syntaxOptions, syntaxRules);

        // it would be better to build the graph directly to stream, but the solution does not support async building
        await using var streamWriter = CreateFileStreamWriter(filePath, encoding);
        await streamWriter.WriteAsync(output);
        await streamWriter.FlushAsync();
    }

    private static TextWriter CreateFileStreamWriter(string filePath, Encoding? encoding) =>
        encoding is not null
            ? new(filePath, append: false, encoding)
            : new StreamWriter(filePath, append: false);
}