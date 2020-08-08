using System.Linq;
using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Graphs.Collections;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Generators.Subgraphs
{
    public class DotSubgraphCollectionGenerator<TSubgraph, TSubgraphAttributes> : DotEntityGenerator<DotGraphCollection<TSubgraph, TSubgraphAttributes>, IDotSubgraphWriterRoot>
        where TSubgraph : DotCommonGraph<TSubgraphAttributes>
        where TSubgraphAttributes : IDotAttributeCollection
    {
        public DotSubgraphCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotGraphCollection<TSubgraph, TSubgraphAttributes> subgraphs, IDotSubgraphWriterRoot writer)
        {
            var orderedSubgraphs = _options.OrderElements
                ? subgraphs.Cast<IDotOrderable>()
                   .OrderBy(subgraph => subgraph.OrderingKey)
                   .Cast<TSubgraph>()
                : subgraphs;

            foreach (var subgraph in orderedSubgraphs)
            {
                WriteSubgraph(subgraph, writer);
            }
        }

        protected virtual void WriteSubgraph(TSubgraph subgraph, IDotSubgraphWriterRoot writer)
        {
            var subgraphWriter = writer.BeginSubgraph(_options.Subgraphs.PreferExplicitKeyword);
            _entityGenerators.GetForEntity<IDotSubgraphWriter>(subgraph).Generate(subgraph, subgraphWriter);
            writer.EndSubgraph();
        }
    }
}