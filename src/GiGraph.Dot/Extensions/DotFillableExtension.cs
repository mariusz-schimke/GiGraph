using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Extensions
{
    public static class DotFillableExtension
    {
        /// <summary>
        ///     Sets a plain-color fill.
        /// </summary>
        /// <param name="this">
        ///     The current context to set the fill for.
        /// </param>
        /// <param name="color">
        ///     The color to use.
        /// </param>
        public static void SetPlainColorFill<T>(this T @this, DotColor color)
            where T : IDotStylable, IDotFillable
        {
            @this.SetStyle(DotStyles.Filled);
            @this.SetFillColor(color);
        }

        /// <summary>
        ///     Sets a gradient fill.
        /// </summary>
        /// <param name="this">
        ///     The current context to set the fill for.
        /// </param>
        /// <param name="color">
        ///     The gradient color definition to use.
        /// </param>
        /// <param name="angle">
        ///     The angle of the fill.
        /// </param>
        public static void SetGradientFill<T>(this T @this, DotGradientColor color, int? angle = null)
            where T : IDotStylable, IDotFillable
        {
            @this.SetGradientFill(color, angle, radial: false);
        }

        /// <summary>
        ///     Sets a radiant gradient fill.
        /// </summary>
        /// <param name="this">
        ///     The current context to set the fill for.
        /// </param>
        /// <param name="color">
        ///     The gradient color definition to use.
        /// </param>
        /// <param name="angle">
        ///     The angle of the fill.
        /// </param>
        public static void SetRadialGradientFill<T>(this T @this, DotGradientColor color, int? angle = null)
            where T : IDotStylable, IDotFillable
        {
            @this.SetGradientFill(color, angle, radial: true);
        }

        private static void SetGradientFill<T>(this T @this, DotGradientColor color, int? angle, bool radial)
            where T : IDotStylable, IDotFillable
        {
            @this.SetStyle(radial ? DotStyles.Radial : DotStyles.Filled);
            @this.SetFillColor(color);
            @this.SetGradientFillAngle(angle);
        }
    }
}