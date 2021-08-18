namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public interface IDotEdgeTailRootAttributes : IDotEdgeEndpointAttributes
    {
        /// <summary>
        ///     Hyperlink properties of the tail of the edge. If defined, the hyperlink is output as part of the tail's
        ///     <see cref="IDotEdgeEndpointAttributes.Label" />. Also, this value is used near the tail, overriding hyperlink properties set
        ///     on the edge.
        /// </summary>
        DotEdgeTailHyperlinkAttributes Hyperlink { get; }
    }
}