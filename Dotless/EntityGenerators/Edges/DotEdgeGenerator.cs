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

        public override void Write(DotEdge edge, IDotEdgeWriter writer)
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
            _entityGenerators.GetForEntity<IDotAttributeCollectionWriter>(attributes).Write(attributes, attributesWriter);
            writer.EndAttributeList(attributes.Count());
        }
    }
}
