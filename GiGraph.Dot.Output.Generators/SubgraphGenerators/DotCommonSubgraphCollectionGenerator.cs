using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Entities.Subgraphs.Collections;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.SubgraphWriters;
using System.Linq;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Generators.TextEscaping;

namespace GiGraph.Dot.Output.Generators.SubgraphGenerators
{
    public class DotCommonSubgraphCollectionGenerator<TSubgraph> : DotEntityGenerator<DotCommonSubgraphCollection<TSubgraph>, IDotSubgraphWriterRoot>
        where TSubgraph : DotCommonSubgraph
    {
        protected DotCommonSubgraphCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotCommonSubgraphCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonSubgraphCollection<TSubgraph> subgraphs, IDotSubgraphWriterRoot writer)
        {
            var orderedSubgraphs = _options.OrderElements
                ? subgraphs.Cast<IDotOrderableEntity>()
                           .OrderBy(subgraph => subgraph.OrderingKey)
                           .Cast<DotCommonSubgraph>()
                : subgraphs;

            foreach (var subgraph in orderedSubgraphs)
            {
                WriteSubgraph(subgraph, writer);
            }
        }

        protected virtual void WriteSubgraph(DotCommonSubgraph subgraph, IDotSubgraphWriterRoot writer)
        {
            var subgraphWriter = writer.BeginSubgraph(_options.Subgraphs.PreferExplicitKeyword);
            _entityGenerators.GetForEntity<IDotSubgraphWriter>(subgraph).Generate(subgraph, subgraphWriter);
            writer.EndSubgraph();
        }
    }
}
