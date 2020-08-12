using System;
using GiGraph.Dot.Entities.Attributes.Collections.Cluster;
using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Entities.Attributes.Collections.Node;

namespace GiGraph.Dot.Entities.Types.Packing
{
    /// <summary>
    ///     The flags used for customizing component distribution in the array packing mode.
    /// </summary>
    [Flags]
    public enum DotArrayPackingOption
    {
        /// <summary>
        ///     Components are packed in column-major order. When not specified, they are in row-major order, with the number of columns
        ///     roughly the square root of the number of components.
        /// </summary>
        ColumnMajorOrder = 1 << 0,

        /// <summary>
        ///     Aligns graphs next to the top of the cells they occupy.
        /// </summary>
        AlignTop = 1 << 1,

        /// <summary>
        ///     Aligns graphs next to the bottom of the cells they occupy.
        /// </summary>
        AlignBottom = 1 << 2,

        /// <summary>
        ///     Aligns graphs next to the left side of the cells they occupy.
        /// </summary>
        AlignLeft = 1 << 3,

        /// <summary>
        ///     Aligns graphs next to the right side of the cells they occupy.
        /// </summary>
        AlignRight = 1 << 4,

        /// <summary>
        ///     Causes the insertion order of elements in the array to be determined by user-supplied values. Each component can specify its
        ///     sort value by a non-negative integer using the <see cref="IDotGraphAttributes.SortIndex" /> attribute on the graph, the
        ///     <see cref="IDotClusterAttributes.SortIndex" /> attribute on a cluster or the <see cref="IDotNodeAttributes.SortIndex" />
        ///     attribute on a cluster. Components are inserted in order, starting with the one with the smallest sort value. If no sort
        ///     value is specified, zero is used.
        /// </summary>
        SortByIndex = 1 << 5
    }
}