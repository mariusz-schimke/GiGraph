using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Graphs
{
    public partial class DotGraphSection
    {
        /// <summary>
        ///     Sets a background color.
        /// </summary>
        /// <param name="color">
        ///     The color to use.
        /// </param>
        public virtual void SetBackground(DotColor color)
        {
            Canvas.BackgroundColor = color;
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
        public virtual void SetBackground(DotGradientColor color, int? angle = null, bool? radial = null)
        {
            switch (radial)
            {
                // the style may also be set from the Clusters collection on graph, and radial is the only attribute
                // that applies to graph background and to cluster fill
                case true:
                    Style.FillStyle = DotClusterFillStyle.Radial;
                    break;

                case false when Style.FillStyle == DotClusterFillStyle.Radial:
                    Style.FillStyle = DotClusterFillStyle.None;
                    break;
            }

            Canvas.BackgroundColor = color;
            Canvas.GradientFillAngle = angle;
        }
    }
}