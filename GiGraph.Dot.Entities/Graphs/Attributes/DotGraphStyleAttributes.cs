using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Graphs;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public class DotGraphStyleAttributes : DotStyleAttributes
    {
        public DotGraphStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets or sets a fill style of the graph. Note that the style is shared with clusters, and that the only option applicable to
        ///     the root graph is <see cref="DotClusterFillStyle.Radial" />.
        /// </summary>
        public virtual DotClusterFillStyle FillStyle
        {
            get => GetPart<DotClusterFillStyle>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Applies the specified style options to the graph and clusters.
        /// </summary>
        /// <param name="options">
        ///     The options to apply.
        /// </param>
        public virtual void Set(DotGraphStyleOptions options)
        {
            Set(options.FillStyle);
        }

        /// <summary>
        ///     Applies the specified style options to the graph and clusters.
        /// </summary>
        /// <param name="fillStyle">
        ///     The fill options to apply.
        /// </param>
        public virtual void Set(DotClusterFillStyle fillStyle = default)
        {
            FillStyle = fillStyle;
        }

        /// <summary>
        ///     Copies style properties from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void CopyFrom(DotGraphStyleAttributes attributes)
        {
            Set(attributes.FillStyle);
        }
    }
}