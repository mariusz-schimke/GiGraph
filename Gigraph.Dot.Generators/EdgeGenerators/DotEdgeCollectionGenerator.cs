using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.EdgeWriters;
using System.Linq;

namespace Gigraph.Dot.Generators.EdgeGenerators
{
    public class DotEdgeCollectionGenerator : DotEntityGenerator<DotEdgeCollection, IDotEdgeStatementWriter>
    {
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
