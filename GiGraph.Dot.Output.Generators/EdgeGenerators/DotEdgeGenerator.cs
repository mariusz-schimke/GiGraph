using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.EdgeWriters;
using GiGraph.Dot.Output.Writers.SubgraphWriters;
using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Output.Generators.EdgeGenerators
{
    public class DotEdgeGenerator : DotEntityWithAttributeListGenerator<DotEdgeDefinition, IDotEdgeWriter>
    {
        protected DotEdgeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, IDotTextEscaper identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotEdgeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotEdgeDefinition edge, IDotEdgeWriter writer)
        {
            WriteEdges(edge.Endpoints, writer);
            WriteAttributes(edge.Attributes, writer);
        }

        protected virtual void WriteEdges(IEnumerable<DotEndpointDefinition> endpoints, IDotEdgeWriter writer)
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

        protected virtual void WriteEndpoint(DotEndpointDefinition endpointDefinition, IDotEdgeWriter writer)
        {
            switch (endpointDefinition)
            {
                case DotEndpoint endpoint:
                    WriteEndpoint(endpoint, writer);
                    break;

                case DotEndpointGroup endpointGroup:
                    WriteEndpointGroup(endpointGroup, writer);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(endpointDefinition), $"The specified endpoint type '{endpointDefinition.GetType().FullName}' is not supported.");
            }
        }

        protected virtual void WriteEndpoint(DotEndpoint endpoint, IDotEdgeWriter writer)
        {
            var nodeId = EscapeIdentifier(endpoint.NodeId);

            var portName = endpoint.Port.Name is { }
                ? EscapeIdentifier(endpoint.Port.Name)
                : null;

            var compassPoint = endpoint.Port.CompassPoint.HasValue
                ? EscapeIdentifier(DotCompassPointConverter.Convert(endpoint.Port.CompassPoint.Value))
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