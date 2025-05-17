using GiGraph.Dot.Entities.Html.LineBreak;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The attributes of an HTML table cell (&lt;td&gt;).
/// </summary>
public interface IDotHtmlTableCellAttributes : IDotHtmlTableTableCellCommonAttributes
{
    /// <summary>
    ///     Specifies the default alignment of &lt;br/&gt; elements contained in the cell (<see cref="DotHtmlLineBreak"/>). That is, if a
    ///     &lt;br/&gt; element has no <see cref="DotHtmlLineBreak.LineAlignment"/> specified explicitly, the alignment indicated by the
    ///     current attribute is applied.
    /// </summary>
    DotHorizontalAlignment? LineAlignment { get; set; }

    /// <summary>
    ///     Specifies the number of columns spanned by the cell. The default is 1, the maximum is 65535.
    /// </summary>
    int? ColumnSpan { get; set; }

    /// <summary>
    ///     Specifies the number of rows spanned by the cell. The default is 1, the maximum is 65535.
    /// </summary>
    int? RowSpan { get; set; }
}