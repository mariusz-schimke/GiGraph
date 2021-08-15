using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Extensions
{
    // TODO: problem jest taki, że tych ustawień nie da się zastosować dla globalnych atrybutów (zobaczyć też inne extensions)
    // TODO: testy jednostkowe

    public static class DotClusterStyleExtension
    {
        /// <summary>
        ///     Sets a plain-color fill.
        /// </summary>
        /// <param name="cluster">
        ///     The current cluster.
        /// </param>
        /// <param name="color">
        ///     The color to use.
        /// </param>
        public static void SetPlainColorFill(this DotCluster cluster, DotColor color)
        {
            cluster.Style.FillStyle = DotClusterFillStyle.Normal;
            cluster.FillColor = color;
        }

        /// <summary>
        ///     Sets a gradient fill.
        /// </summary>
        /// <param name="cluster">
        ///     The current cluster.
        /// </param>
        /// <param name="color">
        ///     The gradient color definition to use.
        /// </param>
        /// <param name="angle">
        ///     The angle of the fill.
        /// </param>
        /// <param name="radial">
        ///     Determines whether to use a radial-style gradient fill.
        /// </param>
        public static void SetGradientFill(this DotCluster cluster, DotGradientColor color, int? angle = null, bool radial = false)
        {
            cluster.Style.FillStyle = radial ? DotClusterFillStyle.Radial : DotClusterFillStyle.Normal;
            cluster.FillColor = color;
            cluster.GradientFillAngle = angle;
        }

        /// <summary>
        ///     Sets a striped fill.
        /// </summary>
        /// <param name="cluster">
        ///     The current cluster.
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetStripedFill(this DotCluster cluster, DotMultiColor colors)
        {
            cluster.Style.FillStyle = DotClusterFillStyle.Striped;
            cluster.FillColor = colors;
        }

        /// <summary>
        ///     Sets a striped fill.
        /// </summary>
        /// <param name="cluster">
        ///     The current cluster.
        /// </param>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public static void SetStripedFill(this DotCluster cluster, params DotColor[] colors)
        {
            cluster.SetStripedFill(new DotMultiColor(colors));
        }
    }
}