using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Extensions
{
    /// <summary>
    ///     Provides extension methods for <see cref="DotEdge{TTail,THead}" />.
    /// </summary>
    public static class DotEdgeToParallelSplinesExtension
    {
        /// <summary>
        ///     Converts the current edge to multiple parallel splines with the specified colors.
        /// </summary>
        /// <param name="edge">
        ///     The edge to convert.
        /// </param>
        /// <param name="count">
        ///     The number of splines to compose the edge of.
        /// </param>
        /// <param name="color">
        ///     The color to assign to the splines the edge will be composed of. If not specified, <see cref="Color.Black" /> is used.
        /// </param>
        public static void ToParallelSplines(this DotEdge edge, int count, DotColor color = null)
        {
            color ??= Color.Black;
            var colors = Enumerable.Range(0, count)
               .Select(i => new DotColor(color.Color, color.Scheme));

            edge.SetColors(colors.ToArray());
        }

        /// <summary>
        ///     Converts the current edge to multiple parallel splines with the specified colors.
        /// </summary>
        /// <param name="edge">
        ///     The edge to convert.
        /// </param>
        /// <param name="colors">
        ///     The colors to assign to individual splines the edge will be composed of. Note that weighted colors (
        ///     <see cref="DotWeightedColor" />) should not be used among the colors.
        /// </param>
        public static void ToParallelSplines(this DotEdge edge, params DotColor[] colors)
        {
            edge.SetColors(colors);
        }

        /// <summary>
        ///     Converts the current edge to multiple parallel splines with the specified colors.
        /// </summary>
        /// <param name="edge">
        ///     The edge to convert.
        /// </param>
        /// <param name="colors">
        ///     The colors to assign to individual splines the edge will be composed of. Note that weighted colors (
        ///     <see cref="DotWeightedColor" />) should not be used among the colors.
        /// </param>
        public static void ToParallelSplines(this DotEdge edge, IEnumerable<DotColor> colors)
        {
            edge.SetColors(colors.ToArray());
        }

        /// <summary>
        ///     Converts the current edge to multiple parallel splines with the specified colors.
        /// </summary>
        /// <param name="edge">
        ///     The edge to convert.
        /// </param>
        /// <param name="colors">
        ///     The colors to assign to individual splines the edge will be composed of. Note that weighted colors (
        ///     <see cref="DotWeightedColor" />) should not be used among the colors.
        /// </param>
        public static void ToParallelSplines(this DotEdge edge, IEnumerable<Color> colors)
        {
            edge.SetColors(colors.Select(color => new DotColor(color)).ToArray());
        }

        private static void SetColors(this DotEdge edge, DotColor[] colors)
        {
            if (colors.Any(color => color is DotWeightedColor))
            {
                throw new ArgumentException("Weighted colors cannot be applied to edge splines.", nameof(colors));
            }

            edge.Attributes.Color = new DotMultiColor(colors);
        }
    }
}