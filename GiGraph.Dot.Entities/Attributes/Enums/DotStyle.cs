using System;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     The styles of an element.
    /// </summary>
    [Flags]
    public enum DotStyle
    {
        /// <summary>
        ///     Indicates that the normal default style should be assigned to the current element. This setting can be used in order to
        ///     restore the style of the element to the normal default value when a custom default style has been set for this type of
        ///     element on a graph or a subgraph level, using <see cref="DotCommonGraph{TAttributes}.EdgeDefaults" /> or
        ///     <see cref="DotCommonGraph{TAttributes}.NodeDefaults" />.
        /// </summary>
        Default = 0,

        /// <summary>
        ///     Applicable to nodes, edges, and clusters.
        /// </summary>
        Solid = 1 << 0,

        /// <summary>
        ///     Applicable to nodes, edges, and clusters.
        /// </summary>
        Dashed = 1 << 1,

        /// <summary>
        ///     Applicable to nodes, edges, and clusters.
        /// </summary>
        Dotted = 1 << 2,

        /// <summary>
        ///     Applicable to nodes, edges, and clusters.
        /// </summary>
        Bold = 1 << 3,

        /// <summary>
        ///     Applicable to nodes and clusters.
        /// </summary>
        Rounded = 1 << 4,

        /// <summary>
        ///     Applicable to nodes.
        /// </summary>
        Diagonals = 1 << 5,

        /// <summary>
        ///     Applicable to nodes and clusters.
        /// </summary>
        Filled = 1 << 6,

        /// <summary>
        ///     Applicable to clusters and rectangularly-shaped nodes. Causes the fill to be done as a set of vertical stripes. The colors
        ///     are specified via a color list (see <see cref="DotMultiColor" />), and drawn from left to right in list order. Optional color
        ///     weights can be specified to indicate the proportional widths of the bars. If the sum of the weights is less than 1, the
        ///     remainder is divided evenly among the colors with no weight.
        /// </summary>
        Striped = 1 << 7,

        /// <summary>
        ///     Applicable to elliptically-shaped nodes. Causes the fill to be done as a set of wedges. The colors are specified via a color
        ///     list (see <see cref="DotMultiColor" />), with the colors drawn counter-clockwise starting at angle 0. Optional color weights
        ///     can be specified to indicate the proportional widths of the bars. If the sum of the weights is less than 1, the remainder is
        ///     divided evenly among the colors with no weight.
        /// </summary>
        Wedged = 1 << 8,

        /// <summary>
        ///     Applicable to nodes, clusters, and graphs. Indicates a radial-style gradient fill when colors are specified via a color list
        ///     (see <see cref="DotMultiColor" />).
        /// </summary>
        Radial = 1 << 9,

        /// <summary>
        ///     Applicable to edges. The effect depends on the <see cref="IDotEdgeAttributes.PenWidth" />,
        ///     <see cref="IDotEdgeAttributes.ArrowDirection" />, <see cref="IDotEdgeAttributes.ArrowHead" />, and
        ///     <see cref="IDotEdgeAttributes.ArrowTail" /> attributes. The edge starts with width <see cref="IDotEdgeAttributes.PenWidth" />
        ///     , and tapers to width 1, in points. The <see cref="IDotEdgeAttributes.ArrowDirection" /> attribute determines whether the
        ///     tapering goes from tail to head (<see cref="IDotEdgeAttributes.ArrowDirection" /> = <see cref="DotArrowDirection.Forward" />
        ///     ), from head to tail (<see cref="IDotEdgeAttributes.ArrowDirection" /> = <see cref="DotArrowDirection.Backward" />), from the
        ///     middle to both the head and tail (<see cref="IDotEdgeAttributes.ArrowDirection" /> = <see cref="DotArrowDirection.Both" />),
        ///     or no tapering at all (<see cref="IDotEdgeAttributes.ArrowDirection" /> = <see cref="DotArrowDirection.None" />). If the
        ///     <see cref="IDotEdgeAttributes.ArrowDirection" /> attribute is not explicitly set, the default for the graph type is used.
        ///     Arrow heads and arrow tails are also drawn, based on the value of <see cref="IDotEdgeAttributes.ArrowDirection" /> attribute;
        ///     to avoid this, set the <see cref="IDotEdgeAttributes.ArrowHead" /> and/or <see cref="IDotEdgeAttributes.ArrowTail" />
        ///     attributes to <see cref="DotArrowheadShape.None" />.
        /// </summary>
        Tapered = 1 << 10,

        /// <summary>
        ///     Applicable to nodes and edges.
        /// </summary>
        Invisible = 1 << 11
    }
}