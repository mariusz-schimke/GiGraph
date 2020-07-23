using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Entities.Tests
{
    public class DotConcatenatedEscapeStringConcatenationTest
    {
        private readonly DotGenerationOptions _generationOptions = new DotGenerationOptions();
        private readonly DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_only_left_side_is_not_null_and_left_is_concatenated()
        {
            var concatenated = @"\a" + DotEscapeString.GraphId;
            var value = concatenated + (DotEscapeString) null;

            Assert.Equal(
                @"\\a\G",
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_right_side_is_not_null_and_left_is_concatenated_null()
        {
            var value = (DotConcatenatedEscapeString) null + @"\a";

            Assert.Equal(
                @"\\a",
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_only_right_side_is_not_null_and_right_is_concatenated()
        {
            var concatenated = @"\a" + DotEscapeString.GraphId;
            var value = (DotEscapeString) null + concatenated;

            Assert.Equal(
                @"\\a\G",
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_left_side_is_not_null_and_right_is_concatenated_null()
        {
            var value = @"\a" + (DotConcatenatedEscapeString) null;

            Assert.Equal(
                @"\\a",
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_both_sides_are_not_null_and_left_is_concatenated()
        {
            var concatenated = @"\a" + DotEscapeString.GraphId;
            var value = concatenated + " ";

            Assert.Equal(
                @"\\a\G ",
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_both_sides_are_not_null_and_right_is_concatenated()
        {
            var concatenated = @"\a" + DotEscapeString.GraphId;
            var value = " " + concatenated;

            Assert.Equal(
                @" \\a\G",
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_both_sides_are_null_and_both_are_concatenated()
        {
            var value = null + (DotConcatenatedEscapeString) null;

            Assert.Equal(
                string.Empty,
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_both_sides_are_null_and_left_is_concatenated()
        {
            var value = (DotConcatenatedEscapeString) null + (DotEscapeString) null;

            Assert.Equal(
                string.Empty,
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }

        [Fact]
        public void concatenated_escape_string_concatenation_produces_a_valid_dot_encoded_value_when_both_sides_are_null_and_right_is_concatenated()
        {
            var value = (DotEscapeString) null + (DotConcatenatedEscapeString) null;

            Assert.Equal(
                string.Empty,
                ((IDotEncodable) value).GetDotEncodedValue(_generationOptions, _syntaxRules));
        }
    }
}