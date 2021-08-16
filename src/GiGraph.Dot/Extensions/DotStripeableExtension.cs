using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Extensions
{
    public static class DotStripeableExtension
    {
        /// <summary>
        ///     Sets a striped fill. Applicable to clusters and rectangularly-shaped nodes (see <see cref="DotNode.Shape" />).
        /// </summary>
        /// <param name="this">
        ///     The current context to set the fill for.
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetStripedFill<T>(this T @this, DotMultiColor colors)
            where T : IDotStylable, IDotStripeable
        {
            @this.SetStyle(DotStyles.Striped);
            @this.SetStripeColors(colors);
        }

        /// <summary>
        ///     Sets a striped fill. Applicable to rectangularly-shaped nodes.
        /// </summary>
        /// <param name="this">
        ///     The current context to set the fill for.
        /// </param>
        /// <param name="shape">
        ///     The shape to set (has to be rectangular).
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetStripedFill<T>(this T @this, DotNodeShape shape, DotMultiColor colors)
            where T : IDotStylable, IDotStripeable, IDotShapableNode
        {
            @this.SetStripedFill(colors);
            @this.SetShape(shape);
        }

        /// <summary>
        ///     Sets a striped fill. Applicable to clusters and rectangularly-shaped nodes (see <see cref="DotNode.Shape" />).
        /// </summary>
        /// <param name="this">
        ///     The current context to set the fill for.
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetStripedFill<T>(this T @this, params DotColor[] colors)
            where T : IDotStylable, IDotStripeable
        {
            @this.SetStripedFill(new DotMultiColor(colors));
        }

        /// <summary>
        ///     Sets a striped fill. Applicable to rectangularly-shaped nodes.
        /// </summary>
        /// <param name="this">
        ///     The current context to set the fill for.
        /// </param>
        /// <param name="shape">
        ///     The shape to set (has to be rectangular).
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetStripedFill<T>(this T @this, DotNodeShape shape, params DotColor[] colors)
            where T : IDotStylable, IDotStripeable, IDotShapableNode
        {
            @this.SetStripedFill(shape, new DotMultiColor(colors));
        }
    }
}