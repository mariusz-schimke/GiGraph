using GiGraph.Dot.Entities.Labels;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Labels
{
    public class DotTextLabelTest
    {
        [Fact]
        public void converts_string_to_text_label()
        {
            var value = "text";
            DotLabel label = value;
            Assert.Equal(value, label.ToString());
        }
    }
}