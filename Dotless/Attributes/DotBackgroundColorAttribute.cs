using System.Drawing;

namespace Dotless.Attributes
{
    public class DotBackgroundColorAttribute : DotColorAttribute
    {
        public DotBackgroundColorAttribute(Color value)
            : base("bgcolor", value)
        {
        }

        public static implicit operator DotBackgroundColorAttribute(Color color)
        {
            return new DotBackgroundColorAttribute(color);
        }
    }
}
