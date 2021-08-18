using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Qualities
{
    public interface IDotFillable
    {
        /// <summary>
        ///     Sets the fill style.
        /// </summary>
        /// <param name="style">
        ///     The style to set.
        /// </param>
        void SetFillStyle(DotFillStyle style);

        /// <summary>
        ///     Sets the fill color.
        /// </summary>
        /// <param name="color">
        ///     The color to set.
        /// </param>
        void SetFillColor(DotColorDefinition color);

        /// <summary>
        ///     Sets the gradient angle.
        /// </summary>
        /// <param name="angle">
        ///     The gradient angle to set.
        /// </param>
        void SetGradientFillAngle(int? angle);
    }
}