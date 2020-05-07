using System.Drawing;

namespace Dotless.Attributes
{
    public class DotColorAttribute : DotAttribute<Color>
    {
        public static string AttributeKey => "color";

        protected DotColorAttribute(string key, Color color)
            : base(key, color)
        {
        }

        public DotColorAttribute(Color value)
            : this(AttributeKey, value)
        {
        }

        public override string ToString()
        {
            return _value.Name.ToString();
        }

        protected override string GetValueAsString()
        {
            return $"#{_value.R:x2}{_value.G:x2}{_value.B:x2}{_value.A:x2}";
        }

        public static implicit operator DotColorAttribute(Color color)
        {
            return new DotColorAttribute(color);
        }
    }
}
