using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Nodes;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.NodeWriters;
using System.Linq;

namespace Gigraph.Dot.Generators.NodeGenerators
{
    public class DotNodeCollectionGenerator : DotEntityGenerator<DotNodeCollection, IDotNodeCollectionWriter>
    {
        public DotNodeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotNodeCollection nodes, IDotNodeCollectionWriter writer)
        {
            var orderedNodes = nodes.OrderBy(n => n.Id).ToList();

            foreach (var node in orderedNodes)
            {
                var nodeWriter = writer.BeginNode();
                _entityGenerators.GetForEntity<IDotNodeWriter>(node).Generate(node, nodeWriter);
                writer.EndNode();
            }
        }
    }
}
