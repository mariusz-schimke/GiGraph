using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Types.Packing;

/// <summary>
///     The flags used for customizing component distribution in the array packing mode.
/// </summary>
[Flags]
[DotJoinableType(separator: "", order: false)]
public enum DotArrayPackingOptions
{
    /// <summary>
    ///     Components are packed in column-major order. When not specified, they are in row-major order, with the number of columns
    ///     roughly the square root of the number of components.
    /// </summary>
    [DotAttributeValue("c")]
    ColumnMajorOrder = 1 << 0,

    /// <summary>
    ///     Aligns graphs next to the top of the cells they occupy.
    /// </summary>
    [DotAttributeValue("t")]
    AlignTop = 1 << 1,

    /// <summary>
    ///     Aligns graphs next to the right side of the cells they occupy.
    /// </summary>
    [DotAttributeValue("r")]
    AlignRight = 1 << 2,

    /// <summary>
    ///     Aligns graphs next to the bottom of the cells they occupy.
    /// </summary>
    [DotAttributeValue("b")]
    AlignBottom = 1 << 3,

    /// <summary>
    ///     Aligns graphs next to the left side of the cells they occupy.
    /// </summary>
    [DotAttributeValue("l")]
    AlignLeft = 1 << 4,

    /// <summary>
    ///     By default, the insertion order is determined by sorting the graphs by size, largest to smallest. If this flag is specified,
    ///     it causes the insertion order of elements in the array to be determined by user-supplied values. Each component can specify
    ///     its sort value by a non-negative integer using the sort index attribute on a graph, on a cluster, or on a node. Components
    ///     are inserted in order, starting with the one with the smallest sort value. If no sort value is specified, zero is used.
    /// </summary>
    [DotAttributeValue("u")]
    SortByIndex = 1 << 5,

    /// <summary>
    ///     Indicates that no sorting is done, with the graphs inserted in input order. See also <see cref="SortByIndex"/>.
    /// </summary>
    [DotAttributeValue("i")]
    SortByInputOrder = 1 << 6
}