using System.Drawing;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    ///     Represents a color definition as a single color (<see cref="DotColor" />), as a gradient (<see cref="DotColorList" />) or as
    ///     multiple colors (<see cref="DotColorList" />).
    /// </summary>
    public abstract class DotColorDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedColor(options, syntaxRules);
        }

        protected internal abstract string GetDotEncodedColor(DotGenerationOptions options, DotSyntaxRules syntaxRules);

        public static implicit operator DotColorDefinition(Color? color)
        {
            return color.HasValue ? new DotColor(color.Value) : null;
        }

        public static implicit operator DotColorDefinition(Color[] colors)
        {
            return colors is {} ? new DotColorList(colors) : null;
        }

        public static implicit operator DotColorDefinition(DotColor[] colors)
        {
            return colors is {} ? new DotColorList(colors) : null;
        }
    }
}