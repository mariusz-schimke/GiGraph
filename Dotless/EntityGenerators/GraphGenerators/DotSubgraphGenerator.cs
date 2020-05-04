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
            writer.WriteSubgraphDeclaration
            (
                graph.Id,
                quote: graph.Id is { } && IdRequiresQuoting(graph.Id!)
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
