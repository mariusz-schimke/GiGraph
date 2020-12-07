using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Edges;
using GiGraph.Dot.Output.Writers.Subgraphs;

namespace GiGraph.Dot.Output.Generators.Edges
{
    public class DotEdgeGenerator : DotEntityWithAttributeListGenerator<DotEdgeDefinition, IDotEdgeWriter>
    {
        public DotEdgeGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteEntity(DotEdgeDefinition edge, IDotEdgeWriter writer)
        {
            WriteEdges(edge.Endpoints, writer);
            WriteAttributes(edge.Attributes.Collection, writer);
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
                writer.WriteEdge();
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

                case DotSubgraphEndpoint subgraph:
                    WriteSubgraph(subgraph, writer);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(endpointDefinition), $"The specified endpoint type '{endpointDefinition.GetType().FullName}' is not supported.");
            }
        }

        protected virtual void WriteEndpoint(DotEndpoint endpoint, IDotEdgeWriter writer)
        {
            var endpointWriter = writer.BeginEndpoint();
            _entityGenerators.GetForEntity<IDotEndpointWriter>(endpoint).Generate(endpoint, endpointWriter);
            writer.EndEndpoint();
        }

        protected virtual void WriteEndpointGroup(DotEndpointGroup endpointGroup, IDotEdgeWriter writer)
        {
            var endpointGroupWriter = writer.BeginEndpointGroup();
            _entityGenerators.GetForEntity<IDotEndpointGroupWriter>(endpointGroup).Generate(endpointGroup, endpointGroupWriter);
            writer.EndEndpointGroup();
        }

        protected virtual void WriteSubgraph(DotSubgraphEndpoint endpoint, IDotEdgeWriter writer)
        {
            var subgraphWriter = writer.BeginSubgraph(_options.Edges.PreferExplicitSubgraphDeclaration);
            _entityGenerators.GetForEntity<IDotSubgraphWriter>(endpoint.Subgraph).Generate(endpoint.Subgraph, subgraphWriter);
            writer.EndSubgraph();
        }
    }
}