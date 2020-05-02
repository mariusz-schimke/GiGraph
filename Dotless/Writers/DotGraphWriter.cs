using Dotless.Core;
using Dotless.DotWriters;
using Dotless.Graphs;
using Dotless.Writers.AttributeWriters;
using Dotless.Writers.NodeWriters;
using Dotless.Writers.Options;

namespace Dotless.Writers
{
    public class DotGraphWriter : DotEntityWriter<DotGraph>
    {
        public DotGraphWriter(DotSyntaxRules syntaxRules, DotWriterOptions options, DotEntityWriterCollection entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Write(DotGraph graph, DotStringWriter writer)
        {
            var context = writer.AssertContext<DotStringWriter.GraphContext>();
        }

        public static DotGraphWriter CreateDefault()
        {
            var syntaxRules = new DotSyntaxRules();
            var dotWriterOptions = new DotWriterOptions();
            var converters = new DotEntityWriterCollection();

            converters.Add(new DotGraphWriter(syntaxRules, dotWriterOptions, converters));
            converters.Add(new DotGraphAttributesWriter(syntaxRules, dotWriterOptions, converters));
            converters.Add(new DotNodeAttributesWriter(syntaxRules, dotWriterOptions, converters));

            converters.Add(new DotTextLabelAttributeWriter(syntaxRules, dotWriterOptions, converters));
            converters.Add(new DotHtmlLabelAttributeWriter(syntaxRules, dotWriterOptions, converters));

            converters.Add(new DotNodeWriter(syntaxRules, dotWriterOptions, converters));

            return new DotGraphWriter(syntaxRules, dotWriterOptions, converters);
        }
    }
}
