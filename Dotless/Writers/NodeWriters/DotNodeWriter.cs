using Dotless.Core;
using Dotless.DotWriters;
using Dotless.GraphElements;
using Dotless.TextEscaping;
using Dotless.Writers.Options;

namespace Dotless.Writers.NodeWriters
{
    public class DotNodeWriter : DotEntityWriter<DotGraphNode>
    {
        public DotNodeWriter(DotSyntaxRules syntaxRules, DotWriterOptions options, DotEntityWriterCollection entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual bool IdRequiresQuoting(string value)
        {
            return _options.Nodes.PreferQuotedId || !_syntaxRules.IsValidIdentifier(value);
        }

        public override void Write(DotGraphNode node, DotStringWriter writer)
        {
            var id = new DotQuotationMarkEscaper().Escape(node.Id)!;

            var nodeContext = writer
                .AssertContext<DotStringWriter.GraphNodeListContext>()
                .BeginNodeContext(id, IdRequiresQuoting(id));

            WriteNodeAttributes(node.Attributes, nodeContext);

            nodeContext.EndContext();
        }

        protected virtual void WriteNodeAttributes(DotNodeAttributes attributes, DotStringWriter.NodeContext nodeContext)
        {
            var context = nodeContext.BeginAttributesContext(_options.Attributes.PreferExplicitDelimiter);

            _entityGenerators.GetForTypeOrForAnyBaseType(attributes).Write(attributes, context);

            context.EndContext();
        }
    }
}
