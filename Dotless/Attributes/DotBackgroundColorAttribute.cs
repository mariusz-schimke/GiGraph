using System.Drawing;

namespace Dotless.Attributes
{
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
