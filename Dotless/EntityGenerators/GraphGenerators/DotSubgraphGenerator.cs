using Dotless.Core;
using Dotless.DotWriters;
using Dotless.EntityGenerators.Options;
using Dotless.Graphs;

namespace Dotless.EntityGenerators.GraphGenerators
{
    public class DotSubgraphGenerator : DotEntityGenerator<DotSubgraph, IDotSubgraphWriter>
    {
        public DotSubgraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Write(DotSubgraph graph, IDotSubgraphWriter writer)
        {
            var id = EscapeIdentifier(graph.Id);

            writer.WriteSubgraphDeclaration
            (
                id,
                quote: id is { } && IdentifierRequiresQuoting(id!)
            );

            WriteBody(graph, writer);
        }

        protected virtual void WriteBody(DotGraphBody subgraphBody, IDotSubgraphWriter writer)
        {
            var bodyWriter = writer.BeginSubgraphBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(subgraphBody).Write(subgraphBody, bodyWriter);
            writer.EndSubraphBody();
        }
    }
}
