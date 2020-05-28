using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using GiGraph.Dot.Writers.EdgeWriters;
using System.Linq;

namespace GiGraph.Dot.Generators.EdgeGenerators
{
    public class DotCommonEdgeCollectionGenerator : DotEntityGenerator<DotCommonEdgeCollection, IDotEdgeStatementWriter>
    {
        protected DotCommonEdgeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotCommonEdgeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonEdgeCollection edges, IDotEdgeStatementWriter writer)
        {
            // TODO: improve sorting to include node names
            var orderedEdges = _options.OrderElements
                ? edges.OrderBy(edge => edge.GetType().FullName)
                       .Cast<DotCommonEdge>()
                : edges;

            foreach (var edge in orderedEdges.Where(edge => edge.Endpoints.Any()))
            {
                WriteEdge(edge, writer);
            }
        }

        protected virtual void WriteEdge(DotCommonEdge edge, IDotEdgeStatementWriter writer)
        {
            var edgeWriter = writer.BeginSequence();
            _entityGenerators.GetForEntity<IDotEdgeWriter>(edge).Generate(edge, edgeWriter);
            writer.EndSequence();
        }
    }
}
