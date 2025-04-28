using GiGraph.Dot.Types.EnumHelpers;

namespace GiGraph.Dot.Types.Alignment;

/// <summary>
///     Alignment attributes.
/// </summary>
public record DotAlignmentProperties()
{
    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    /// <param name="horizontal">
    ///     The horizontal alignment to set.
    /// </param>
    /// <param name="vertical">
    ///     The vertical alignment to set.
    /// </param>
    public DotAlignmentProperties(DotHorizontalAlignment? horizontal, DotVerticalAlignment? vertical)
        : this()
    {
        Horizontal = horizontal;
        Vertical = vertical;
    }

    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public DotAlignmentProperties(DotAlignment alignment)
        : this(
            DotPartialEnumMapper.ExtractPartialFlags<DotHorizontalAlignment, DotAlignment>(alignment),
            DotPartialEnumMapper.ExtractPartialFlags<DotVerticalAlignment, DotAlignment>(alignment)
        )
    {
    }

    /// <summary>
    ///     Horizontal alignment.
    /// </summary>
    public DotHorizontalAlignment? Horizontal { get; init; }

    /// <summary>
    ///     Vertical alignment.
    /// </summary>
    public DotVerticalAlignment? Vertical { get; init; }
}