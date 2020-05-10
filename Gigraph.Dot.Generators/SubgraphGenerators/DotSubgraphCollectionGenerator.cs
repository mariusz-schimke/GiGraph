using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Subgraphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.SubgraphWriters;
using System.Linq;

namespace Gigraph.Dot.Generators.SubgraphGenerators
{
    public class DotSubgraphCollectionGenerator : DotEntityGenerator<DotSubgraphCollection, IDotSubgraphCollectionWriter>
    {
        public DotSubgraphCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotSubgraphCollection subgraphs, IDotSubgraphCollectionWriter writer)
        {
            var orderedSubgraphs = subgraphs.OrderBy(n => n.IsCluster).ThenBy(n => n.Id).ToList();

            foreach (var subgraph in orderedSubgraphs)
            {
                var subgraphWriter = writer.BeginSubgraph();
                _entityGenerators.GetForEntity<IDotSubgraphWriter>(subgraph).Generate(subgraph, subgraphWriter);
                writer.EndSubgraph();
            }
        }
    }
}
