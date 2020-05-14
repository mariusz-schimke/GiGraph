using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Nodes;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.NodeWriters;

namespace Gigraph.Dot.Generators.NodeGenerators
{
    public class DotNodeGenerator : DotEntityWithAttributeListGenerator<DotNode, IDotNodeWriter>
    {
        public DotNodeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
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
    }
}
