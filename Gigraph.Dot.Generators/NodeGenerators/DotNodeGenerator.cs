using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Nodes;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.NodeWriters;
using System.Linq;

namespace Gigraph.Dot.Generators.NodeGenerators
{
    public class DotNodeGenerator : DotEntityGenerator<DotNode, IDotNodeWriter>
    {
        public DotNodeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotNode node, IDotNodeWriter writer)
        {
            WriteIdentifier(node, writer);
            WriteAttributes(node, writer);
        }

        protected virtual void WriteIdentifier(DotNode node, IDotNodeWriter writer)
        {
            var id = EscapeIdentifier(node.Id);
            writer.WriteNodeIdentifier(id, IdentifierRequiresQuoting(id));
        }

        protected virtual void WriteAttributes(DotNode node, IDotNodeWriter writer)
        {
            var attributesWriter = writer.BeginAttributeList(_options.Attributes.PreferExplicitSeparator);
            _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(node.Attributes).Generate(node.Attributes, attributesWriter);
            writer.EndAttributeList(node.Attributes.Count());
        }
    }
}
