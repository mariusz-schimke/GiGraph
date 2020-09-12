using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    ///     Represents a list of colors that may be used to generate gradient fill, multicolor stripes or wedges, or multicolor edges.
    /// </summary>
    public class DotMultiColor : DotColorDefinition
    {
        /// <summary>
        ///     <para>
        ///         Creates a new color list rendered in a specific way depending on how many colors are specified, whether they have
        ///         weights, and what type of element the color list is applied to.
        ///     </para>
        ///     <para>
        ///         The returned color list will be rendered as gradient fill when two colors with no weights (<see cref="DotColor" />) are
        ///         specified (refers to the root graph, nodes, and clusters), or as two parallel splines when applied to an edge. When a
        ///         weight is specified for either of the colors (<see cref="DotWeightedColor" />), the returned color list will be rendered
        ///         as dual-color fill (refers to the root graph, nodes, and clusters), or as a two-segment spline, when applied to an edge
        ///         (with color proportions determined by the weight in both cases).
        ///     </para>
        ///     <para>
        ///         When more than two colors are specified, they will be rendered as parallel splines if used for edges (when no weights are
        ///         present), or as multicolor segments (when at least one weighted color is present). When used for rectangularly-shaped
        ///         nodes or clusters with the <see cref="DotStyles.Striped" /> style, the returned color list will be rendered as a striped
        ///         multicolor fill, or as a wedged multicolor fill, when used for elliptically-shaped nodes with the
        ///         <see cref="DotStyles.Wedged" /> style.
        ///     </para>
        /// </summary>
        /// <param name="colors">
        ///     The colors to initialize the instance with. The supported types are <see cref="DotColor" /> (with no weight) and
        ///     <see cref="DotWeightedColor" /> (with weight). If only weighted colors are provided, the weights must sum to at most 1. If
        ///     both colors with and without weights are provided, the sum of the weighted ones should be below 1, as otherwise those without
        ///     weights will be ignored by the visualization tool.
        /// </param>
        public DotMultiColor(params DotColor[] colors)
        {
            if (colors is null)
            {
                throw new ArgumentNullException(nameof(colors), "Color collection cannot be null.");
            }

            var totalWeight = colors.Sum(c => c.GetWeight().GetValueOrDefault(0));
            if (totalWeight > 1)
            {
                throw new ArgumentException("The weights of the colors must sum to at most 1 for a color list.", nameof(colors));
            }

            Colors = colors;
        }

        /// <summary>
        ///     <para>
        ///         Creates a new color list rendered in a specific way depending on how many colors are specified, whether they have
        ///         weights, and what type of element the color list is applied to.
        ///     </para>
        ///     <para>
        ///         The returned color list will be rendered as gradient fill when two colors with no weights (<see cref="DotColor" />) are
        ///         specified (refers to the root graph, nodes, and clusters), or as two parallel splines when applied to an edge. When a
        ///         weight is specified for either of the colors (<see cref="DotWeightedColor" />), the returned color list will be rendered
        ///         as dual-color fill (refers to the root graph, nodes, and clusters), or as a two-segment spline, when applied to an edge
        ///         (with color proportions determined by the weight in both cases).
        ///     </para>
        ///     <para>
        ///         When more than two colors are specified, they will be rendered as parallel splines if used for edges (when no weights are
        ///         present), or as multicolor segments (when at least one weighted color is present). When used for rectangularly-shaped
        ///         nodes or clusters with the <see cref="DotStyles.Striped" /> style, the returned color list will be rendered as a striped
        ///         multicolor fill, or as a wedged multicolor fill, when used for elliptically-shaped nodes with the
        ///         <see cref="DotStyles.Wedged" /> style.
        ///     </para>
        /// </summary>
        /// <param name="colors">
        ///     The colors to initialize the instance with. The supported types are <see cref="DotColor" /> (with no weight) and
        ///     <see cref="DotWeightedColor" /> (with weight). If only weighted colors are provided, the weights must sum to at most 1. If
        ///     both colors with and without weights are provided, the sum of the weighted ones should be below 1, as otherwise those without
        ///     weights will be ignored by the visualization tool.
        /// </param>
        public DotMultiColor(IEnumerable<DotColor> colors)
            : this(colors?.ToArray())
        {
        }

        /// <summary>
        ///     <para>
        ///         Creates a new color list rendered in a specific way depending on how many colors are specified, and what type of element
        ///         the color list is applied to.
        ///     </para>
        ///     <para>
        ///         The returned color list will be rendered as gradient fill when only two colors are specified (refers to the root graph,
        ///         nodes, and clusters), or as two parallel splines when applied to an edge.
        ///     </para>
        ///     <para>
        ///         When more than two colors are specified, they will be rendered as parallel splines, if used for edges; when used for
        ///         rectangularly-shaped nodes or clusters with the <see cref="DotStyles.Striped" /> style, the returned color list will be
        ///         rendered as a striped multicolor fill, or as a wedged multicolor fill, when used for elliptically-shaped nodes with the
        ///         <see cref="DotStyles.Wedged" /> style.
        ///     </para>
        /// </summary>
        /// <param name="colors">
        ///     The colors to initialize the instance with.
        /// </param>
        public DotMultiColor(IEnumerable<Color> colors)
            : this(colors?.Select(c => new DotColor(c)))
        {
        }

        /// <summary>
        ///     Gets the colors of the color list (<see cref="DotColor" />, <see cref="DotWeightedColor" />).
        /// </summary>
        public virtual DotColor[] Colors { get; }

        public override string ToString()
        {
            return string.Join(", ", Colors.Select(color => color.ToString()));
        }

        protected internal override string GetDotEncodedColor(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            var colors = Colors.Select(color => color.GetDotEncodedColor(options, syntaxRules));
            return string.Join(":", colors);
        }
    }
}