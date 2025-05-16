using GiGraph.Dot.Types.EnumHelpers;

namespace GiGraph.Dot.Types.Alignment;

/// <summary>
///     Alignment attributes.
/// </summary>
/// <param name="Horizontal">
///     The horizontal alignment to set.
/// </param>
/// <param name="Vertical">
///     The vertical alignment to set.
/// </param>
public record DotAlignmentOptions(DotHorizontalAlignment? Horizontal = null, DotVerticalAlignment? Vertical = null)
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