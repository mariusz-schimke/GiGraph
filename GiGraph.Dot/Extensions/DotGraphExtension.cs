using System.IO;
using System.Text;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Output.Generators.Graphs;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers;
using GiGraph.Dot.Output.Writers.GraphWriters;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    ///     Provides helper methods for <see cref="DotGraph" />.
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
        /// <param name="generationOptions">
        ///     The generation options to use.
        /// </param>
        /// <param name="syntaxRules">
        ///     The syntax rules to use.
        /// </param>
        /// <param name="encoding">
        ///     The encoding to use for the output text.
        /// </param>
        public static string Build(this DotGraph graph, DotFormattingOptions formattingOptions = null,
            DotGenerationOptions generationOptions = null, DotSyntaxRules syntaxRules = null, Encoding encoding = null)
        {
            var output = new MemoryStream();

            using var outputWriter = encoding is { }
                ? new StreamWriter(output, encoding)
                : new StreamWriter(output);

            graph.Build(outputWriter, formattingOptions, generationOptions, syntaxRules);

            outputWriter.Flush();
            return outputWriter.Encoding.GetString(output.ToArray());
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
        /// <param name="generationOptions">
        ///     The generation options to use.
        /// </param>
        /// <param name="syntaxRules">
        ///     The syntax rules to use.
        /// </param>
        public static void Build(this DotGraph graph, StreamWriter outputWriter, DotFormattingOptions formattingOptions = null,
            DotGenerationOptions generationOptions = null, DotSyntaxRules syntaxRules = null)
        {
            var generatorsProviderBuilder = new DotEntityGeneratorsProviderBuilder();
            var graphGeneratorBuilder = new DotGraphGeneratorBuilder(generatorsProviderBuilder);

            graph.Build(outputWriter, graphGeneratorBuilder, formattingOptions, generationOptions, syntaxRules);
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
        /// <param name="generationOptions">
        ///     The generation options to use.
        /// </param>
        /// <param name="syntaxRules">
        ///     The syntax rules to use.
        /// </param>
        /// <param name="graphGeneratorBuilder">
        ///     The graph generator builder to use in order to get the graph builder to generate the DOT output with.
        /// </param>
        public static void Build(this DotGraph graph, StreamWriter outputWriter, IDotGraphGeneratorBuilder graphGeneratorBuilder,
            DotFormattingOptions formattingOptions = null, DotGenerationOptions generationOptions = null, DotSyntaxRules syntaxRules = null)
        {
            syntaxRules ??= new DotSyntaxRules();
            formattingOptions ??= new DotFormattingOptions();
            generationOptions ??= new DotGenerationOptions();

            var graphBuilder = graphGeneratorBuilder.Build(syntaxRules, generationOptions);

            var tokenWriter = new DotTokenWriter(outputWriter, formattingOptions, indentationLevel: 0);
            var graphWriterRoot = new DotGraphWriterRoot(tokenWriter);

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
        /// <param name="generationOptions">
        ///     The generation options to use.
        /// </param>
        /// <param name="syntaxRules">
        ///     The syntax rules to use.
        /// </param>
        /// <param name="encoding">
        ///     The encoding to use for the output text.
        /// </param>
        public static void SaveToFile(this DotGraph graph, string filePath, DotFormattingOptions formattingOptions = null,
            DotGenerationOptions generationOptions = null, DotSyntaxRules syntaxRules = null, Encoding encoding = null)
        {
            using var streamWriter = encoding is { }
                ? new StreamWriter(filePath, append: false, encoding)
                : new StreamWriter(filePath, append: false);

            graph.Build(streamWriter, formattingOptions, generationOptions, syntaxRules);
        }
    }
}