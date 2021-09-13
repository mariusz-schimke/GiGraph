using System;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.EscapeString;
using Xunit;

namespace GiGraph.Dot.Types.Tests.EscapeString
{
    public class DotEscapedStringTest
    {
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void throws_exception_on_constructor_null_value()
        {
            Assert.Throws<ArgumentNullException>(() => new DotEscapedString(null));
        }

        [Fact]
        public void implicit_conversion_returns_null_for_null()
        {
            DotEscapedString escStringValue = (string) null;
            Assert.Null(escStringValue);

            string stringValue = escStringValue;
            Assert.Null(stringValue);
        }

        [Fact]
        public void to_string_returns_original_value()
        {
            var value = DotEscapeStringTest.SpecialChars;

            DotEscapedString escStringValue = value;
            Assert.Equal(value, escStringValue.ToString());
        }

        [Fact]
        public void returns_exact_input_as_dot_encoded_value()
        {
            var value = $"a bcd {DotEscapeStringTest.SpecialChars} h ij";

            DotEscapedString str = value;
            Assert.Equal(value, ((IDotEscapable) str).GetEscaped(_syntaxRules.Attributes.EscapeStringValueEscaper));
        }
    }
}