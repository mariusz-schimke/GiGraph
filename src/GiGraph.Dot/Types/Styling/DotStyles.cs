using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Edges.Arrowheads;

namespace GiGraph.Dot.Types.Styling;

/// <summary>
///     The styles of an element.
/// </summary>
[Flags]
[DotJoinableType(separator: ", ")]
public enum DotStyles
{
    /// <summary>
    ///     Indicates that the default style should be assigned to the current element. This setting can be used in order to restore the
    ///     style of the element to the default value when a custom style has been set globally for this type of element on a graph or a
    ///     subgraph, using global edge attributes or global node attributes.
    /// </summary>
    [DotAttributeValue(null)]
    Default = 0,

    /// <summary>
    ///     A solid line style. Applicable to nodes, edges, and clusters.
    /// </summary>
    [DotAttributeValue("solid")]
    Solid = 1 << 0,

    /// <summary>
    ///     A dashed line style. Applicable to nodes, edges, and clusters.
    /// </summary>
    [DotAttributeValue("dashed")]
    Dashed = 1 << 1,

    /// <summary>
    ///     A dotted line style. Applicable to nodes, edges, and clusters.
    /// </summary>
    [DotAttributeValue("dotted")]
    Dotted = 1 << 2,

    /// <summary>
    ///     A bold line style. Applicable to nodes, edges, and clusters.
    /// </summary>
    [DotAttributeValue("bold")]
    Bold = 1 << 3,

    /// <summary>
    ///     Applies rounded corners to the shape. Applicable to nodes and clusters.
    /// </summary>
    [DotAttributeValue("rounded")]
    Rounded = 1 << 4,

    /// <summary>
    ///     Causes small chords to be drawn near the vertices of the node’s polygon or, in case of circles and ellipses, two chords near
    ///     the top and the bottom of the shape. Applicable to nodes.
    /// </summary>
    [DotAttributeValue("diagonals")]
    Diagonals = 1 << 5,

    /// <summary>
    ///     Applies a filled style to the shape. Applicable to nodes and clusters.
    /// </summary>
    [DotAttributeValue("filled")]
    Filled = 1 << 6,

    /// <summary>
    ///     Causes the fill to be done as a set of vertical stripes. The colors are specified via a color list (see
    ///     <see cref="DotMulticolor"/>), and drawn from left to right in list order. Optional color weights can be specified to indicate
    ///     the proportional widths of the bars. If the sum of the weights is less than 1, the remainder is divided evenly among the
    ///     colors with no weight. Applicable to clusters and rectangularly-shaped nodes.
    /// </summary>
    [DotAttributeValue("striped")]
    Striped = 1 << 7,

    /// <summary>
    ///     Causes the fill to be done as a set of wedges. The colors are specified via a color list (see <see cref="DotMulticolor"/>),
    ///     with the colors drawn counter-clockwise starting at angle 0. Optional color weights can be specified to indicate the
    ///     proportional widths of the bars. If the sum of the weights is less than 1, the remainder is divided evenly among the colors
    ///     with no weight. Applicable to elliptically-shaped nodes.
    /// </summary>
    [DotAttributeValue("wedged")]
    Wedged = 1 << 8,

    /// <summary>
    ///     Indicates a radial-style gradient fill when colors are specified via a color list (see <see cref="DotGradientColor"/>).
    ///     Applicable to nodes, clusters, and graphs.
    /// </summary>
    [DotAttributeValue("radial")]
    Radial = 1 << 9,

    /// <summary>
    ///     <para>
    ///         Applicable to edges. The effect depends on the width attribute of an edge, its directions attribute, and the arrowhead
    ///         attributes of its head and tail.
    ///     </para>
    ///     <para>
    ///         The edge starts with the width specified in the attributes, and tapers to width 1, in points. The directions attribute
    ///         determines whether the tapering goes from tail to head (<see cref="DotEdgeDirections.Forward"/> ), from head to tail (
    ///         <see cref="DotEdgeDirections.Backward"/>), from the middle to both the head and tail (
    ///         <see cref="DotEdgeDirections.Both"/>), or no tapering at all (<see cref="DotEdgeDirections.None"/>). If the attribute is
    ///         not explicitly set, the default for the graph type is used.
    ///     </para>
    ///     <para>
    ///         Arrowheads and arrow tails are also drawn based on the value of the directions attribute. To avoid this, set the
    ///         arrowhead attribute for the head or the tail to <see cref="DotArrowheadShape.None"/>.
    ///     </para>
    /// </summary>
    [DotAttributeValue("tapered")]
    Tapered = 1 << 10,

    /// <summary>
    ///     Makes the element invisible. Applicable to nodes, edges, and clusters.
    /// </summary>
    [DotAttributeValue("invis")]
    Invisible = 1 << 11
}