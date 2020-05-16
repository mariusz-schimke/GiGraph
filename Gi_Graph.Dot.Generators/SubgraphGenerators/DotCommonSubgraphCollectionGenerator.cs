using GiGraph.Dot.Core;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Writers.SubgraphWriters;
using System.Linq;

namespace GiGraph.Dot.Generators.SubgraphGenerators
{
    public class DotCommonSubgraphCollectionGenerator : DotEntityGenerator<DotCommonSubgraphCollection, IDotSubgraphWriterRoot>
    {
        public DotCommonSubgraphCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonSubgraphCollection subgraphs, IDotSubgraphWriterRoot writer)
        {
            var orderedSubgraphs = subgraphs.OrderByDescending(n => n.GetType().FullName).ThenBy(n => n.Id).ToList();

            foreach (var subgraph in orderedSubgraphs)
            {
                var subgraphWriter = writer.BeginSubgraph(_options.Subgraphs.PreferExplicitKeyword);
                _entityGenerators.GetForEntity<IDotSubgraphWriter>(subgraph).Generate(subgraph, subgraphWriter);
                writer.EndSubgraph();
            }
        }
    }
}
