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
        ///     <para>
        ///         The color scheme to evaluate the current color with if a named color is specified. See <see cref="DotColorSchemes" /> for
        ///         supported scheme names.
        ///     </para>
        ///     <para>
        ///         Pass null to use the color scheme set on the element, or to use the default scheme if none was set. Pass
        ///         <see cref="DotColorSchemes.Default" /> to make the color be evaluated using the default
        ///         <see cref="DotColorSchemes.X11" /> naming.
        ///     </para>
        /// </param>
        public DotColor(Color color, string scheme = null)
        {
            Color = color;
            Scheme = scheme;
        }

        /// <summary>
        ///     Creates a new instance initialized with a named color.
        /// </summary>
        /// <param name="name">
        ///     The color name to initialize the instance with. The name will be evaluated in the context of the <paramref name="scheme" />
        ///     if specified, in the context of the scheme applied to the current element if any, or in the context of the default
        ///     <see cref="DotColorSchemes.X11" /> scheme otherwise.
        /// </param>
        /// <param name="scheme">
        ///     <para>
        ///         The color scheme to evaluate the current color with if a named color is specified. See <see cref="DotColorSchemes" /> for
        ///         supported scheme names.
        ///     </para>
        ///     <para>
        ///         Pass null to use the color scheme set on the element, or to use the default scheme if none was set. Pass
        ///         <see cref="DotColorSchemes.Default" /> to make the color be evaluated using the default
        ///         <see cref="DotColorSchemes.X11" /> naming.
        ///     </para>
        /// </param>
        public DotColor(string name, string scheme = null)
            : this(Color.FromName(name), scheme)
        {
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

        protected internal override string GetDotEncodedColor(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            if (options.Colors.PreferName && Color.IsNamedColor)
            {
                var scheme = Scheme is null
                    ? null
                    : Scheme == DotColorSchemes.Default
                        ? DotColorSchemes.Default
                        : $"/{Scheme}/";

                return $"{scheme?.ToLowerInvariant()}{Color.Name.ToLowerInvariant()}";
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