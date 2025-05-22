using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Qualities;

/// <summary>
///     Indicates that the implementation has font attributes.
/// </summary>
public interface IDotHasFontAttributes
{
    string? Name { get; set; }
    double? Size { get; set; }
    DotColor? Color { get; set; }
}