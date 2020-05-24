using GiGraph.Dot.Entities;
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
            var orderedEdges = edges
                .Cast<IDotEntityWithIds>()
                .Where(e => e.Ids.Any())
                .OrderBy(e => string.Join(" ", e.Ids))
                .ToArray();

            foreach (var edge in orderedEdges)
            {
                var edgeWriter = writer.BeginEdgeChain();
                _entityGenerators.GetForEntity<IDotEdgeWriter>(edge).Generate(edge, edgeWriter);
                writer.EndEdgeChain();
            }
        }
    }
}
