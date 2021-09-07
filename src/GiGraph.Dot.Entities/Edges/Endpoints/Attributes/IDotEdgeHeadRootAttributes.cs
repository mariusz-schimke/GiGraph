namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes
{
    public interface IDotEdgeHeadRootAttributes : IDotEdgeEndpointAttributes
    {
        /// <summary>
        ///     Hyperlink attributes of the head of the edge. If defined, the hyperlink is output as part of the head's
        ///     <see cref="IDotEdgeEndpointAttributes.Label" />. Also, this value is used near the head, overriding hyperlink attributes set
        ///     on the edge.
        /// </summary>
        DotEdgeHeadHyperlinkAttributes Hyperlink { get; }
    }
}