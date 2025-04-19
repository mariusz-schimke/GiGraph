using GiGraph.Dot.Output.Metadata.Html;

namespace GiGraph.Dot.Types.Html.Table;

/// <summary>
///     The style of an HTML table or cell.
/// </summary>
[Flags]
[DotHtmlJoinableType(separator: ", ")]
public enum DotHtmlTableStyles
{
    /// <summary>
    ///     The table will have rounded corners. This probably works best if the outmost cells have no borders, or their cell spacing is
    ///     sufficiently large. If it is desirable to have borders around the cells, use HR and VR elements, or the column and row
    ///     formatting attributes of the table.
    /// </summary>
    [DotHtmlAttributeValue("ROUNDED")]
    Rounded = 1 << 0,

    /// <summary>
    ///     The table will have a radial gradient fill if specified for the table background.
    /// </summary>
    [DotHtmlAttributeValue("RADIAL")]
    Radial = 1 << 1
}