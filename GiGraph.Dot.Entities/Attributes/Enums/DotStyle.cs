using GiGraph.Dot.Entities.Graphs;
using System;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    /// The styles of an element.
    /// </summary>
    [Flags]
    public enum DotStyle
    {
        /// <summary>
        /// Indicates that the normal default style should be assigned to the current element.
        /// This setting can be used in order to restore the style of the element to the normal default value
        /// when a custom default style has been set for this type of element on a graph or a subgraph level,
        /// using <see cref="DotCommonGraph.EdgeDefaults"/> or <see cref="DotCommonGraph.NodeDefaults"/>.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Applicable to nodes, edges, and clusters.
        /// </summary>
        Solid = 1 << 0,

        /// <summary>
        /// Applicable to nodes, edges, and clusters.
        /// </summary>
        Dashed = 1 << 1,

        /// <summary>
        /// Applicable to nodes, edges, and clusters.
        /// </summary>
        Dotted = 1 << 2,

        /// <summary>
        /// Applicable to nodes, edges, and clusters.
        /// </summary>
        Bold = 1 << 3,

        /// <summary>
        /// Applicable to nodes and clusters.
        /// </summary>
        Rounded = 1 << 4,

        /// <summary>
        /// Applicable to nodes.
        /// </summary>
        Diagonals = 1 << 5,

        /// <summary>
        /// Applicable to nodes and clusters.
        /// </summary>
        Filled = 1 << 6,

        /// <summary>
        /// Applicable to clusters and rectangularly-shaped nodes.
        /// Causes the fill to be done as a set of vertical stripes.
        /// The colors are specified via a color list, and drawn from left to right in list order. 
        /// Optional color weights can be specified to indicate the proportional widths of the bars.
        /// If the sum of the weights is less than 1, the remainder is divided evenly among the colors with no weight.
        /// </summary>
        Striped = 1 << 7,

        /// <summary>
        /// Applicable to elliptically-shaped nodes.
        /// Causes the fill to be done as a set of wedges. The colors are specified via a color list, 
        /// with the colors drawn counter-clockwise starting at angle 0.
        /// Optional color weights can be specified to indicate the proportional widths of the bars.
        /// If the sum of the weights is less than 1, the remainder is divided evenly among the colors with no weight.
        /// </summary>
        Wedged = 1 << 8,

        /// <summary>
        /// Applicable to nodes, clusters and graphs. Indicates a radial-style gradient fill
        /// when colors are specified via a color list.
        /// </summary>
        Radial = 1 << 9,

        /// <summary>
        /// Applicable to edges.
        /// </summary>
        Tapered = 1 << 10,

        /// <summary>
        /// Applicable to nodes and edges.
        /// </summary>
        Invisible = 1 << 11
    }
}
