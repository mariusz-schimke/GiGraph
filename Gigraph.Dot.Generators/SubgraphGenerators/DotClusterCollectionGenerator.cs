using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Subgraphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.SubgraphWriters;
using System.Linq;

namespace Gigraph.Dot.Generators.SubgraphGenerators
{
    public class DotClusterCollectionGenerator : DotEntityGenerator<DotClusterCollection, IDotSubgraphCollectionWriter>
    {
        public DotClusterCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotClusterCollection clusters, IDotSubgraphCollectionWriter writer)
        {
            var orderedClusters = clusters.OrderBy(n => n.Id).ToList();

            foreach (var subgraph in orderedClusters)
            {
                var subgraphWriter = writer.BeginSubgraph();
                _entityGenerators.GetForEntity<IDotSubgraphWriter>(subgraph).Generate(subgraph, subgraphWriter);
                writer.EndSubgraph();
            }
        }
    }
}
