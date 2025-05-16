using GiGraph.Dot.Entities.Html.LineBreak;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The alignment attributes of an HTML table cell (&lt;td&gt;).
/// </summary>
public interface IDotHtmlTableCellAlignmentAttributes
{
    /// <summary>
    ///     Specifies horizontal placement. When an object is allocated more space than required, this value determines where the extra
    ///     space is placed left and right of the object. Default: <see cref="DotHorizontalAlignment.Center"/>.
    /// </summary>
    DotHtmlTableCellHorizontalAlignment? Horizontal { get; set; }

    /// <summary>
    ///     Specifies vertical placement. When an object is allocated more space than required, this value determines where the extra
    ///     space is placed above and below the object. Default: <see cref="DotVerticalAlignment.Center"/>.
    /// </summary>
    DotVerticalAlignment? Vertical { get; set; }

    /// <summary>
    ///     Specifies the default alignment of &lt;br/&gt; elements contained in the cell (<see cref="DotHtmlLineBreak"/>). That is, if a
    ///     &lt;br/&gt; element has no <see cref="DotHtmlLineBreak.LineAlignment"/> specified explicitly, the alignment indicated by the
    ///     current attribute is applied.
    /// </summary>
    DotHorizontalAlignment? Line { get; set; }
}