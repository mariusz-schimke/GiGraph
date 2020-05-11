using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.AttributeWriters;
using Gigraph.Dot.Writers.EdgeWriters;
using System.Linq;

namespace Gigraph.Dot.Generators.EdgeGenerators
{
    public class DotEdgeGenerator : DotEntityGenerator<DotEdge, IDotEdgeWriter>
    {
        public DotEdgeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotEdge edge, IDotEdgeWriter writer)
        {
            WriteEdge(edge, writer);
            WriteAttributes(edge, writer);
        }

        protected virtual void WriteEdge(DotEdge edge, IDotEdgeWriter writer)
        {
            var leftNodeId = EscapeIdentifier(edge.LeftNodeId);
            var rightNodeId = EscapeIdentifier(edge.RightNodeId);

            writer.WriteEdge
            (
                leftNodeId,
                IdentifierRequiresQuoting(leftNodeId),
                rightNodeId,
                IdentifierRequiresQuoting(rightNodeId)
            );
        }

        protected virtual void WriteAttributes(DotEdge edge, IDotEdgeWriter writer)
        {
            var attributesWriter = writer.BeginAttributeList(_options.Attributes.PreferExplicitSeparator);
            _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(edge.Attributes).Generate(edge.Attributes, attributesWriter);
            writer.EndAttributeList(edge.Attributes.Count());
        }
    }
}
