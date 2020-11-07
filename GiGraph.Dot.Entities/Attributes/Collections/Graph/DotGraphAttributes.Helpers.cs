using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public partial class DotGraphAttributes
    {
        /// <summary>
        ///     Sets a background color.
        /// </summary>
        /// <param name="color">
        ///     The color to use.
        /// </param>
        public virtual DotGraphAttributes SetBackground(DotColor color)
        {
            BackgroundColor = color;
            return this;
        }

        /// <summary>
        ///     Sets a gradient background.
        /// </summary>
        /// <param name="color">
        ///     The gradient color definition to use.
        /// </param>
        /// <param name="angle">
        ///     The angle of the fill. Note that this attribute also applies to clusters.
        /// </param>
        /// <param name="radial">
        ///     Determines whether to use a radial-style gradient fill. Note that this attribute also applies to clusters.
        /// </param>
        public virtual DotGraphAttributes SetBackground(DotGradientColor color, int? angle = null, bool? radial = null)
        {
            if (Style.IsSet() || radial.HasValue)
            {
                Style.Radial = radial.GetValueOrDefault(false);
            }

            BackgroundColor = color;
            GradientAngle = angle;

            return this;
        }
    }
}