using GiGraph.Dot.Core;
using GiGraph.Dot.Core.TextEscaping;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Writers.EdgeWriters;

namespace GiGraph.Dot.Generators.EdgeGenerators
{
    public class DotEdgeGenerator : DotEntityWithAttributeListGenerator<DotEdge, IDotEdgeWriter>
    {
        protected DotEdgeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

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
