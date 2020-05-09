using Gigraph.Dot.Builders;
using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Writers.Options;
using Gigraph.Dot.Writers.StringWriter;
using System.IO;
using System.Text;

namespace Gigraph.Dot.Helpers
{
    public static class DotGraphExtension
    {
        public static string Build(this DotGraph graph, DotFormattingOptions formattingOptions, DotGenerationOptions generationOptions, Encoding encoding)
        {
            var stream = new MemoryStream();
            using var streamWriter = new StreamWriter(stream, encoding);

            graph.Build(streamWriter, formattingOptions, generationOptions, encoding);

            streamWriter.Flush();
            return encoding.GetString(stream.ToArray());
        }

        public static void BuildToFile(this DotGraph graph, string filePath, DotFormattingOptions formattingOptions, DotGenerationOptions generationOptions, Encoding encoding)
        {
            using var streamWriter = new StreamWriter(filePath, append: false, encoding);
            graph.Build(streamWriter, formattingOptions, generationOptions, encoding);
        }

        public static void Build(this DotGraph graph, StreamWriter output, DotFormattingOptions formattingOptions, DotGenerationOptions generationOptions, Encoding encoding)
        {
            var generatorsProviderBuilder = new DotEntityGeneratorsProviderBuilder();
            var graphGeneratorBuilder = new DotGraphGeneratorBuilder(generatorsProviderBuilder);

            var graphBuilder = graphGeneratorBuilder.Build(new DotSyntaxRules(), generationOptions);

            var stringWriter = new DotStringWriter(output, formattingOptions);
            var graphWriterFactory = new DotGraphStringWriterFactory(stringWriter);

            graphBuilder.Generate(graph, graphWriterFactory);
        }
    }
}
