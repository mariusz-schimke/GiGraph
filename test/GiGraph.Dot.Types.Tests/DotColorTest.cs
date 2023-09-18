using System.Drawing;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.Colors;
using Xunit;

namespace GiGraph.Dot.Types.Tests;

public class DotColorTest
{
    private readonly DotSyntaxOptions _syntaxOptions = new();
    private readonly DotSyntaxRules _syntaxRules = new();

    [Fact]
    public void color_definition_includes_alpha_in_dot_encoded_value_when_less_than_ff()
    {
        DotColorDefinition def = Color.FromArgb(0x0f, Color.Red);

        Assert.Equal("#ff00000f", ((IDotEncodable) def).GetDotEncodedValue(_syntaxOptions, _syntaxRules));
    }

    [Fact]
    public void color_definition_returns_color_name_as_dot_encoded_value_when_specified()
    {
        DotColorDefinition def = Color.Red;

        Assert.Equal("red", ((IDotEncodable) def).GetDotEncodedValue(_syntaxOptions, _syntaxRules));
    }

    [Fact]
    public void color_definition_returns_empty_string_as_dot_encoded_value_when_color_empty_is_used()
    {
        DotColorDefinition def = Color.Empty;

        Assert.Equal(string.Empty, ((IDotEncodable) def).GetDotEncodedValue(_syntaxOptions, _syntaxRules));
    }

    [Fact]
    public void color_definition_returns_hex_color_as_dot_encoded_value_when_name_is_not_specified()
    {
        DotColorDefinition def = Color.FromArgb(0xff, Color.Red);

        Assert.Equal("#ff0000", ((IDotEncodable) def).GetDotEncodedValue(_syntaxOptions, _syntaxRules));
    }

    [Fact]
    public void color_list_includes_colon_separated_colors_in_dot_encoded_value()
    {
        DotColorDefinition def = new DotMulticolor(
            new DotWeightedColor(Color.Blue, 0.8),
            Color.Green);

        Assert.Equal("blue;0.8:green", ((IDotEncodable) def).GetDotEncodedValue(_syntaxOptions, _syntaxRules));
    }

    [Fact]
    public void weighted_color_definition_includes_weight_in_dot_encoded_value()
    {
        DotColorDefinition def = new DotWeightedColor(Color.Blue, 0.8);

        Assert.Equal("blue;0.8", ((IDotEncodable) def).GetDotEncodedValue(_syntaxOptions, _syntaxRules));
    }
}