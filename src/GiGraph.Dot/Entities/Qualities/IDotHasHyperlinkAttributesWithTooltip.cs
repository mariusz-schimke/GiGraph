using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Qualities;

/// <summary>
///     Indicates that the implementation has hyperlink attributes that include a tooltip.
/// </summary>
public interface IDotHasHyperlinkAttributesWithTooltip : IDotHasHyperlinkAttributes
{
    DotEscapeString? Tooltip { get; set; }
}