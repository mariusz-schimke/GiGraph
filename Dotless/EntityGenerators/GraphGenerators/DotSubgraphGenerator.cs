using Dotless.Core;
using Dotless.DotWriters;
using Dotless.EntityGenerators.Options;
using Dotless.Graphs;
using Dotless.TextEscaping;

namespace Dotless.EntityGenerators.GraphGenerators
{
    public class DotSubgraphGenerator : DotEntityGenerator<DotSubgraph, IDotSubgraphWriter>
    {
        protected readonly TextEscapingPipeline _graphIdEscaper = TextEscapingPipeline.CreateForGraphId();

        public DotSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual string EscapeSubgraphIdentifier(string id)
        {
            return _graphIdEscaper.Escape(id);
        }

        public override void Write(DotSubgraph graph, IDotSubgraphWriter writer)
        {
            WriteDeclaration(graph, writer);
            WriteBody(graph, writer);
        }

        protected virtual void WriteDeclaration(DotSubgraph graph, IDotSubgraphWriter writer)
        {
            // the identifier has to be prefixed with the 'cluster' keyword,
            // as otherwise subgraph is not explicitly drawn by DOT graph renderers
            var id = $"cluster {EscapeSubgraphIdentifier(graph.Id)}";
            writer.WriteSubgraphDeclaration(id, IdentifierRequiresQuoting(id));
        }

        protected virtual void WriteBody(DotGraphBody subgraphBody, IDotSubgraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(subgraphBody).Write(subgraphBody, bodyWriter);
            writer.EndBody();
        }
    }
}
