using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotWriters;
using Dotless.Edges;
using Dotless.EntityGenerators.Options;
using System.Linq;

namespace Dotless.EntityGenerators.Edges
{
    public class DotEdgeGenerator : DotEntityGenerator<DotEdge, IDotEdgeWriter>
    {
        public DotEdgeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, DotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Write(DotEdge node, IDotEdgeWriter writer)
        {
            WriteEdge(node, writer);
            WriteAttributes(node.Attributes, writer);
        }

        protected virtual void WriteEdge(DotEdge edge, IDotEdgeWriter writer)
        {
            var leftNodeId = EscapeIdentifier(edge.LeftNodeId);
            var rightNodeId = EscapeIdentifier(edge.RightNodeId);

            writer.WriteEdge
            (
                // TODO: Fix this!!!
                directed: false,
                leftNodeId,
                IdentifierRequiresQuoting(leftNodeId),
                rightNodeId,
                IdentifierRequiresQuoting(rightNodeId)
            );
        }

        protected virtual void WriteAttributes(DotAttributeCollection attributes, IDotEdgeWriter writer)
        {
            var attributesWriter = writer.BeginAttributeList(_options.Attributes.PreferExplicitSeparator);
            _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(attributes).Write(attributes, attributesWriter);
            writer.EndAttributeList(attributes.Count());
        }
    }
}
