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
            var orderedEdges = _options.OrderElements
                ? edges.Where(edge => edge.Endpoints.Any())
                       .OrderBy(edge => edge.GetType().FullName)
                       .Cast<DotCommonEdge>()
                : edges;

            foreach (var edge in orderedEdges)
            {
                WriteEdge(edge, writer);
            }
        }

        protected virtual void WriteEdge(DotCommonEdge edge, IDotEdgeStatementWriter writer)
        {
            var edgeWriter = writer.BeginEdgeChain();
            _entityGenerators.GetForEntity<IDotEdgeWriter>(edge).Generate(edge, edgeWriter);
            writer.EndEdgeChain();
        }
    }
}
