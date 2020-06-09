using System.Drawing;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes.Colors
{
    /// <summary>
    /// Color attribute.
    /// </summary>
    public class DotColorAttribute : DotCommonAttribute<Color>
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
            return Value.Name;
        }

        protected override string GetDotEncodedValue(DotGenerationOptions options)
        {
            return DotColorConverter.Convert(Value, options);
        }
    }
}
