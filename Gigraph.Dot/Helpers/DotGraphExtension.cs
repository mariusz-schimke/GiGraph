using Gigraph.Dot.Builders;
using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Writers;
using Gigraph.Dot.Writers.GraphWriters;
using Gigraph.Dot.Writers.Options;
using System.IO;
using System.Text;

namespace Gigraph.Dot.Helpers
{
    public static class DotGraphExtension
    {
        public static string Build(this DotGraph graph, DotFormattingOptions formattingOptions = null, DotGenerationOptions generationOptions = null, Encoding encoding = null)
        {
            var output = new MemoryStream();

            using var outputWriter = encoding is { }
                ? new StreamWriter(output, encoding)
                : new StreamWriter(output);

            graph.Build(outputWriter, formattingOptions, generationOptions);

            outputWriter.Flush();
            return outputWriter.Encoding.GetString(output.ToArray());
        }

        public static void SaveToFile(this DotGraph graph, string filePath, DotFormattingOptions formattingOptions = null, DotGenerationOptions generationOptions = null, Encoding encoding = null)
        {
            using var streamWriter = encoding is { }
                ? new StreamWriter(filePath, append: false, encoding)
                : new StreamWriter(filePath, append: false);

            graph.Build(streamWriter, formattingOptions, generationOptions);
        }

        public static void Build(this DotGraph graph, StreamWriter outputWriter, DotFormattingOptions formattingOptions = null,
            DotGenerationOptions generationOptions = null, DotSyntaxRules syntaxRules = null)
        {
            var generatorsProviderBuilder = new DotEntityGeneratorsProviderBuilder();
            var graphGeneratorBuilder = new DotGraphGeneratorBuilder(generatorsProviderBuilder);

            graph.Build(outputWriter, graphGeneratorBuilder, formattingOptions, generationOptions, syntaxRules);
        }

        public static void Build(this DotGraph graph, StreamWriter outputWriter, DotGraphGeneratorBuilder graphGeneratorBuilder,
            DotFormattingOptions formattingOptions = null, DotGenerationOptions generationOptions = null, DotSyntaxRules syntaxRules = null)
        {
            syntaxRules ??= new DotSyntaxRules();
            formattingOptions ??= new DotFormattingOptions();
            generationOptions ??= new DotGenerationOptions();

            var graphBuilder = graphGeneratorBuilder.Build(syntaxRules, generationOptions);

            var tokenWriter = new DotTokenWriter(outputWriter, formattingOptions);
            var graphWriterFactory = new DotGraphWriterFactory(tokenWriter);

            graphBuilder.Generate(graph, graphWriterFactory);
        }
    }
}
