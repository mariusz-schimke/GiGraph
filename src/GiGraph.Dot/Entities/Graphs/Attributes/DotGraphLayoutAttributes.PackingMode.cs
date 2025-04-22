using GiGraph.Dot.Types.Packing;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphLayoutAttributes
{
    /// <summary>
    ///     <para>
    ///         Sets array packing mode parameters. Indicates that the components should be packed at the graph level into an array of
    ///         graphs. By default, the components are in row-major order, with the number of columns roughly the square root of the
    ///         number of components.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="PackingMode"/> property directly, using <see cref="DotArrayPackingMode"/>.
    ///     </para>
    /// </summary>
    /// <param name="options">
    ///     The packing option flags to set. Multiple options can be provided.
    /// </param>
    /// <param name="rankCount">
    ///     Specifies the number of columns for row-major component ordering or the number of rows for column-major component ordering.
    /// </param>
    /// <remarks>
    ///     Only granularity-based or array packing mode can be set at once.
    /// </remarks>
    public void SetArrayPackingMode(DotArrayPackingOptions? options = null, int? rankCount = null)
    {
        PackingMode = new DotArrayPackingMode(options, rankCount);
    }

    /// <summary>
    ///     <para>
    ///         Sets array packing mode parameters. Indicates that the components should be packed at the graph level into an array of
    ///         graphs. By default, the components are in row-major order, with the number of columns roughly the square root of the
    ///         number of components.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="PackingMode"/> property directly, using <see cref="DotArrayPackingMode"/>.
    ///     </para>
    /// </summary>
    /// <param name="rankCount">
    ///     Specifies the number of columns for row-major component ordering or the number of rows for column-major component ordering.
    /// </param>
    /// <remarks>
    ///     Only granularity-based or array packing mode can be set at once.
    /// </remarks>
    public void SetArrayPackingMode(int rankCount)
    {
        PackingMode = new DotArrayPackingMode(rankCount);
    }

    /// <summary>
    ///     <para>
    ///         Sets packing mode based on the specified granularity option. Indicates that components should be packed together tightly,
    ///         using the specified granularity.
    ///     </para>
    ///     <para>
    ///         It is equivalent to setting the <see cref="PackingMode"/> property directly, using
    ///         <see cref="DotGranularityPackingMode"/>.
    ///     </para>
    /// </summary>
    /// <param name="granularity">
    ///     The granularity option.
    /// </param>
    /// <remarks>
    ///     Only granularity-based or array packing mode can be set at once.
    /// </remarks>
    public void SetGranularityPackingMode(DotPackingGranularity granularity)
    {
        PackingMode = new DotGranularityPackingMode(granularity);
    }
}