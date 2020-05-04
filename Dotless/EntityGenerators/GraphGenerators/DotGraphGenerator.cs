using Dotless.Core;
using Dotless.DotWriters;
using Dotless.EntityGenerators.Options;
using Dotless.Graphs;

namespace Dotless.EntityGenerators.GraphGenerators
{
    public class DotGraphGenerator : DotEntityGenerator<DotGraph, IDotGraphWriter>
    {
        public DotGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Write(DotGraph graph, IDotGraphWriter writer)
        {
            writer.WriteGraphDeclaration
            (
                graph.Id,
                graph.IsDirected,
                graph.IsStrict,
                quoteId: graph.Id is { } && IdRequiresQuoting(graph.Id!)
            );

            WriteBody(graph, writer);
        }

        protected virtual void WriteBody(DotGraphBody graphBody, IDotGraphWriter writer)
        {
            var bodyWriter = writer.BeginGraphBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(graphBody).Write(graphBody, bodyWriter);
            writer.EndGraphBody();
        }
    }
}
