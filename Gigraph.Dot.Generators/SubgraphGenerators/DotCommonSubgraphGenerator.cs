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
            WriteDeclaration(subgraph.Id, writer);
            WriteBody(subgraph, writer);
        }

        protected virtual string EscapeSubgraphIdentifier(string id)
        {
            return _graphIdEscaper.Escape(id);
        }

        protected virtual void WriteDeclaration(string id, IDotSubgraphWriter writer)
        {
            id = EscapeSubgraphIdentifier(id);
            writer.WriteSubgraphDeclaration(id, _isCluster, IdentifierRequiresQuoting(id));
        }

        protected virtual void WriteBody(DotCommonSubgraph subgraphBody, IDotSubgraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(subgraphBody).Generate(subgraphBody, bodyWriter);
            writer.EndBody();
        }
    }
}
