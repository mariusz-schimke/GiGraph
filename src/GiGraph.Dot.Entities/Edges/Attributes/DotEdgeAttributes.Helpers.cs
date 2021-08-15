using System;
using System.Drawing;
using System.Linq;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public partial class DotEdgeAttributes
    {
        /// <summary>
        ///     Applies the <see cref="DotLineStyle.Tapered" /> style to the edge. The edge starts with the specified width, and tapers to
        ///     width 1, in points.
        /// </summary>
        /// <param name="startWidth">
        ///     The width to start with (applied to the <see cref="Width" /> attribute).
        /// </param>
        public virtual void SetTapered(double startWidth)
        {
            _styleAttributes.LineStyle = DotLineStyle.Tapered;
            ((IDotEdgeAttributes) this).Width = startWidth;
        }

        /// <summary>
        ///     Converts the current edge to a segmented line with the specified colors by setting its <see cref="Color" /> attribute. At
        ///     least one of the colors has to have a weight specified (use <see cref="DotWeightedColor" />).
        /// </summary>
        /// <param name="segments">
        ///     The colors to assign to consecutive segments of the edge. At least one of the colors has to have a weight specified (use
        ///     <see cref="DotWeightedColor" />), that determines the proportion of the area covered with the specified color. If only
        ///     weighted colors are provided, the weights must sum to at most 1. If both colors with and without weights are provided, the
        ///     sum of the weighted ones should be below 1, as otherwise those without weights will be ignored by the visualization tool.
        /// </param>
        public virtual void SetSegmented(params DotColor[] segments)
        {
            SetSegmented(new DotMultiColor(segments));
        }

        /// <summary>
        ///     Converts the current edge to a segmented line with the specified colors by setting its <see cref="Color" /> attribute. At
        ///     least one of the colors has to have a weight specified (use <see cref="DotWeightedColor" />).
        /// </summary>
        /// <param name="segments">
        ///     The colors to assign to consecutive segments of the edge. At least one of the colors has to have a weight specified (use
        ///     <see cref="DotWeightedColor" />), that determines the proportion of the area covered with the specified color. If only
        ///     weighted colors are provided, the weights must sum to at most 1. If both colors with and without weights are provided, the
        ///     sum of the weighted ones should be below 1, as otherwise those without weights will be ignored by the visualization tool.
        /// </param>
        public virtual void SetSegmented(DotMultiColor segments)
        {
            if (!segments.Colors.Any(item => item is DotWeightedColor))
            {
                throw new ArgumentException("At least one color has to have a weight specified.", nameof(segments));
            }

            ((IDotEdgeAttributes) this).Color = segments;
        }

        /// <summary>
        ///     Converts the current edge to multiple parallel splines or lines by setting its <see cref="Color" /> attribute.
        /// </summary>
        /// <param name="lineCount">
        ///     The number of parallel splines/lines to compose the edge of.
        /// </param>
        /// <param name="color">
        ///     The color to assign to the splines/lines the edge will be composed of. If not specified,
        ///     <see cref="System.Drawing.Color.Black" /> is used.
        /// </param>
        public virtual void SetMultiline(int lineCount, DotColor color = null)
        {
            color ??= Color.Black;
            var colors = Enumerable.Range(0, lineCount)
               .Select(_ => new DotColor(color.Color, color.Scheme));

            SetMultiline(colors.ToArray());
        }

        /// <summary>
        ///     Converts the current edge to multiple parallel splines or lines by setting its <see cref="Color" /> attribute.
        /// </summary>
        /// <param name="lines">
        ///     The colors to assign to individual splines/lines the edge will be composed of. Note that weighted colors (
        ///     <see cref="DotWeightedColor" />) should not be used among the colors.
        /// </param>
        public virtual void SetMultiline(params DotColor[] lines)
        {
            SetMultiline(new DotMultiColor(lines));
        }

        /// <summary>
        ///     Converts the current edge to multiple parallel splines or lines with the specified colors by setting its <see cref="Color" />
        ///     attribute.
        /// </summary>
        /// <param name="lines">
        ///     The colors to assign to individual splines/lines the edge will be composed of. Note that weighted colors (
        ///     <see cref="DotWeightedColor" />) should not be used among the colors.
        /// </param>
        public virtual void SetMultiline(DotMultiColor lines)
        {
            if (lines.Colors.Any(color => color is DotWeightedColor))
            {
                throw new ArgumentException("Weighted colors cannot be applied to parallel edge splines.", nameof(lines));
            }

            ((IDotEdgeAttributes) this).Color = lines;
        }
    }
}