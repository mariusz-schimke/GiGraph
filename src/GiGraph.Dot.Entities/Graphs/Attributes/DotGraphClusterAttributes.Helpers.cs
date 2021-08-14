using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public partial class DotGraphClusterAttributes
    {
        /// <summary>
        ///     Sets the fill color of clusters.
        /// </summary>
        /// <param name="color">
        ///     The color to use.
        /// </param>
        public virtual void SetFilled(DotColor color)
        {
            Style.FillStyle = DotClusterFillStyle.Normal;
            FillColor = color;
        }

        /// <summary>
        ///     Sets a gradient fill for clusters.
        /// </summary>
        /// <param name="color">
        ///     The gradient color definition to use.
        /// </param>
        /// <param name="angle">
        ///     The angle of the fill. Note that this attribute is shared with the parent graph (see
        ///     <see cref="DotGraphCanvasAttributes.GradientFillAngle" /> of graph <see cref="IDotGraphAttributesRoot.Canvas" />), and will
        ///     overwrite its current value if already set there.
        /// </param>
        /// <param name="radial">
        ///     Determines whether to use a radial-style gradient fill. Note that this attribute is shared with the parent graph (see
        ///     <see cref="IDotGraphAttributes.Style" />), and will overwrite its current value if already set there.
        /// </param>
        public virtual void SetFilled(DotGradientColor color, int? angle = null, bool radial = false)
        {
            Style.FillStyle = radial ? DotClusterFillStyle.Radial : DotClusterFillStyle.Normal;
            FillColor = color;
            ((IDotGraphAttributesRoot) _graphAttributes).Canvas.GradientFillAngle = angle;
        }

        /// <summary>
        ///     Sets a striped fill.
        /// </summary>
        /// <param name="colors">
        ///     The colors to use for consecutive stripes. Proportions for individual stripes may be specified optionally by using a
        ///     <see cref="DotWeightedColor" /> for them.
        /// </param>
        public virtual void SetStriped(DotMultiColor colors)
        {
            Style.FillStyle = DotClusterFillStyle.Striped;
            FillColor = colors;
        }
    }
}