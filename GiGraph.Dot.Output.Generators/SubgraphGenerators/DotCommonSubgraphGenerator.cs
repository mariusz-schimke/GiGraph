using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Generators.GraphGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.SubgraphWriters;

namespace GiGraph.Dot.Output.Generators.SubgraphGenerators
{
    public class DotCommonSubgraphGenerator<TSubgraph> : DotCommonGraphGenerator<TSubgraph, IDotSubgraphWriter>
        where TSubgraph : DotCommonSubgraph
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

        protected virtual void WriteDeclaration(string id, IDotSubgraphWriter writer)
        {
            id = EscapeIdentifier(id);
            writer.WriteSubgraphDeclaration(id, IdentifierRequiresQuoting(id));
        }
    }
}