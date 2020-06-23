using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Entities.Tests
{
    public class AttributesTest
    {
        private DotGenerationOptions _generationOptions = new DotGenerationOptions();
        private DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        [Fact]
        public void string_attribute_returns_the_exact_same_encoded_value_as_attribute_value()
        {
            var value = "a bcd \" \\ \r\n \r \n h ij < > { } |";
            IDotEncodable attr = new DotStringAttribute("key", value);

            Assert.Equal(value, attr.GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void escape_string_attribute_returns_escaped_encoded_value()
        {
            var value = "a bcd \" \\ \r\n \r \n h ij < > { } |";
            IDotEncodable attr = new DotEscapeStringAttribute("key", value);

            Assert.Equal(@"a bcd \"" \\ \n \n \n h ij < > { } |", attr.GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void label_attribute_returns_escaped_encoded_value_for_string_input()
        {
            var value = "a bcd \" \\ \r\n \r \n h ij < > { } |";
            IDotEncodable attr = new DotLabelAttribute("key", value);

            Assert.Equal(@"a bcd \"" \\ \n \n \n h ij < > { } |", attr.GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void double_attribute_returns_invariant_culture_encoded_value()
        {
            var value = 10.23455;
            IDotEncodable attr = new DotDoubleAttribute("key", value);

            Assert.Equal("10.23455", attr.GetDotEncodedValue(_generationOptions, _syntaxRules));
        }
    }
}