using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    /// Provides helper methods for <see cref="DotNode"/>.
    /// </summary>
    public static class DotNodeColorExtension
    {
        /// <summary>
        /// Sets the fill color of the current node.
        /// </summary>
        /// <param name="node">The current node whose fill color to set.</param>
        /// <param name="color">The color to set.</param>
        public static void Fill(this DotNode node, DotColor color)
        {
            node.Fill((DotColorDefinition) color);
        }

        /// <summary>
        /// Sets the fill color of the current node.
        /// </summary>
        /// <param name="node">The current node whose fill color to set.</param>
        /// <param name="colorList">The color list to set.</param>
        public static void Fill(this DotNode node, DotColorList colorList)
        {
            node.Fill((DotColorDefinition) colorList);
        }

        /// <summary>
        /// Sets the fill color of the current node.
        /// </summary>
        /// <param name="node">The current node whose fill color to set.</param>
        /// <param name="color">The color to set (<see cref="Color"/>, <see cref="DotColor"/>, or <see cref="DotColorList"/>).</param>
        public static void Fill(this DotNode node, DotColorDefinition color)
        {
            if (node.Attributes.Style is null)
            {
                node.Attributes.Style = DotStyle.Filled;
            }
            else
            {
                node.Attributes.Style |= DotStyle.Filled;
            }

            node.Attributes.FillColor = color;
        }
    }
}