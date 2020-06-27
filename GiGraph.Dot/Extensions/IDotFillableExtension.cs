using System.Drawing;
using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    /// Provides helper methods for <see cref="IDotFillable"/> elements.
    /// </summary>
    public static class IDotFillableExtension
    {
        /// <summary>
        /// Sets the fill color of the current element.
        /// </summary>
        /// <param name="element">The current element whose fill color to set.</param>
        /// <param name="color">The color to set.</param>
        public static void Fill(this IDotFillable element, DotColor color)
        {
            element.Fill(color);
        }

        /// <summary>
        /// Sets the fill color of the current element.
        /// </summary>
        /// <param name="element">The current element whose fill color to set.</param>
        /// <param name="colorList">The color list to set.</param>
        public static void Fill(this IDotFillable element, DotColorList colorList)
        {
            element.Fill(colorList);
        }

        /// <summary>
        /// Sets the fill color of the current element.
        /// </summary>
        /// <param name="element">The current element whose fill color to set.</param>
        /// <param name="color">The color to set (<see cref="Color"/>, <see cref="DotColor"/>, or <see cref="DotColorList"/>).</param>
        public static void Fill(this IDotFillable element, DotColorDefinition color)
        {
            element.Fill(color);
        }
    }
}