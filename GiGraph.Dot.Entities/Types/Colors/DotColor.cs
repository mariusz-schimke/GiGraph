using System.Drawing;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    /// Represents a single color.
    /// </summary>
    public class DotColor : DotColorDefinition
    {
        /// <summary>
        /// Creates a new instance initialized with a color.
        /// </summary>
        /// <param name="color">The color to initialize the instance with.</param>
        public DotColor(Color color)
        {
            Color = color;
        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        public virtual Color Color { get; }

        protected internal virtual double? GetWeight()
        {
            return null;
        }

        protected internal override string GetDotEncodedColor(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            if (options.Colors.PreferName && Color.IsNamedColor)
            {
                return Color.Name.ToLowerInvariant();
            }

            if (Color.IsEmpty)
            {
                return string.Empty;
            }

            // add alpha only when necessary
            var alpha = Color.A < 0xff ? $"{Color.A:x2}" : null;

            return $"#{Color.R:x2}{Color.G:x2}{Color.B:x2}{alpha}";
        }

        public override string ToString()
        {
            if (Color.IsNamedColor)
            {
                return Color.Name;
            }

            if (Color.IsEmpty)
            {
                return string.Empty;
            }

            return $"#{Color.ToArgb():x8}";
        }

        public static implicit operator DotColor(Color? color)
        {
            return color.HasValue ? new DotColor(color.Value) : null;
        }

        public static implicit operator Color?(DotColor color)
        {
            return color?.Color;
        }
    }
}