using GiGraph.Dot.Output.Writers.Subgraphs;
using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Edges;

public class DotEdgeWriter : DotEntityWithAttributeListWriter, IDotEdgeWriter
{
    public DotEdgeWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration)
        : base(tokenWriter, configuration, configuration.Formatting.Edges.SingleLineAttributeLists)
    {
    }

    public virtual IDotEndpointWriter BeginEndpoint() => new DotEndpointWriter(_tokenWriter, _configuration);

    public virtual void EndEndpoint()
    {
    }

    public virtual IDotEndpointGroupWriter BeginEndpointGroup() => new DotEndpointGroupWriter(_tokenWriter.SingleLine(), _configuration);

    public virtual void EndEndpointGroup()
    {
        _tokenWriter.ClearLingerBuffer();
    }

    public virtual IDotSubgraphWriter BeginSubgraph(bool preferExplicitDeclaration) =>
        new DotSubgraphWriter(
            _configuration.Formatting.Edges.SingleLineSubgraphs
                ? _tokenWriter.SingleLine()
                : _tokenWriter,
            _configuration,
            preferExplicitDeclaration
        );

    public virtual void EndSubgraph()
    {
        _tokenWriter.ClearLingerBuffer();
    }

    public virtual void WriteEdge()
    {
        // these will be removed by the parent writer if no further endpoints are written
        _tokenWriter.Space(linger: true)
            .Edge(_configuration.IsDirectedGraph, linger: true)
            .Space(linger: true);
    }
}