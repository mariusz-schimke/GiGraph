using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public class DotGraphStyleAttributes : DotEntityStyleAttributes
    {
        protected DotGraphStyleAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotGraphStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="DotStyles.Radial" /> style option state. Note that the option applies not only to the graph, but
        ///     also to clusters.
        /// </summary>
        public virtual bool Radial
        {
            get => HasOptions(DotStyles.Radial);
            set => ApplyOption(DotStyles.Radial, value);
        }

        /// <summary>
        ///     Applies the specified style options to the graph. Note that the <see cref="DotClusterStyleOptions.Radial" /> option applies
        ///     not only to the graph, but also to clusters.
        /// </summary>
        /// <param name="options">
        ///     The options to apply.
        /// </param>
        public virtual void Apply(DotGraphStyleOptions options)
        {
            base.Apply(options);
        }
    }
}