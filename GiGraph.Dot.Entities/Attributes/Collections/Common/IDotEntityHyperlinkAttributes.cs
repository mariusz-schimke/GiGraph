using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public interface IDotEntityHyperlinkAttributes
    {
        /// <summary>
        ///     <para>
        ///         Hyperlinks incorporated into device-dependent output (svg, postscript, map only). At present, used in PS2, CMAP, I*MAP
        ///         and SVG formats. For all these formats, URLs can be attached to nodes, edges and clusters. URL attributes can also be
        ///         attached to the root graph in PS2, CMAP and I*MAP formats. This serves as the base URL for relative URLs in the former,
        ///         and as the default image map file in the latter.
        ///     </para>
        ///     <para>
        ///         The active area for a cluster is its bounding box.
        ///     </para>
        ///     <para>
        ///         For SVG, CMAPX and IMAP output, the active area for a node is its visible image. For example, an unfilled node with no
        ///         drawn boundary will only be active on its label. For other output, the active area is its bounding box.
        ///     </para>
        ///     <para>
        ///         For edges, the active areas are small circles where the edge contacts its head and tail nodes. In addition, for SVG,
        ///         CMAPX and IMAP, the active area includes a thin polygon approximating the edge. The circles may overlap the related node,
        ///         and the edge URL dominates. If the edge has a label, this will also be active. Finally, if the edge has a head or tail
        ///         label, this will also be active.
        ///     </para>
        ///     <para>
        ///         Note that, for edges, the <see cref="DotEdgeHeadHyperlinkAttributes.Url" /> attribute of
        ///         <see cref="DotEdgeAttributes.Head" />, the <see cref="DotEdgeTailHyperlinkAttributes.Url" /> attribute of
        ///         <see cref="DotEdgeAttributes.Tail" />, the <see cref="DotEdgeLabelHyperlinkAttributes.Url" /> attribute of
        ///         <see cref="DotEdgeAttributes.LabelHyperlink" />, and the <see cref="DotEdgeHyperlinkAttributes.Url" /> attribute of
        ///         <see cref="DotEdgeAttributes.EdgeHyperlink" />, allow control of various parts of an edge. Also note that, if active
        ///         areas of two edges overlap, it is unspecified which area dominates.
        ///     </para>
        /// </summary>
        DotEscapeString Url { get; set; }

        /// <summary>
        ///     Synonym for <see cref="Url" /> (svg, postscript, map only).
        /// </summary>
        DotEscapeString Href { get; set; }

        /// <summary>
        ///     If <see cref="Url" /> is specified, this attribute determines which window of the browser is used for the URL (svg, map
        ///     only). See
        ///     <see href="http://www.w3.org/TR/html401/present/frames.html#adef-target">
        ///         W3C documentation
        ///     </see>
        ///     .
        /// </summary>
        DotEscapeString Target { get; set; }
    }
}