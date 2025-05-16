using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The common attributes of an HTML table (&lt;table&gt;) and an HTML table cell (&lt;td&gt;).
/// </summary>
public interface IDotHtmlTableTableCellCommonAlignmentAttributes
{
    /// <summary>
    ///     Specifies vertical placement. When an object is allocated more space than required, this value determines where the extra
    ///     space is placed above and below the object. Default: <see cref="DotVerticalAlignment.Center"/>.
    /// </summary>
    DotVerticalAlignment? Vertical { get; set; }
}