using System;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html;
using Xunit;

namespace GiGraph.Dot.Types.Tests.Html;

public class DotHtmlStringTest
{
    [Fact]
    public void throws_exception_on_constructor_null_value()
    {
        Assert.Throws<ArgumentNullException>(() => new DotHtmlString(null!));
    }

    [Fact]
    public void implicit_conversion_returns_null_for_null()
    {
        DotHtmlString? htmlStringValue = (string?) null;
        Assert.Null(htmlStringValue);

        string? stringValue = htmlStringValue;
        Assert.Null(stringValue);
    }

    [Fact]
    public void implicit_conversion_returns_original_string()
    {
        const string value = "<table></table>";
        DotHtmlString htmlStringValue = value;

        string stringValue = htmlStringValue;
        Assert.Equal(value, stringValue);

        DotEscapeString escStringValue = htmlStringValue;
        Assert.IsType<DotUnescapedString>(escStringValue);
        Assert.Equal(value, escStringValue.ToString());
    }

    [Fact]
    public void to_string_returns_original_value()
    {
        const string value = "<table></table>";
        DotHtmlString htmlStringValue = value;
        Assert.Equal(value, htmlStringValue.ToString());
    }

    [Fact]
    public void concatenation_returns_concatenated_html_string()
    {
        DotHtmlString value1 = "value1";
        DotHtmlString value2 = "value2";

        var result = value1 + value2;
        Assert.Equal("value1value2", result);

        result = value1 + null;
        Assert.Equal("value1", result);

        result = null + value2;
        Assert.Equal("value2", result);
    }

    [Fact]
    public void concatenation_works_for_string_and_html_string()
    {
        DotHtmlString value1 = "value1";
        const string value2 = "value2";

        var result1 = value1 + value2;
        Assert.IsType<DotHtmlString>(result1);

        // the other way round
        var result2 = value2 + value1;
        Assert.IsType<DotHtmlString>(result2);
    }

    [Fact]
    public void concatenation_of_nulls_same_as_for_string()
    {
        DotHtmlString? value1 = null;
        DotHtmlString? value2 = null;

        // null string concatenation returns an empty string instead of null, and the expected behavior below should be analogous

        var result1 = value1 + value2;
        Assert.True(string.IsNullOrEmpty(result1.ToString()));

        string result2 = value1 + value2;
        Assert.True(string.IsNullOrEmpty(result2));
    }
}