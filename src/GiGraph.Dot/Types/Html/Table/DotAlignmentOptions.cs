using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.EnumHelpers;

namespace GiGraph.Dot.Types.Html.Table;

/// <summary>
///     The alignment attributes of an HTML table cell.
/// </summary>
/// <param name="Horizontal">
///     The horizontal alignment to set.
/// </param>
/// <param name="Vertical">
///     The vertical alignment to set.
/// </param>
public record DotHtmlTableCellAlignmentOptions(DotHtmlTableCellHorizontalAlignment? Horizontal = null, DotVerticalAlignment? Vertical = null) :
    DotAlignmentOptions<DotHtmlTableCellHorizontalAlignment, DotVerticalAlignment>(Horizontal, Vertical)
{
    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public DotHtmlTableCellAlignmentOptions(DotAlignment alignment)
        : this(
            DotPartialEnumMapper.ExtractPartialFlags<DotHtmlTableCellHorizontalAlignment, DotAlignment>(alignment),
            DotPartialEnumMapper.ExtractPartialFlags<DotVerticalAlignment, DotAlignment>(alignment)
        )
    {
    }
}