using GiGraph.Dot.Entities.Attributes.Collections.Subgraph;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Generators.Subgraphs
{
    public class DotSubgraphGenerator : DotCommonSubgraphGenerator<DotSubgraph, IDotSubgraphAttributeCollection>
    {
        public DotSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteDeclaration(string id, IDotSubgraphWriter writer)
        {
            id = EscapeIdentifier(id);
            writer.WriteSubgraphDeclaration(id, IdentifierRequiresQuoting(id));
        }
    }
}