using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Entities.Tests
{
    public class StringsTest
    {
        private readonly DotGenerationOptions _generationOptions = new DotGenerationOptions();
        private readonly DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        [Fact]
        public void unescaped_string_returns_escaped_string_as_dot_encoded_value()
        {
            DotUnescapedString str = "a bcd \" \\ \r\n \r \n h ij < > { } |";
            Assert.Equal(
                @"a bcd \"" \\ \n \n \n h ij < > { } |",
                ((IDotEncodable) str).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void escaped_string_returns_exact_input_as_dot_encoded_value()
        {
            var value = "a bcd \" \\ \r\n \r \n h ij < > { } |";

            DotEscapedString str = value;
            Assert.Equal(value, ((IDotEncodable) str).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void record_field_string_returns_escaped_string_as_dot_encoded_value()
        {
            var value = "a bcd \" \\ \r\n \r \n h ij < > { } |";

            DotUnescapedRecordFieldString str = value;

            Assert.Equal(
                @"a&#32;bcd&#32;\""&#32;\\&#32;\n&#32;\n&#32;\n&#32;h&#32;ij&#32;\<&#32;\>&#32;\{&#32;\}&#32;\|",
                ((IDotEncodable) str).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }
    }
}