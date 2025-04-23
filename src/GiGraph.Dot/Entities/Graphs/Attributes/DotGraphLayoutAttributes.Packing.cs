using GiGraph.Dot.Types.Packing;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphLayoutAttributes
{
    /// <summary>
    ///     <para>
    ///         Determines whether each connected component of the graph should be laid out separately, and then the graphs packed
    ///         together. The granularity and method of packing is influenced by the <see cref="PackingMode"/> attribute.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="Packing"/> property directly, using <see cref="DotPackingEnabled"/> or
    ///         assigning a boolean value directly. For layouts which always do packing, such as twopi, you can only set the margin (see
    ///         <see cref="SetPackingMargin"/>).
    ///     </para>
    /// </summary>
    /// <param name="enabled">
    ///     If true, each connected component of the graph is laid out separately, and then the graphs are packed together. If false, the
    ///     entire graph is laid out together.
    /// </param>
    /// <remarks>
    ///     Packing may be enabled by calling this method or <see cref="SetPackingMargin"/>. Only one of them should be used, as both of
    ///     them write the same graph attribute.
    /// </remarks>
    public void SetPackingEnabled(bool enabled = true)
    {
        Packing = new DotPackingEnabled(enabled);
    }

    /// <summary>
    ///     <para>
    ///         Determines whether each connected component of the graph should be laid out separately, and then the graphs packed
    ///         together. The granularity and method of packing is influenced by the <see cref="PackingMode"/> attribute.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="Packing"/> property directly, using <see cref="DotPackingMargin"/> or
    ///         assigning an integer value directly.
    ///     </para>
    /// </summary>
    /// <param name="margin">
    ///     The size, in points, of a margin around each graph part being packed. Packing is enabled when a non-negative value is
    ///     specified.
    /// </param>
    /// <remarks>
    ///     Packing may be enabled by calling this method or <see cref="SetPackingEnabled"/>. Only one of them should be used, as both of
    ///     them write the same graph attribute.
    /// </remarks>
    public void SetPackingMargin(int margin)
    {
        Packing = new DotPackingMargin(margin);
    }
}