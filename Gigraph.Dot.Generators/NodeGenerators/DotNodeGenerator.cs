using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes;
using Gigraph.Dot.Entities.Nodes;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.NodeWriters;
using System.Linq;

namespace Gigraph.Dot.Generators.NodeGenerators
{
    public class DotNodeGenerator : DotEntityGenerator<DotNode, IDotNodeWriter>
    {
        public DotNodeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotNode node, IDotNodeWriter writer)
        {
            WriteIdentifier(node.Id, writer);
            WriteAttributes(node.Attributes, writer);
        }

        protected virtual void WriteIdentifier(string id, IDotNodeWriter writer)
        {
            id = EscapeIdentifier(id);
            writer.WriteNodeIdentifier(id, IdentifierRequiresQuoting(id));
        }

        protected virtual void WriteAttributes(DotAttributeCollection attributes, IDotNodeWriter writer)
        {
            var attributesWriter = writer.BeginAttributeList(_options.Attributes.PreferExplicitSeparator);
            _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(attributes).Generate(attributes, attributesWriter);
            writer.EndAttributeList(attributes.Count());
        }
    }
}
