using System;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Text;
using Xunit;

namespace GiGraph.Dot.Types.Tests.EscapeString
{
    public class DotEscapeStringTest
    {
        public const string SpecialChars = "\" \\ \r\n \r \n < > { } |";
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void escaped_string_returns_exact_input_as_dot_encoded_value()
        {
            var value = $"a bcd {SpecialChars} h ij";

            DotEscapedString str = value;
            Assert.Equal(value, ((IDotEscapable) str).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void unescaped_string_returns_escaped_string_as_dot_encoded_value()
        {
            DotUnescapedString str = $"a bcd {SpecialChars} h ij";
            Assert.Equal(
                @"a bcd \"" \\ \n \n \n < > { } | h ij",
                ((IDotEscapable) str).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }

        [Fact]
        public void throws_exception_on_constructor_null_value()
        {
            Assert.Throws<ArgumentNullException>(() => new DotEscapedString(null));
            Assert.Throws<ArgumentNullException>(() => new DotUnescapedString(null));
            Assert.Throws<ArgumentNullException>(() => new DotHtmlString(null));
        }
    }
}