namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes
{
    public interface IDotEdgeEndpointRootAttributes : IDotEdgeEndpointAttributes
    {
        /// <summary>
        ///     Hyperlink attributes of the endpoint of the edge. If defined, the hyperlink is output as part of the endpoint's
        ///     <see cref="IDotEdgeEndpointAttributes.Label" />. Also, this value is used near the endpoint, overriding hyperlink attributes
        ///     set on the edge.
        /// </summary>
        DotEdgeEndpointHyperlinkAttributes Hyperlink { get; }
    }
}