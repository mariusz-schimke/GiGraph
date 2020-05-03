using Dotless.Core;
using Dotless.DotWriters;
using Dotless.Graphs;
using Dotless.Nodes;
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

        public override bool Write(DotGraph graph, DotStringWriter writer)
        {
            var context = writer.AssertContext<DotStringWriter.GraphContext>();

            WriteAttributes(graph.Attributes, context);
            WriteNodes(graph.Nodes, context);

            context.EndContext();

            return true;
        }

        protected virtual void WriteAttributes(DotGraphAttributes attributes, DotStringWriter.GraphContext graphContext)
        {
            var attributesContext = graphContext.BeginAttributesContext(_options.Attributes.PreferExplicitDelimiter);
            _entityGenerators.GetForTypeOrForAnyBaseType(attributes).Write(attributes, attributesContext);
            attributesContext.EndContext();
        }

        protected virtual void WriteNodes(DotGraphNodes nodes, DotStringWriter.GraphContext graphContext)
        {
            var nodesContext = graphContext.BeginNodesContext(_options.PreferStatementDelimiter);
            _entityGenerators.GetForTypeOrForAnyBaseType(nodes).Write(nodes, nodesContext);
            nodesContext.EndContext();
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
            converters.Add(new DotGraphNodesWriter(syntaxRules, dotWriterOptions, converters));

            return new DotGraphWriter(syntaxRules, dotWriterOptions, converters);
        }
    }
}
