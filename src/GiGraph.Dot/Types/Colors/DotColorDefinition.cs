using System.Drawing;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Colors;

/// <summary>
///     Represents a color definition as a single color (<see cref="DotColor" />), as a gradient (<see cref="DotMulticolor" />) or as
///     multiple colors (<see cref="DotMulticolor" />).
/// </summary>
public abstract record DotColorDefinition : IDotEncodable
{
    string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncodedColor(options, syntaxRules);

    protected internal abstract string GetDotEncodedColor(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

    public static implicit operator DotColorDefinition(Color? color) => color.HasValue ? new DotColor(color.Value) : null;

    public static implicit operator DotColorDefinition(Color[] colors) => colors is not null ? new DotMulticolor(colors) : null;

    public static implicit operator DotColorDefinition(DotColor[] colors) => colors is not null ? new DotMulticolor(colors) : null;
}