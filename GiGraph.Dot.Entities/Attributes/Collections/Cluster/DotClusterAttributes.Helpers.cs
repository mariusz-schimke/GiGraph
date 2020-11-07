using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public partial class DotClusterAttributes
    {
        /// <summary>
        ///     Makes the border and background of the cluster invisible.
        /// </summary>
        public virtual DotClusterAttributes SetInvisible()
        {
            Style.Invisible = true;
            return this;
        }

        /// <summary>
        ///     Sets a fill color.
        /// </summary>
        /// <param name="color">
        ///     The color to use.
        /// </param>
        public virtual DotClusterAttributes SetFilled(DotColor color)
        {
            Style.Filled = true;
            FillColor = color;
            return this;
        }

        /// <summary>
        ///     Sets a gradient fill.
        /// </summary>
        /// <param name="color">
        ///     The gradient color definition to use.
        /// </param>
        /// <param name="angle">
        ///     The angle of the fill.
        /// </param>
        /// <param name="radial">
        ///     Determines whether to use a radial-style gradient fill.
        /// </param>
        public virtual DotClusterAttributes SetFilled(DotGradientColor color, int? angle = null, bool radial = false)
        {
            Style.Filled = true;
            Style.Radial = radial;

            FillColor = color;
            GradientAngle = angle;

            return this;
        }
    }
}