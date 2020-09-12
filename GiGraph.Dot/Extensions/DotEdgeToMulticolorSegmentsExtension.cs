using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    ///     Provides extension methods for <see cref="DotEdge{TTail,THead}" />.
    /// </summary>
    public static class DotEdgeToMulticolorSegmentsExtension
    {
        /// <summary>
        ///     Converts the current edge to a segmented line with the specified colors. At least one of the colors has to have a weight
        ///     specified (use <see cref="DotWeightedColor" />).
        /// </summary>
        /// <param name="edge">
        ///     The edge to convert.
        /// </param>
        /// <param name="colors">
        ///     The colors to assign to consecutive segments of the edge. At least one of the colors has to have a weight specified (use
        ///     <see cref="DotWeightedColor" />), that determines the proportion of the area covered with the specified color. If only
        ///     weighted colors are provided, the weights must sum to at most 1. If both colors with and without weights are provided, the
        ///     sum of the weighted ones should be below 1, as otherwise those without weights will be ignored by the visualization tool.
        /// </param>
        public static void ToMulticolorSegments(this DotEdge edge, params DotColor[] colors)
        {
            edge.SetColors(colors);
        }

        /// <summary>
        ///     Converts the current edge to a segmented line with the specified colors. At least one of the colors has to have a weight
        ///     specified (use <see cref="DotWeightedColor" />).
        /// </summary>
        /// <param name="edge">
        ///     The edge to convert.
        /// </param>
        /// <param name="colors">
        ///     The colors to assign to consecutive segments of the edge. At least one of the colors has to have a weight specified (use
        ///     <see cref="DotWeightedColor" />), that determines the proportion of the area covered with the specified color. If only
        ///     weighted colors are provided, the weights must sum to at most 1. If both colors with and without weights are provided, the
        ///     sum of the weighted ones should be below 1, as otherwise those without weights will be ignored by the visualization tool.
        /// </param>
        public static void ToMulticolorSegments(this DotEdge edge, IEnumerable<DotColor> colors)
        {
            edge.SetColors(colors.ToArray());
        }

        private static void SetColors(this DotEdge edge, DotColor[] colors)
        {
            if (!colors.Any(color => color is DotWeightedColor))
            {
                throw new ArgumentException("At least one color has to have a weight specified.", nameof(colors));
            }

            edge.Attributes.Color = new DotMultiColor(colors);
        }
    }
}