using System.Drawing;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes;

/// <summary>
///     Represents a single color.
/// </summary>
public record DotColorAttribute : DotAttribute<Color>
{
    /// <summary>
    ///     Creates a new color attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute, for example "color", "bgcolor", or "fillcolor".
    /// </param>
    /// <param name="color">
    ///     The value of the attribute as a color.
    /// </param>
    public DotColorAttribute(string key, Color color)
        : base(key, color)
    {
    }

    protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        return ((IDotEncodable) new DotColor(Value)).GetDotEncodedValue(options, syntaxRules);
    }
}