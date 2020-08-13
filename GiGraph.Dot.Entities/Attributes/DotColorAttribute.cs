using System.Drawing;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Represents a single color.
    /// </summary>
    public class DotColorAttribute : DotAttribute<Color>
    {
        /// <summary>
        ///     Creates a new color attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute, for example "color", "bgcolor", or "fillcolor".
        /// </param>
        /// <param name="color">
        ///     The value of the attribute as a color.
        /// </param>
        public DotColorAttribute(string key, Color color)
            : base(key, color)
        {
        }

        public override string ToString()
        {
            return new DotColor(Value).ToString();
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return new DotColor(Value).GetDotEncodedColor(options, syntaxRules);
        }
    }
}