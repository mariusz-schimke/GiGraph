using System.Drawing;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    ///     Represents a single color.
    /// </summary>
    public class DotColor : DotColorDefinition
    {
        /// <summary>
        ///     Creates a new instance initialized with a color.
        /// </summary>
        /// <param name="color">
        ///     The color to initialize the instance with.
        /// </param>
        /// <param name="scheme">
        ///     The color scheme to use (or to override one if set on the element as an attribute). See <see cref="DotColorSchemes" /> for
        ///     supported scheme names. Pass null to use the color scheme set on the element, or to use the default scheme if none was set.
        ///     Pass <see cref="DotColorSchemes.Default" /> to make the color be evaluated using the default X11 naming.
        /// </param>
        public DotColor(Color color, string scheme = null)
        {
            Color = color;
            Scheme = scheme;
        }

        /// <summary>
        ///     Gets the color.
        /// </summary>
        public virtual Color Color { get; }

        /// <summary>
        ///     Gets the color scheme (see <see cref="DotColorSchemes" />).
        /// </summary>
        public virtual string Scheme { get; }

        protected internal virtual double? GetWeight()
        {
            return null;
        }

        protected internal override string GetDotEncodedColor(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            if (options.Colors.PreferName && Color.IsNamedColor)
            {
                var scheme = Scheme is null
                    ? null
                    : Scheme == DotColorSchemes.Default
                        ? DotColorSchemes.Default
                        : $"/{Scheme}/";

                return $"{scheme}{Color.Name.ToLowerInvariant()}";
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
            var scheme = Scheme is {} ? $"{Scheme}:" : null;

            if (Color.IsNamedColor)
            {
                return $"{scheme}{Color.Name}";
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