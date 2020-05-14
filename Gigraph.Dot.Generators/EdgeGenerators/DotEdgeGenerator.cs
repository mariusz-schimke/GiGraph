using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.EdgeWriters;

namespace Gigraph.Dot.Generators.EdgeGenerators
{
    public class DotEdgeGenerator : DotEntityWithAttributeListGenerator<DotEdge, IDotEdgeWriter>
    {
        public DotEdgeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotEdge edge, IDotEdgeWriter writer)
        {
            WriteEdge(edge.LeftNodeId, edge.RightNodeId, writer);
            WriteAttributes(edge.Attributes, writer);
        }

        protected virtual void WriteEdge(string leftNodeId, string rightNodeId, IDotEdgeWriter writer)
        {
            leftNodeId = EscapeIdentifier(leftNodeId);
            rightNodeId = EscapeIdentifier(rightNodeId);

            writer.WriteEdge
            (
                leftNodeId,
                IdentifierRequiresQuoting(leftNodeId),
                rightNodeId,
                IdentifierRequiresQuoting(rightNodeId)
            );
        }
    }
}
