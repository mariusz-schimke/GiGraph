using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotWriters;
using Dotless.EntityGenerators.Options;
using Dotless.Nodes;
using Dotless.TextEscaping;
using System.Linq;

namespace Dotless.EntityGenerators.NodeGenerators
{
    public class DotNodeGenerator : DotEntityGenerator<DotNode, IDotNodeWriter>
    {
        public DotNodeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Write(DotNode node, IDotNodeWriter writer)
        {
            WriteIdentifier(node.Id, writer);
            WriteAttributes(node.Attributes, writer);
        }

        private void WriteIdentifier(string id, IDotNodeWriter writer)
        {
            id = new DotQuotationMarkEscaper().Escape(id)!;
            writer.WriteNodeIdentifier(id, IdRequiresQuoting(id));
        }

        protected virtual void WriteAttributes(DotAttributeCollection attributes, IDotNodeWriter writer)
        {
            if (attributes.Any())
            {
                var attributesWriter = writer.BeginAttributeList(_options.Attributes.PreferExplicitSeparator);
                _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(attributes).Write(attributes, attributesWriter);
                writer.EndAttributeList();
            }
        }
    }
}
