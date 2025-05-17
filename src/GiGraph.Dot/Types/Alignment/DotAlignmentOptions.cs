using GiGraph.Dot.Types.EnumHelpers;

namespace GiGraph.Dot.Types.Alignment;

/// <summary>
///     Custom alignment attributes.
/// </summary>
/// <param name="Horizontal">
///     The horizontal alignment to set.
/// </param>
/// <param name="Vertical">
///     The vertical alignment to set.
/// </param>
/// <typeparam name="THorizontalAlignment">
///     The horizontal alignment enumeration type.
/// </typeparam>
/// <typeparam name="TVerticalAlignment">
///     The vertical alignment enumeration type.
/// </typeparam>
public record DotAlignmentOptions<THorizontalAlignment, TVerticalAlignment>(THorizontalAlignment? Horizontal = null, TVerticalAlignment? Vertical = null)
    where THorizontalAlignment : struct, Enum
    where TVerticalAlignment : struct, Enum
{
    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public DotAlignmentOptions(DotAlignment alignment)
        : this(
            DotPartialEnumMapper.ExtractPartialFlags<THorizontalAlignment, DotAlignment>(alignment),
            DotPartialEnumMapper.ExtractPartialFlags<TVerticalAlignment, DotAlignment>(alignment)
        )
    {
    }
}

/// <summary>
///     Alignment attributes.
/// </summary>
/// <param name="Horizontal">
///     The horizontal alignment to set.
/// </param>
/// <param name="Vertical">
///     The vertical alignment to set.
/// </param>
public record DotAlignmentOptions(DotHorizontalAlignment? Horizontal = null, DotVerticalAlignment? Vertical = null) :
    DotAlignmentOptions<DotHorizontalAlignment, DotVerticalAlignment>(Horizontal, Vertical)
{
    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public DotAlignmentOptions(DotAlignment alignment)
        : this(
            DotPartialEnumMapper.ExtractPartialFlags<DotHorizontalAlignment, DotAlignment>(alignment),
            DotPartialEnumMapper.ExtractPartialFlags<DotVerticalAlignment, DotAlignment>(alignment)
        )
    {
    }
}