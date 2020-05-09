using Gigraph.Dot.Entities.Attributes;
using Gigraph.Dot.Core;
using Gigraph.Dot.Writers;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Generators.Options;
using System.Linq;

namespace Gigraph.Dot.Generators.Edges
{
    public class DotEdgeGenerator : DotEntityGenerator<DotEdge, IDotEdgeWriter>
    {
        public DotEdgeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
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

        protected virtual void WriteAttributes(DotAttributeCollection attributes, IDotEdgeWriter writer)
        {
            var attributesWriter = writer.BeginAttributeList(_options.Attributes.PreferExplicitSeparator);
            _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(attributes).Generate(attributes, attributesWriter);
            writer.EndAttributeList(attributes.Count());
        }
    }
}
