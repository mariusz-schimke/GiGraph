using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Entities.Qualities;

/// <summary>
///     Indicates that the implementation has HTML table borders.
/// </summary>
public interface IDotHasHtmlTableBorders
{
    DotHtmlTableBorders? Borders { get; set; }
}