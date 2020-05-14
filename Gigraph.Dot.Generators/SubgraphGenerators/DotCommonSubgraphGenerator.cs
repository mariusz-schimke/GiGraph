using Gigraph.Dot.Core;
using Gigraph.Dot.Core.TextEscaping;
using Gigraph.Dot.Entities.Subgraphs;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.GraphWriters;
using Gigraph.Dot.Writers.SubgraphWriters;

namespace Gigraph.Dot.Generators.SubgraphGenerators
{
    public abstract class DotCommonSubgraphGenerator<TSubgraph> : DotEntityGenerator<TSubgraph, IDotSubgraphWriter>
        where TSubgraph : DotCommonSubgraph
    {
        protected readonly TextEscapingPipeline _graphIdEscaper = TextEscapingPipeline.CreateForGraphId();
        protected readonly bool _isCluster;

        public DotCommonSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, bool isCluster)
            : base(syntaxRules, options, entityGenerators)
        {
            _isCluster = isCluster;
        }

        public override void Generate(TSubgraph subgraph, IDotSubgraphWriter writer)
        {
            WriteDeclaration(subgraph, writer);
            WriteBody(subgraph, writer);
        }

        protected virtual string EscapeSubgraphIdentifier(string id)
        {
            return _graphIdEscaper.Escape(id);
        }

        protected virtual void WriteDeclaration(TSubgraph subgraph, IDotSubgraphWriter writer)
        {
            var id = EscapeSubgraphIdentifier(subgraph.Id);
            writer.WriteSubgraphDeclaration(id, _isCluster, IdentifierRequiresQuoting(id));
        }

        protected virtual void WriteBody(TSubgraph subgraph, IDotSubgraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(subgraph).Generate(subgraph, bodyWriter);
            writer.EndBody();
        }
    }
}
