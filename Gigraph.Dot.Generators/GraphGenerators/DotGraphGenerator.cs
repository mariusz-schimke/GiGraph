using Gigraph.Dot.Core;
using Gigraph.Dot.Core.TextEscaping;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Writers.GraphWriters;

namespace Gigraph.Dot.Generators.GraphGenerators
{
    public class DotGraphGenerator : DotEntityGenerator<DotGraph, IDotGraphWriterFactory>
    {
        protected readonly TextEscapingPipeline _graphIdEscaper = TextEscapingPipeline.CreateForGraphId();

        public DotGraphGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected virtual string EscapeGraphIdentifier(string id)
        {
            return _graphIdEscaper.Escape(id);
        }

        public override void Generate(DotGraph graph, IDotGraphWriterFactory writerFactory)
        {
            var writer = writerFactory.Create(graph.IsDirected);

            WriteDeclaration(graph.Id, graph.IsStrict, writer);
            WriteBody(graph, writer);
        }

        protected virtual void WriteDeclaration(string id, bool isStrict, IDotGraphWriter writer)
        {
            id = EscapeGraphIdentifier(id);

            writer.WriteGraphDeclaration
            (
                id,
                isStrict,
                quoteId: id is { } && IdentifierRequiresQuoting(id)
            );
        }

        protected virtual void WriteBody(DotGraphBody graphBody, IDotGraphWriter writer)
        {
            var bodyWriter = writer.BeginBody();
            _entityGenerators.GetForEntity<IDotGraphBodyWriter>(graphBody).Generate(graphBody, bodyWriter);
            writer.EndBody();
        }
    }
}
