using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public class DotGraphStyleAttributes : DotEntityStyleAttributes
    {
        public DotGraphStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets or sets a fill style of the graph. Note that the style is shared with clusters, and that the only option applicable to
        ///     the root graph is <see cref="DotClusterFillStyle.Radial" />.
        /// </summary>
        public virtual DotClusterFillStyle Fill
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
            Set(options.Fill);
        }

        /// <summary>
        ///     Applies the specified style options to the graph and clusters.
        /// </summary>
        /// <param name="fill">
        ///     The fill options to apply.
        /// </param>
        public virtual void Set(DotClusterFillStyle fill = DotClusterFillStyle.None)
        {
            Fill = fill;
        }
    }
}