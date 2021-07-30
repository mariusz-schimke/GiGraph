using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.EscapeString
{
    public class DotEscapeStringTest
    {
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void escaped_string_returns_exact_input_as_dot_encoded_value()
        {
            var value = "a bcd \" \\ \r\n \r \n h ij < > { } |";

            DotEscapedString str = value;
            Assert.Equal(value, ((IDotEscapable) str).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void unescaped_string_returns_escaped_string_as_dot_encoded_value()
        {
            DotUnescapedString str = "a bcd \" \\ \r\n \r \n h ij < > { } |";
            Assert.Equal(
                @"a bcd \"" \\ \n \n \n h ij < > { } |",
                ((IDotEscapable) str).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }
    }
}