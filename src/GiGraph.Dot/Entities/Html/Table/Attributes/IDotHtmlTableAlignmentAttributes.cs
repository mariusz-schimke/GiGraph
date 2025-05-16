using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The alignment attributes of an HTML table (&lt;table&gt;).
/// </summary>
public interface IDotHtmlTableAlignmentAttributes : IDotHtmlTableTableCellCommonAlignmentAttributes
{
    /// <summary>
    ///     Specifies horizontal placement. When an object is allocated more space than required, this value determines where the extra
    ///     space is placed left and right of the object. Default: <see cref="DotHorizontalAlignment.Center"/>.
    /// </summary>
    DotHorizontalAlignment? Horizontal { get; set; }
}