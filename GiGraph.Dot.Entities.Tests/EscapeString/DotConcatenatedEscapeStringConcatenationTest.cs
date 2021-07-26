using GiGraph.Dot.Entities.Types.Text;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.EscapeString
{
    public class DotConcatenatedEscapeStringConcatenationTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_both_sides_are_not_null_and_left_is_concatenated()
        {
            var concatenated = @"\a" + DotEscapeString.GraphId;
            var value = concatenated + " ";

            Assert.Equal(
                @"\\a\G ",
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_both_sides_are_not_null_and_right_is_concatenated()
        {
            var concatenated = @"\a" + DotEscapeString.GraphId;
            var value = " " + concatenated;

            Assert.Equal(
                @" \\a\G",
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_both_sides_are_null_and_both_are_concatenated()
        {
            var value = null + (DotConcatenatedEscapeString) null;

            Assert.Equal(
                string.Empty,
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_both_sides_are_null_and_left_is_concatenated()
        {
            var value = null + (DotEscapeString) null;

            Assert.Equal(
                string.Empty,
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_both_sides_are_null_and_right_is_concatenated()
        {
            var value = null + (DotConcatenatedEscapeString) null;

            Assert.Equal(
                string.Empty,
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_left_side_is_not_null_and_right_is_concatenated_null()
        {
            var value = @"\a" + (DotConcatenatedEscapeString) null;

            Assert.Equal(
                @"\\a",
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_only_left_side_is_not_null_and_left_is_concatenated()
        {
            var concatenated = @"\a" + DotEscapeString.GraphId;
            var value = concatenated + null;

            Assert.Equal(
                @"\\a\G",
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_only_right_side_is_not_null_and_right_is_concatenated()
        {
            var concatenated = @"\a" + DotEscapeString.GraphId;
            var value = null + concatenated;

            Assert.Equal(
                @"\\a\G",
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_right_side_is_not_null_and_left_is_concatenated_null()
        {
            var value = (DotConcatenatedEscapeString) null + @"\a";

            Assert.Equal(
                @"\\a",
                ((IDotEscapable) value).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }
    }
}