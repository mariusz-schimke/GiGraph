using Dotless.Core;
using Dotless.DotWriters;
using Dotless.Edges;
using Dotless.EntityGenerators.Options;
using System.Linq;

namespace Dotless.EntityGenerators.Edges
{
    public class DotEdgeCollectionGenerator : DotEntityGenerator<DotEdgeCollection, IDotEdgeCollectionWriter>
    {
        public DotEdgeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Write(DotEdgeCollection edges, IDotEdgeCollectionWriter writer)
        {
            var orderedEdges = edges
                .OrderBy(e => e.LeftNodeId)
                .ThenBy(e => e.RightNodeId)
                .ToList();

            foreach (var edge in orderedEdges)
            {
                var edgeWriter = writer.BeginEdge();
                _entityGenerators.GetForEntity<IDotEdgeWriter>(edge).Write(edge, edgeWriter);
                writer.EndEdge();
            }
        }
    }
}
