using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Styles;

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
        ///     Determines whether to use a radial-style gradient fill. Note that this attribute also applies to clusters. Pass null if you
        ///     don't want to modify the current fill style if set.
        /// </param>
        public virtual DotGraphAttributes SetBackground(DotGradientColor color, int? angle = null, bool? radial = null)
        {
            // the style may also be set from the Clusters collection on graph, and radial is the only attribute
            // that applies to graph background and to cluster fill
            if (true == radial)
            {
                Style.Fill = DotClusterFillStyle.Radial;
            }
            else if (false == radial && Style.Fill == DotClusterFillStyle.Radial)
            {
                Style.Fill = DotClusterFillStyle.None;
            }

            BackgroundColor = color;
            GradientAngle = angle;

            return this;
        }
    }
}