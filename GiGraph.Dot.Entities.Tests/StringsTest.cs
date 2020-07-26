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
        public void escaped_string_returns_exact_input_as_dot_encoded_value()
        {
            var value = "a bcd \" \\ \r\n \r \n h ij < > { } |";

            DotEscapedString str = value;
            Assert.Equal(value, ((IDotEscapable) str).GetEscaped(_syntaxRules.TextValueEscaper));
        }

        [Fact]
        public void unescaped_string_returns_escaped_string_as_dot_encoded_value()
        {
            DotUnescapedString str = "a bcd \" \\ \r\n \r \n h ij < > { } |";
            Assert.Equal(
                @"a bcd \"" \\ \n \n \n h ij < > { } |",
                ((IDotEscapable) str).GetEscaped(_syntaxRules.TextValueEscaper));
        }
    }
}