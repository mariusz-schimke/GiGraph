using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using GiGraph.Dot.Writers.EdgeWriters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Generators.EdgeGenerators
{
    public class DotCommonEdgeGenerator : DotEntityWithAttributeListGenerator<DotCommonEdge, IDotEdgeWriter>
    {
        protected DotCommonEdgeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotCommonEdgeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonEdge edge, IDotEdgeWriter writer)
        {
            WriteEdges(((IDotEntityWithIds)edge).Ids.ToArray(), writer);
            WriteAttributes(edge.Attributes, writer);
        }

        protected virtual void WriteEdges(ICollection<string> nodeIds, IDotEdgeWriter writer)
        {
            if (nodeIds.Count < 2)
            {
                throw new ArgumentException("At least a pair of node identifiers has to be specified for an edge.", nameof(nodeIds));
            }

            foreach (var nodeId in nodeIds)
            {
                WriteNodeId(nodeId, writer);
                writer.WriteEdge();
            }
        }

        protected virtual void WriteNodeId(string nodeId, IDotEdgeWriter writer)
        {
            nodeId = EscapeIdentifier(nodeId);

            writer.WriteNodeId
            (
                nodeId,
                IdentifierRequiresQuoting(nodeId)
            );
        }
    }
}
