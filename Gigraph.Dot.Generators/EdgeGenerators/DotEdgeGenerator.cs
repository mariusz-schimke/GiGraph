﻿using Gigraph.Dot.Core;
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
            WriteEdge(edge, writer);
            WriteAttributes(edge.Attributes, writer);
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
    }
}
