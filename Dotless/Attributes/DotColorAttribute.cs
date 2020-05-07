using System.Drawing;

namespace Dotless.Attributes
{
    public class DotColorAttribute : DotAttribute<Color>
    {
        protected DotColorAttribute(string key, Color color)
            : base(key, color)
        {
        }

        public DotColorAttribute(Color value)
            : this("color", value)
        {
        }

        protected override string GetValueAsString()
        {
            return $"#{_value.R:x2}{_value.G:x2}{_value.B:x2}{_value.A:x2}";
        }
    }
}
