using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Generators.GraphGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using GiGraph.Dot.Writers.SubgraphWriters;

namespace GiGraph.Dot.Generators.SubgraphGenerators
{
    public abstract class DotCommonSubgraphGenerator<TSubgraph> : DotCommonGraphGenerator<TSubgraph, IDotSubgraphWriter>
        where TSubgraph : DotCommonSubgraph
    {
        protected readonly bool _isCluster;

        protected DotCommonSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper, bool isCluster)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
            _isCluster = isCluster;
        }

        public DotCommonSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, bool isCluster)
            : this(syntaxRules, options, entityGenerators, identifierEscaper: null, isCluster)
        {
        }

        public override void Generate(TSubgraph subgraph, IDotSubgraphWriter writer)
        {
            WriteDeclaration(subgraph.Id, writer);
            WriteBody(subgraph, writer);
        }

        protected virtual void WriteDeclaration(string id, IDotSubgraphWriter writer)
        {
            id = EscapeIdentifier(id);
            writer.WriteSubgraphDeclaration(id, _isCluster, IdentifierRequiresQuoting(id));
        }
    }
}
