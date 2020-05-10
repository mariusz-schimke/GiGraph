using Gigraph.Dot.Core;
using Gigraph.Dot.Core.TextEscaping;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Entities.Subgraphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.GraphWriters;
using Gigraph.Dot.Writers.SubgraphWriters;

namespace Gigraph.Dot.Generators.SubgraphGenerators
{
    public class DotSubgraphGenerator : DotEntityGenerator<DotSubgraph, IDotSubgraphWriter>
    {
        protected readonly TextEscapingPipeline _graphIdEscaper = TextEscapingPipeline.CreateForGraphId();

        public DotSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual string EscapeSubgraphIdentifier(string id)
        {
            return _graphIdEscaper.Escape(id);
        }

        public override void Generate(DotSubgraph graph, IDotSubgraphWriter writer)
        {
            WriteDeclaration(graph.Id, graph.IsCluster, writer);
            WriteBody(graph, writer);
        }

        protected virtual void WriteDeclaration(string id, bool isCluster, IDotSubgraphWriter writer)
        {
            id = EscapeSubgraphIdentifier(id);

            if (isCluster)
            {
                id = $"cluster {id}";
            }

            writer.WriteSubgraphDeclaration(id, IdentifierRequiresQuoting(id));
        }

        protected virtual void WriteBody(DotGraphBody subgraphBody, IDotSubgraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(subgraphBody).Generate(subgraphBody, bodyWriter);
            writer.EndBody();
        }
    }
}
