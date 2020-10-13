using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities
{
    /// <summary>
    ///     Makes an element fillable with a color or a color list.
    /// </summary>
    public interface IDotFillable
    {
        /// <summary>
        ///     Sets a fill color of the element and includes the <see cref="DotStyles.Filled" /> flag in its styles.
        /// </summary>
        /// <param name="color">
        ///     The color to set.
        /// </param>
        void SetFilled(Color color);

        /// <summary>
        ///     Sets a fill color of the element and includes the <see cref="DotStyles.Filled" /> flag in its styles.
        /// </summary>
        /// <param name="color">
        ///     The color to set (<see cref="Color" />, <see cref="DotColor" />, or <see cref="DotMultiColor" />).
        /// </param>
        void SetFilled(DotColorDefinition color);
    }
}