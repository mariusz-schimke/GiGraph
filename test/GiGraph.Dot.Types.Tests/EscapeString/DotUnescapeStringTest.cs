using System;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.EscapeString;
using Xunit;

namespace GiGraph.Dot.Types.Tests.EscapeString;

public class DotUnescapeStringTest
{
    private readonly DotSyntaxRules _syntaxRules = new();

    [Fact]
    public void throws_exception_on_constructor_null_value()
    {
        Assert.Throws<ArgumentNullException>(() => new DotUnescapedString(null!));
    }

    [Fact]
    public void implicit_conversion_returns_null_for_null()
    {
        DotUnescapedString? escStringValue = (string?) null;
        Assert.Null(escStringValue);

        string? stringValue = escStringValue;
        Assert.Null(stringValue);
    }

    [Fact]
    public void to_string_returns_original_value()
    {
        var value = DotEscapeStringTest.SpecialChars;

        var escStringValue = (DotUnescapedString) value;
        Assert.Equal(value, escStringValue.ToString());
    }

    [Fact]
    public void returns_escaped_string_as_dot_encoded_value()
    {
        DotUnescapedString str = $"a bcd {DotEscapeStringTest.SpecialChars} h ij";
        Assert.Equal(
            @"a bcd \"" \\ \n \n \n < > { } | h ij",
            ((IDotEscapable) str).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
    }
}