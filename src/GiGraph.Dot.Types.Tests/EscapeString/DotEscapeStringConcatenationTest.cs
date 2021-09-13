using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.EscapeString;
using Xunit;

namespace GiGraph.Dot.Types.Tests.EscapeString
{
    public class DotEscapeStringConcatenationTest
    {
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void escape_string_concatenation_produces_a_valid_dot_encoded_value_when_both_sides_are_not_null()
        {
            var value = @"\a" + DotEscapeString.GraphId;

            Assert.Equal(
                @"\\a\G",
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void escape_string_concatenation_produces_a_valid_dot_encoded_value_when_left_side_is_null()
        {
            var value = (DotEscapeString) null + @"\a";

            Assert.Equal(
                @"\\a",
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void escape_string_concatenation_produces_a_valid_dot_encoded_value_when_right_side_is_null()
        {
            var value = @"\a" + (DotEscapeString) null;

            Assert.Equal(
                @"\\a",
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void escape_string_concatenation_produces_an_empty_dot_encoded_value_when_both_sides_are_null()
        {
            var value = null + (DotEscapeString) null;

            Assert.Equal(
                string.Empty,
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }
    }
}