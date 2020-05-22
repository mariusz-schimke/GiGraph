using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
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
            WriteEdge(edge.TailNodeId, edge.HeadNodeId, writer);
            WriteAttributes(edge.Attributes, writer);
        }

        protected virtual void WriteEdge(string tailNodeId, string headNodeId, IDotEdgeWriter writer)
        {
            tailNodeId = EscapeIdentifier(tailNodeId);
            headNodeId = EscapeIdentifier(headNodeId);

            writer.WriteEdge
            (
                tailNodeId,
                IdentifierRequiresQuoting(tailNodeId),
                headNodeId,
                IdentifierRequiresQuoting(headNodeId)
            );
        }
    }
}
