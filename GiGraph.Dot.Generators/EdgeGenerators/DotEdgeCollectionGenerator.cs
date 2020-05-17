using GiGraph.Dot.Core;
using GiGraph.Dot.Core.TextEscaping;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Writers.EdgeWriters;
using System.Linq;

namespace GiGraph.Dot.Generators.EdgeGenerators
{
    public class DotEdgeCollectionGenerator : DotEntityGenerator<DotEdgeCollection, IDotEdgeStatementWriter>
    {
        protected DotEdgeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotEdgeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotEdgeCollection edges, IDotEdgeStatementWriter writer)
        {
            var orderedEdges = edges
                .OrderBy(e => e.LeftNodeId)
                .ThenBy(e => e.RightNodeId)
                .ToList();

            foreach (var edge in orderedEdges)
            {
                var edgeWriter = writer.BeginEdge();
                _entityGenerators.GetForEntity<IDotEdgeWriter>(edge).Generate(edge, edgeWriter);
                writer.EndEdge();
            }
        }
    }
}
