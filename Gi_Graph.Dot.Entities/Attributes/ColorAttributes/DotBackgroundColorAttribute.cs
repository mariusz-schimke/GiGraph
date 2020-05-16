using System.Drawing;

namespace GiGraph.Dot.Entities.Attributes.ColorAttributes
{
    /// <summary>
    /// Background color attribute. Supported by graphs and cluster subgraphs.
    /// </summary>
    public class DotBackgroundColorAttribute : DotColorAttribute
    {
        public static new string AttributeKey => "bgcolor";

        public DotBackgroundColorAttribute(Color value)
            : base(AttributeKey, value)
        {
        }

        public static implicit operator DotBackgroundColorAttribute(Color color)
        {
            return new DotBackgroundColorAttribute(color);
        }
    }
}
