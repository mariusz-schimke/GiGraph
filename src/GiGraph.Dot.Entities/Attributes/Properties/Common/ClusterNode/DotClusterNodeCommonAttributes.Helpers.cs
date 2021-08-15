using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.ClusterNode
{
    // TODO: jak to współdzielić z root graphem? Wspólny interfejs, dla którego zdefiniowana zostanie klasa extension?
    // Może wtedy dla spójności wszystkie takie helpery przenieść do extension?
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
            // SetFillStyle(DotStyles.Filled);
            // FillColor = color;
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
            // SetFillStyle(radial ? DotStyles.Radial : DotStyles.Filled);
            // FillColor = color;
            // GradientFillAngle = angle;
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
            // SetFillStyle(DotStyles.Striped);
            // FillColor = colors;
        }

        /// <summary>
        ///     Sets a striped fill.
        /// </summary>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public virtual void SetStriped(params DotColor[] colors)
        {
            SetStriped(new DotMultiColor(colors));
        }
    }
}