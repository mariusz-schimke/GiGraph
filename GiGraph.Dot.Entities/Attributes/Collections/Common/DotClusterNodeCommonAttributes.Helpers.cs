using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public partial class DotClusterNodeCommonAttributes<TIEntityAttributeProperties>
    {
        /// <summary>
        ///     Sets a fill color.
        /// </summary>
        /// <param name="color">
        ///     The color to use.
        /// </param>
        public virtual void SetFilled(DotColor color)
        {
            SetFillStyle(DotStyles.Filled);
            FillColor = color;
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
        public virtual void SetFilled(DotGradientColor color, int? angle = null, bool radial = false)
        {
            SetFillStyle(radial ? DotStyles.Radial : DotStyles.Filled);
            FillColor = color;
            GradientAngle = angle;
        }

        /// <summary>
        ///     Sets a striped fill.
        /// </summary>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public virtual void SetStriped(DotMultiColor colors)
        {
            SetFillStyle(DotStyles.Striped);
            FillColor = colors;
        }
    }
}