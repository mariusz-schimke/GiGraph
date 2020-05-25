using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Converters;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;
using GiGraph.Dot.Writers.EdgeWriters;
using GiGraph.Dot.Writers.SubgraphWriters;
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
            WriteEdges(edge.Endpoints.ToArray(), writer);
            WriteAttributes(edge.Attributes, writer);
        }

        protected virtual void WriteEdges(ICollection<DotEndpoint> elements, IDotEdgeWriter writer)
        {
            if (elements.Count < 2)
            {
                throw new ArgumentException("At least a pair of elements has to be specified for an edge.", nameof(elements));
            }

            foreach (var element in elements)
            {
                WriteElement(element, writer);
            }
        }

        protected virtual void WriteElement(DotEndpoint element, IDotEdgeWriter writer)
        {
            switch (element)
            {
                case DotNodeEndpoint node:
                    WriteNode(node, writer);
                    break;

                case DotSubgraphEndpoint subgraph:
                    WriteSubgraph(subgraph, writer);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(element), $"The specified edge element type '{element.GetType().FullName}' is not supported.");
            }
        }

        protected virtual void WriteNode(DotNodeEndpoint node, IDotEdgeWriter writer)
        {
            var nodeId = EscapeIdentifier(node.NodeId);

            var portName = node.PortName is { }
                ? EscapeIdentifier(node.PortName)
                : null;

            var compassPoint = node.CompassPoint.HasValue
                ? EscapeIdentifier(new DotCompassPointConverter().Convert(node.CompassPoint.Value))
                : null;

            writer.WriteNode
            (
                nodeId,
                IdentifierRequiresQuoting(nodeId),
                portName,
                IdentifierRequiresQuoting(portName),
                compassPoint,
                IdentifierRequiresQuoting(compassPoint)
            );
        }

        protected virtual void WriteSubgraph(DotSubgraphEndpoint element, IDotEdgeWriter writer)
        {
            var subgraphWriter = writer.BeginSubgraph(_options.Subgraphs.PreferExplicitKeyword);
            _entityGenerators.GetForEntity<IDotSubgraphWriter>(element.Subgraph).Generate(element.Subgraph, subgraphWriter);
            writer.EndSubgraph();
        }
    }
}
