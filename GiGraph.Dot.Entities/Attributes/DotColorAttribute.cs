using System.Drawing;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Color attribute.
    /// </summary>
    public class DotColorAttribute : DotAttribute<Color>
    {
        /// <summary>
        /// Creates a new color attribute.
        /// </summary>
        /// <param name="key">The key of the attribute, for example "color" or "bgcolor".</param>
        /// <param name="color">The value of the attribute as color.</param>
        public DotColorAttribute(string key, Color color)
            : base(key, color)
        {
        }

        public override string ToString()
        {
            return Value.Name.ToString();
        }

        protected override string GetDotEncodedValue()
        {
            return $"#{Value.R:x2}{Value.G:x2}{Value.B:x2}{Value.A:x2}";
        }
    }
}
