using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The alignment attributes of an HTML table cell (&lt;td&gt;).
/// </summary>
public interface IDotHtmlTableCellAlignmentAttributes : IDotHtmlTableTableCellCommonAlignmentAttributes
{
    /// <summary>
    ///     Specifies horizontal placement. When an object is allocated more space than required, this value determines where the extra
    ///     space is placed left and right of the object. Default: <see cref="DotHorizontalAlignment.Center"/>.
    /// </summary>
    DotHtmlTableCellHorizontalAlignment? Horizontal { get; set; }
}