using System.Drawing;

namespace Dotless.Attributes
{
    public class DotBackgroundColorAttribute : DotColorAttribute
    {
        public DotBackgroundColorAttribute(Color value)
            : base("bgcolor", value)
        {
        }
    }
}
