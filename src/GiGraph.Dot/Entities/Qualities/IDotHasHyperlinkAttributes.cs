using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Qualities;

/// <summary>
///     Indicates that the implementation has hyperlink attributes.
/// </summary>
public interface IDotHasHyperlinkAttributes
{
    DotEscapeString? Href { get; set; }
    DotEscapeString? Target { get; set; }
}