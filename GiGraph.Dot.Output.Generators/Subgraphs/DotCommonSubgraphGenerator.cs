using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Output.Generators.Graphs;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Generators.Subgraphs
{
    public abstract class DotCommonSubgraphGenerator<TSubgraph, TSubgraphAttributes> : DotCommonGraphGenerator<TSubgraph, TSubgraphAttributes, IDotSubgraphWriter>
        where TSubgraph : DotCommonGraph<TSubgraphAttributes>
        where TSubgraphAttributes : IDotAttributeCollection
    {
        public DotCommonSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(TSubgraph subgraph, IDotSubgraphWriter writer)
        {
            WriteDeclaration(subgraph.Id, writer);
            WriteBody(subgraph, writer);
        }

        protected abstract void WriteDeclaration(string id, IDotSubgraphWriter writer);
    }
}