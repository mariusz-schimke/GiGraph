using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeStyleAttributes : DotEntityCommonStyleAttributes
    {
        public DotEdgeStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets or sets a line style for the edge (default: <see cref="DotEdgeStyle.Default" />).
        /// </summary>
        public virtual DotEdgeStyle Line
        {
            get => GetPart<DotEdgeStyle>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Gets or sets a line weight for the edge (default: <see cref="DotEdgeWeight.Normal" />).
        /// </summary>
        public virtual DotEdgeWeight Weight
        {
            get => GetPart<DotEdgeWeight>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Applies the specified style options to the edge.
        /// </summary>
        /// <param name="options">
        ///     The options to apply.
        /// </param>
        public virtual void Set(DotEdgeStyleOptions options)
        {
            Set(options.Line, options.Weight, options.Invisible);
        }

        /// <summary>
        ///     Applies the specified style options to the edge.
        /// </summary>
        /// <param name="line">
        ///     The line style to set.
        /// </param>
        /// <param name="weight">
        ///     The line weight to set.
        /// </param>
        /// <param name="invisible">
        ///     Determines whether the edge should be invisible.
        /// </param>
        public virtual void Set(DotEdgeStyle line = DotEdgeStyle.Default, DotEdgeWeight weight = DotEdgeWeight.Normal, bool invisible = false)
        {
            Line = line;
            Weight = weight;
            Invisible = invisible;
        }
    }
}