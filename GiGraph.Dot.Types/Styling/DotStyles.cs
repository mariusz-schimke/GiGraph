using System;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Types.Styling
{
    /// <summary>
    ///     The styles of an element.
    /// </summary>
    [Flags]
    public enum DotStyles
    {
        /// <summary>
        ///     Indicates that the normal default style should be assigned to the current element. This setting can be used in order to
        ///     restore the style of the element to the default value when a custom style has been set globally for this type of element on a
        ///     graph or a subgraph, using global edge attributes or global node attributes.
        /// </summary>
        [DotAttributeValue(null)]
        Default = 0,

        /// <summary>
        ///     Applicable to nodes, edges, and clusters.
        /// </summary>
        [DotAttributeValue("solid")]
        Solid = 1 << 0,

        /// <summary>
        ///     Applicable to nodes, edges, and clusters.
        /// </summary>
        [DotAttributeValue("dashed")]
        Dashed = 1 << 1,

        /// <summary>
        ///     Applicable to nodes, edges, and clusters.
        /// </summary>
        [DotAttributeValue("dotted")]
        Dotted = 1 << 2,

        /// <summary>
        ///     Applicable to nodes, edges, and clusters.
        /// </summary>
        [DotAttributeValue("bold")]
        Bold = 1 << 3,

        /// <summary>
        ///     Applicable to nodes and clusters.
        /// </summary>
        [DotAttributeValue("rounded")]
        Rounded = 1 << 4,

        /// <summary>
        ///     Applicable to nodes.
        /// </summary>
        [DotAttributeValue("diagonals")]
        Diagonals = 1 << 5,

        /// <summary>
        ///     Applicable to nodes and clusters.
        /// </summary>
        [DotAttributeValue("filled")]
        Filled = 1 << 6,

        /// <summary>
        ///     Applicable to clusters and rectangularly-shaped nodes. Causes the fill to be done as a set of vertical stripes. The colors
        ///     are specified via a color list (see <see cref="DotMultiColor" />), and drawn from left to right in list order. Optional color
        ///     weights can be specified to indicate the proportional widths of the bars. If the sum of the weights is less than 1, the
        ///     remainder is divided evenly among the colors with no weight.
        /// </summary>
        [DotAttributeValue("striped")]
        Striped = 1 << 7,

        /// <summary>
        ///     Applicable to elliptically-shaped nodes. Causes the fill to be done as a set of wedges. The colors are specified via a color
        ///     list (see <see cref="DotMultiColor" />), with the colors drawn counter-clockwise starting at angle 0. Optional color weights
        ///     can be specified to indicate the proportional widths of the bars. If the sum of the weights is less than 1, the remainder is
        ///     divided evenly among the colors with no weight.
        /// </summary>
        [DotAttributeValue("wedged")]
        Wedged = 1 << 8,

        /// <summary>
        ///     Applicable to nodes, clusters, and graphs. Indicates a radial-style gradient fill when colors are specified via a color list
        ///     (see <see cref="DotGradientColor" />).
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
        ///         determines whether the tapering goes from tail to head (<see cref="DotEdgeDirections.Forward" /> ), from head to tail (
        ///         <see cref="DotEdgeDirections.Backward" />), from the middle to both the head and tail (
        ///         <see cref="DotEdgeDirections.Both" />), or no tapering at all (<see cref="DotEdgeDirections.None" />). If the attribute
        ///         is not explicitly set, the default for the graph type is used.
        ///     </para>
        ///     <para>
        ///         Arrowheads and arrow tails are also drawn based on the value of the directions attribute. To avoid this, set the
        ///         arrowhead attribute for the head or the tail to <see cref="DotArrowheadShape.None" />.
        ///     </para>
        /// </summary>
        [DotAttributeValue("tapered")]
        Tapered = 1 << 10,

        /// <summary>
        ///     Applicable to nodes, edges, and clusters.
        /// </summary>
        [DotAttributeValue("invis")]
        Invisible = 1 << 11
    }
}