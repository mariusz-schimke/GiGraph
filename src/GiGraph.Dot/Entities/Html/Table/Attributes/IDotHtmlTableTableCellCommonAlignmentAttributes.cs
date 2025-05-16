using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

/// <summary>
///     The common attributes of an HTML table (&lt;table&gt;) and an HTML table cell (&lt;td&gt;).
/// </summary>
/// <typeparam name="THorizontalAlignment">
///     The horizontal alignment enumeration type.
/// </typeparam>
public interface IDotHtmlTableTableCellCommonAlignmentAttributes<THorizontalAlignment>
    where THorizontalAlignment : struct, Enum
{
    /// <summary>
    ///     Specifies horizontal placement. When an object is allocated more space than required, this value determines where the extra
    ///     space is placed left and right of the object. Default: <see cref="DotHorizontalAlignment.Center"/>.
    /// </summary>
    THorizontalAlignment? Horizontal { get; set; }

    /// <summary>
    ///     Specifies vertical placement. When an object is allocated more space than required, this value determines where the extra
    ///     space is placed above and below the object. Default: <see cref="DotVerticalAlignment.Center"/>.
    /// </summary>
    DotVerticalAlignment? Vertical { get; set; }
}