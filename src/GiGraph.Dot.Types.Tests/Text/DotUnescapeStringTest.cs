using System;
using GiGraph.Dot.Types.Text;
using Xunit;

namespace GiGraph.Dot.Types.Tests.Text
{
    public class DotUnescapeStringTest
    {
        [Fact]
        public void throws_exception_on_constructor_null_value()
        {
            Assert.Throws<ArgumentNullException>(() => new DotUnescapedString(null));
        }

        [Fact]
        public void implicit_conversion_returns_null()
        {
            DotUnescapedString escStringValue = (string) null;
            Assert.Null(escStringValue);

            string stringValue = escStringValue;
            Assert.Null(stringValue);

            escStringValue = (DotHtmlString) null;
            Assert.Null(escStringValue);
        }
    }
}