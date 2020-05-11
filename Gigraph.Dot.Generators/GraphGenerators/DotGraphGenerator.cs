using Gigraph.Dot.Core;
using Gigraph.Dot.Core.TextEscaping;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.GraphWriters;

namespace Gigraph.Dot.Generators.GraphGenerators
{
    public class DotGraphGenerator : DotEntityGenerator<DotGraph, IDotGraphWriterRoot>
    {
        protected readonly TextEscapingPipeline _graphIdEscaper = TextEscapingPipeline.CreateForGraphId();

        public DotGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual string EscapeGraphIdentifier(string id)
        {
            return _graphIdEscaper.Escape(id);
        }

        public override void Generate(DotGraph graph, IDotGraphWriterRoot writerRoot)
        {
            var writer = writerRoot.BeginGraph(graph.IsDirected);

            WriteDeclaration(graph, writer);
            WriteBody(graph, writer);
        }

        protected virtual void WriteDeclaration(DotGraph graph, IDotGraphWriter writer)
        {
            var id = graph.Id;

            if (id is { })
            {
                id = EscapeGraphIdentifier(id);
            }

            // whether the graph and its edges will be directed, is decided by the writer instance
            writer.WriteGraphDeclaration
            (
                id,
                graph.IsStrict,
                quoteId: id is { } && IdentifierRequiresQuoting(id)
            );
        }

        protected virtual void WriteBody(DotGraph graph, IDotGraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(graph).Generate(graph, bodyWriter);
            writer.EndBody();
        }
    }
}
