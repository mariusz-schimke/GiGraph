using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using GiGraph.Dot.Writers.SubgraphWriters;
using System.Linq;

namespace GiGraph.Dot.Generators.SubgraphGenerators
{
    public class DotCommonSubgraphCollectionGenerator : DotEntityGenerator<DotCommonSubgraphCollection, IDotSubgraphWriterRoot>
    {
        protected DotCommonSubgraphCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotCommonSubgraphCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonSubgraphCollection subgraphs, IDotSubgraphWriterRoot writer)
        {
            var orderedSubgraphs = subgraphs
                .OrderByDescending(n => n.GetType().FullName)
                .ThenBy(n => n.Id)
                .ToArray();

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
