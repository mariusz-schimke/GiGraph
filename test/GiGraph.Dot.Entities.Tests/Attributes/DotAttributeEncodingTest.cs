using System.Globalization;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes;

public class DotAttributeEncodingTest
{
    private readonly DotSyntaxOptions _syntaxOptions = new();
    private readonly DotSyntaxRules _syntaxRules = new();

    [Fact]
    public void double_attribute_returns_invariant_culture_encoded_value()
    {
        const double value = 10.23455;
        IDotEncodable attr = new DotDoubleAttribute("key", value);

        Thread.CurrentThread.CurrentCulture = new CultureInfo("PL");
        Assert.Equal("0,5", 0.5.ToString(Thread.CurrentThread.CurrentCulture));

        Assert.Equal("10.23455", attr.GetDotEncodedValue(_syntaxOptions, _syntaxRules));
    }

    [Fact]
    public void double_list_attribute_returns_invariant_culture_encoded_value()
    {
        var values = new[] { 10.23455, 0.5, 1.345 };
        IDotEncodable attr = new DotDoubleArrayAttribute("key", values);

        Thread.CurrentThread.CurrentCulture = new CultureInfo("PL");
        Assert.Equal("0,5", 0.5.ToString(Thread.CurrentThread.CurrentCulture));

        Assert.Equal("10.23455:0.5:1.345", attr.GetDotEncodedValue(_syntaxOptions, _syntaxRules));
    }

    [Fact]
    public void escape_string_attribute_returns_escaped_encoded_value()
    {
        const string value = "a bcd \" \\ \r\n \r \n h ij < > { } |";
        IDotEncodable attr = new DotEscapeStringAttribute("key", value);

        Assert.Equal(@"a bcd \"" \\ \n \n \n h ij < > { } |", attr.GetDotEncodedValue(_syntaxOptions, _syntaxRules));
    }

    [Fact]
    public void label_attribute_returns_escaped_encoded_value_for_string_input()
    {
        const string value = "a bcd \" \\ \r\n \r \n h ij < > { } |";
        IDotEncodable attr = new DotComplexTypeAttribute<DotLabel>("key", value);

        Assert.Equal(@"a bcd \"" \\ \n \n \n h ij < > { } |", attr.GetDotEncodedValue(_syntaxOptions, _syntaxRules));
    }

    [Fact]
    public void raw_attribute_returns_the_exact_same_encoded_value_as_attribute_value()
    {
        const string value = "a bcd \" \\ \r\n \r \n h ij < > { } |";
        IDotEncodable attr = new DotRawAttribute("key", value);

        Assert.Equal(value, attr.GetDotEncodedValue(_syntaxOptions, _syntaxRules));
    }
}