using System;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public partial class DotEdgeAttributes
    {
        /// <summary>
        ///     Makes the edge invisible.
        /// </summary>
        public virtual DotEdgeAttributes SetInvisible()
        {
            Style.Invisible = true;
            return this;
        }

        /// <summary>
        ///     Sets the fill color of the arrowhead(s), assuming that they have a filled style. See the
        ///     <see cref="DotEdgeEndpointAttributes.Arrowhead" /> attribute of <see cref="Head" /> and/or <see cref="Tail" /> to set a
        ///     filled arrowhead shape if required.
        /// </summary>
        /// <param name="color">
        ///     The color to use.
        /// </param>
        public virtual DotEdgeAttributes SetFilled(DotColor color)
        {
            FillColor = color;
            return this;
        }

        /// <summary>
        ///     Applies the <see cref="DotStyles.Tapered" /> style to the edge. The edge starts with the specified width, and tapers to width
        ///     1, in points.
        /// </summary>
        /// <param name="startWidth">
        ///     The width to start with (applied to the <see cref="Width" /> attribute).
        /// </param>
        public virtual DotEdgeAttributes SetTapered(double startWidth)
        {
            Style.LineStyle = DotLineStyle.Tapered;
            Width = startWidth;
            return this;
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
        public virtual DotEdgeAttributes SetSegmented(params DotColor[] segments)
        {
            return SetSegmented(new DotMultiColor(segments));
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
        public virtual DotEdgeAttributes SetSegmented(DotMultiColor segments)
        {
            if (!segments.Colors.Any(item => item is DotWeightedColor))
            {
                throw new ArgumentException("At least one color has to have a weight specified.", nameof(segments));
            }

            Color = segments;
            return this;
        }

        /// <summary>
        ///     Converts the current edge to multiple parallel splines by setting its <see cref="Color" /> attribute.
        /// </summary>
        /// <param name="splineCount">
        ///     The number of parallel splines to compose the edge of.
        /// </param>
        /// <param name="color">
        ///     The color to assign to the splines the edge will be composed of. If not specified, <see cref="System.Drawing.Color.Black" />
        ///     is used.
        /// </param>
        public virtual DotEdgeAttributes SetMultiline(int splineCount, DotColor color = null)
        {
            color ??= System.Drawing.Color.Black;
            var colors = Enumerable.Range(0, splineCount)
               .Select(i => new DotColor(color.Color, color.Scheme));

            return SetMultiline(colors.ToArray());
        }

        /// <summary>
        ///     Converts the current edge to multiple parallel splines by setting its <see cref="Color" /> attribute.
        /// </summary>
        /// <param name="splines">
        ///     The colors to assign to individual splines the edge will be composed of. Note that weighted colors (
        ///     <see cref="DotWeightedColor" />) should not be used among the colors.
        /// </param>
        public virtual DotEdgeAttributes SetMultiline(params DotColor[] splines)
        {
            return SetMultiline(new DotMultiColor(splines));
        }

        /// <summary>
        ///     Converts the current edge to multiple parallel splines with the specified colors by setting its <see cref="Color" />
        ///     attribute.
        /// </summary>
        /// <param name="splines">
        ///     The colors to assign to individual splines the edge will be composed of. Note that weighted colors (
        ///     <see cref="DotWeightedColor" />) should not be used among the colors.
        /// </param>
        public virtual DotEdgeAttributes SetMultiline(DotMultiColor splines)
        {
            if (splines.Colors.Any(color => color is DotWeightedColor))
            {
                throw new ArgumentException("Weighted colors cannot be applied to parallel edge splines.", nameof(splines));
            }

            Color = splines;
            return this;
        }
    }
}