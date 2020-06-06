using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Converters;
using GiGraph.Dot.Output.Options;
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
            WriteEdges(edge.Endpoints, writer);
            WriteAttributes(edge.Attributes, writer);
        }

        protected virtual void WriteEdges(IEnumerable<DotCommonEndpoint> endpoints, IDotEdgeWriter writer)
        {
            if (endpoints.Count() < 2)
            {
                throw new ArgumentException("At least a pair of endpoints has to be specified for an edge or an edge sequence.", nameof(endpoints));
            }

            foreach (var endpoint in endpoints)
            {
                WriteEndpoint(endpoint, writer);
            }
        }

        protected virtual void WriteEndpoint(DotCommonEndpoint commonEndpoint, IDotEdgeWriter writer)
        {
            switch (commonEndpoint)
            {
                case DotEndpoint endpoint:
                    WriteEndpoint(endpoint, writer);
                    break;

                case DotEndpointGroup endpointGroup:
                    WriteEndpointGroup(endpointGroup, writer);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(commonEndpoint), $"The specified endpoint type '{commonEndpoint.GetType().FullName}' is not supported.");
            }
        }

        protected virtual void WriteEndpoint(DotEndpoint endpoint, IDotEdgeWriter writer)
        {
            var nodeId = EscapeIdentifier(endpoint.NodeId);

            var portName = endpoint.PortName is { }
                ? EscapeIdentifier(endpoint.PortName)
                : null;

            var compassPoint = endpoint.CompassPoint.HasValue
                ? EscapeIdentifier(new DotCompassPointConverter().Convert(endpoint.CompassPoint.Value))
                : null;

            writer.WriteEndpoint
            (
                nodeId,
                IdentifierRequiresQuoting(nodeId),
                portName,
                IdentifierRequiresQuoting(portName),
                compassPoint,
                IdentifierRequiresQuoting(compassPoint)
            );
        }

        protected virtual void WriteEndpointGroup(DotEndpointGroup endpointGroup, IDotEdgeWriter writer)
        {
            var subgraphWriter = writer.BeginSubgraph(_options.Subgraphs.PreferExplicitKeyword);
            _entityGenerators.GetForEntity<IDotSubgraphWriter>(endpointGroup.Subgraph).Generate(endpointGroup.Subgraph, subgraphWriter);
            writer.EndSubgraph();
        }
    }
}
