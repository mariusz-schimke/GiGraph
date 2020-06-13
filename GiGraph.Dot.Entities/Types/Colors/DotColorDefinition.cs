using System.Collections.Generic;
using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Colors
{
    /// <summary>
    /// Represents a color definition as a single color (<see cref="DotColor"/>), as a gradient (<see cref="DotColorList"/>)
    /// or as multiple colors (<see cref="DotColorList"/>).
    /// </summary>
    public abstract class DotColorDefinition : IDotEncodableValue
    {
        protected internal abstract string GetDotEncodedColor(DotGenerationOptions options);
        string IDotEncodableValue.GetDotEncodedValue(DotGenerationOptions options) => GetDotEncodedColor(options);

        /// <summary>
        /// Creates a new color instance initialized with a single color.
        /// </summary>
        /// <param name="color">The color to initialize the instance with.</param>
        public static DotColor Mono(Color color)
        {
            return new DotColor(color);
        }

        /// <summary>
        /// Creates a new color instance initialized with a color (<see cref="DotColor"/>),
        /// or with a weighted color (<see cref="DotWeightedColor"/>) if <paramref name="weight"/> is specified.
        /// <see cref="DotWeightedColor"/> may be used in color lists only, where the weight specifies the area proportion for the color.
        /// </summary>
        /// <param name="color">The color to initialize the instance with.</param>
        /// <param name="weight">The optional weight of the color in the range 0 ≤ <paramref name="weight"/> ≤ 1.
        /// Use only if the returned color will be an item of a color lists.</param>
        public static DotColor Weighted(Color color, double? weight)
        {
            if (weight.HasValue)
            {
                return new DotWeightedColor(color, weight.Value);
            }

            return new DotColor(color);
        }

        /// <summary>
        /// <para>
        ///     Creates a new color definition that will be rendered in a specific way depending on how many colors are specified,
        ///     whether they have weights, and what type of element the color definition is applied to.
        /// </para>
        /// <para>
        ///     The returned definition will be rendered as a gradient fill when two colors with no weights (<see cref="DotColor"/>)
        ///     are specified (refers to the root graph, nodes, and clusters), or as two parallel splines when applied to an edge.
        ///     When a weight is specified for either of the colors (<see cref="DotWeightedColor"/>), the returned definition
        ///     will be rendered as a two-color fill (refers to the root graph, nodes, and clusters), or as a two-segment line,
        ///     when applied to an edge (with color proportions determined by the weight in both cases).
        /// </para>
        /// <para>
        ///     When more than two colors are specified, they will be rendered as parallel splines if used for edges
        ///     (when no weights are present), or as multicolor segments (when at least one weighted color is present).
        ///     When used for rectangularly-shaped nodes or clusters with the <see cref="DotStyle.Striped"/> style,
        ///     the returned color definition will be rendered as a striped multicolor fill, or as a wedged multicolor fill,
        ///     when used for elliptically-shaped nodes with the <see cref="DotStyle.Wedged"/> style.
        /// </para>
        /// </summary>
        /// <param name="colors">The colors to initialize the instance with. The supported types are
        /// <see cref="DotColor"/> (with no weight) and <see cref="DotWeightedColor"/> (with weight).
        /// If only weighted colors are provided, the weights must sum to at most 1.
        /// If both colors with and without weights are provided, the sum of the weighted ones must be below 1.</param>
        public static DotColorList Multi(params DotColor[] colors)
        {
            return new DotColorList(colors);
        }

        /// <summary>
        /// <para>
        ///     Creates a new color definition that will be rendered in a specific way depending on how many colors are specified,
        ///     whether they have weights, and what type of element the color definition is applied to.
        /// </para>
        /// <para>
        ///     The returned definition will be rendered as a gradient fill when two colors with no weights (<see cref="DotColor"/>)
        ///     are specified (refers to the root graph, nodes, and clusters), or as two parallel splines when applied to an edge.
        ///     When a weight is specified for either of the colors (<see cref="DotWeightedColor"/>), the returned definition
        ///     will be rendered as a two-color fill (refers to the root graph, nodes, and clusters), or as a two-segment line,
        ///     when applied to an edge (with color proportions determined by the weight in both cases).
        /// </para>
        /// <para>
        ///     When more than two colors are specified, they will be rendered as parallel splines if used for edges
        ///     (when no weights are present), or as multicolor segments (when at least one weighted color is present).
        ///     When used for rectangularly-shaped nodes or clusters with the <see cref="DotStyle.Striped"/> style,
        ///     the returned color definition will be rendered as a striped multicolor fill, or as a wedged multicolor fill,
        ///     when used for elliptically-shaped nodes with the <see cref="DotStyle.Wedged"/> style.
        /// </para>
        /// </summary>
        /// <param name="colors">The colors to initialize the instance with. The supported types are
        /// <see cref="DotColor"/> (with no weight) and <see cref="DotWeightedColor"/> (with weight).
        /// If only weighted colors are provided, the weights must sum to at most 1.
        /// If both colors with and without weights are provided, the sum of the weighted ones must be below 1.</param>
        public static DotColorList Multi(IEnumerable<DotColor> colors)
        {
            return new DotColorList(colors);
        }

        /// <summary>
        /// <para>
        ///     Creates a new color definition that will be rendered in a specific way depending on how many colors are specified,
        ///     and what type of element the color definition is applied to.
        /// </para>
        /// <para>
        ///     The returned definition will be rendered as a gradient fill when only two colors are specified
        ///     (refers to the root graph, nodes, and clusters), or as two parallel splines when applied to an edge.
        /// </para>
        /// <para>
        ///     When more than two colors are specified, they will be rendered as parallel splines, if used for edges;
        ///     when used for rectangularly-shaped nodes or clusters with the <see cref="DotStyle.Striped"/> style,
        ///     the returned color definition will be rendered as a striped multicolor fill, or as a wedged multicolor fill,
        ///     when used for elliptically-shaped nodes with the <see cref="DotStyle.Wedged"/> style.
        /// </para>
        /// </summary>
        /// <param name="colors">The colors to initialize the instance with.</param>
        public static DotColorList Multi(params Color[] colors)
        {
            return new DotColorList(colors);
        }

        /// <summary>
        /// <para>
        ///     Creates a new color definition that will be rendered in a specific way depending on how many colors are specified,
        ///     and what type of element the color definition is applied to.
        /// </para>
        /// <para>
        ///     The returned definition will be rendered as a gradient fill when only two colors are specified
        ///     (refers to the root graph, nodes, and clusters), or as two parallel splines when applied to an edge.
        /// </para>
        /// <para>
        ///     When more than two colors are specified, they will be rendered as parallel splines, if used for edges;
        ///     when used for rectangularly-shaped nodes or clusters with the <see cref="DotStyle.Striped"/> style,
        ///     the returned color definition will be rendered as a striped multicolor fill, or as a wedged multicolor fill,
        ///     when used for elliptically-shaped nodes with the <see cref="DotStyle.Wedged"/> style.
        /// </para>
        /// </summary>
        /// <param name="colors">The colors to initialize the instance with.</param>
        public static DotColorList Multi(IEnumerable<Color> colors)
        {
            return new DotColorList(colors);
        }

        /// <summary>
        /// Creates a new color definition that will be rendered as a two-color fill when applied to the root graph,
        /// node, or cluster, or as a two-segment line, when applied to an edge. Only one color weight should be specified.
        /// </summary>
        /// <param name="color1">The first color to initialize the instance with.</param>
        /// <param name="color2">The second color to initialize the instance with.</param>
        /// <param name="weight1">The optional weight of the first color. Only one of the weight parameters should be specified,
        /// and it must be in the range 0 ≤ <paramref name="weight1"/> &lt; 1.</param>
        /// <param name="weight2">The optional weight of the second color. Only one of the weight parameters should be specified,
        /// and it must be in the range 0 ≤ <paramref name="weight2"/> &lt; 1.</param>
        public static DotColorList Double(Color color1, Color color2, double? weight1 = null, double? weight2 = null)
        {
            return new DotColorList(color1, color2, weight1, weight2);
        }

        /// <summary>
        /// Creates a new color definition that will be rendered as a gradient fill when applied to the root graph, node, or cluster.
        /// </summary>
        /// <param name="startColor">The start color of the gradient fill.</param>
        /// <param name="endColor">The end color of the gradient fill.</param>
        public static DotColorList Gradient(Color startColor, Color endColor)
        {
            return new DotColorList(startColor, endColor);
        }

        public static implicit operator DotColorDefinition(Color? color)
        {
            return color.HasValue ? new DotColor(color.Value) : null;
        }

        public static implicit operator DotColorDefinition(Color[] colors)
        {
            return colors is {} ? new DotColorList(colors) : null;
        }

        public static implicit operator DotColorDefinition(DotColor[] colors)
        {
            return colors is {} ? new DotColorList(colors) : null;
        }
    }
}