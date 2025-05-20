using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Qualities;

/// <summary>
///     Indicates that the implementation has a hyperlink with a tooltip.
/// </summary>
public interface IDotHasHyperlinkWithTooltip : IDotHasHyperlink
{
    DotEscapeString? Tooltip { get; set; }
}