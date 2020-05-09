using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Writers;
using System.Linq;

namespace Gigraph.Dot.Generators.Edges
{
    public class DotEdgeCollectionGenerator : DotEntityGenerator<DotEdgeCollection, IDotEdgeCollectionWriter>
    {
        public DotEdgeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotEdgeCollection edges, IDotEdgeCollectionWriter writer)
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
