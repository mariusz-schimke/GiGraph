using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotStringAttributeTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new DotSyntaxOptions();
        private readonly DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        [Fact]
        public void string_attribute_returns_encoded_value_with_only_quotation_marks_and_backslashes_escaped_as_attribute_value()
        {
            var value = "a bcd \" \\ \r\n \r \n h ij < > { } | \\";
            var expected = "a bcd \\\" \\ \r\n \r \n h ij < > { } | &#92;";

            IDotEncodable attr = new DotStringAttribute("key", value);
            Assert.Equal(expected, attr.GetDotEncodedValue(_syntaxOptions, _syntaxRules));
        }
    }
}