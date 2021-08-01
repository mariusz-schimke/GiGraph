using GiGraph.Dot.Types.Text;
using Xunit;

namespace GiGraph.Dot.Types.Tests.Text
{
    public class DotEscapeStringTest
    {
        public const string SpecialChars = "\" \\ \r\n \r \n < > { } |";

        [Fact]
        public void implicit_conversion_returns_null_for_null()
        {
            DotEscapeString escStringValue = (string) null;
            Assert.Null(escStringValue);

            string stringValue = escStringValue;
            Assert.Null(stringValue);
        }
    }
}