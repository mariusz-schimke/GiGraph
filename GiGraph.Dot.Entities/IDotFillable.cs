using System.Drawing;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities
{
    /// <summary>
    /// Makes an element fillable with a color or a color list.
    /// </summary>
    public interface IDotFillable
    {
        /// <summary>
        /// Sets the fill color of the element.
        /// </summary>
        /// <param name="color">The color to set.</param>
        void SetFilled(Color color);

        /// <summary>
        /// Sets the fill color of the element.
        /// </summary>
        /// <param name="colorList">The color list to set.</param>
        void SetFilled(DotColorList colorList);

        /// <summary>
        /// Sets the fill color of the element.
        /// </summary>
        /// <param name="color">The color to set (<see cref="Color"/>, <see cref="DotColor"/>, or <see cref="DotColorList"/>).</param>
        void SetFilled(DotColorDefinition color);
    }
}