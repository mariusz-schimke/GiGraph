using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public class DotEdgeStyleAttributes : DotStyleAttributes
    {
        public DotEdgeStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets or sets a line style for the edge (default: <see cref="DotLineStyle.Normal" />).
        /// </summary>
        public virtual DotLineStyle LineStyle
        {
            get => GetPart<DotLineStyle>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Gets or sets a line weight for the edge (default: <see cref="DotLineWeight.Normal" />).
        /// </summary>
        public virtual DotLineWeight LineWeight
        {
            get => GetPart<DotLineWeight>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Gets or sets a value indicating if the edge is invisible.
        /// </summary>
        public virtual bool Invisible
        {
            get => HasOptions(DotStyles.Invisible);
            set => ApplyOption(DotStyles.Invisible, value);
        }

        /// <summary>
        ///     Applies the specified style options to the edge.
        /// </summary>
        /// <param name="options">
        ///     The options to apply.
        /// </param>
        public virtual void Set(DotEdgeStyleProperties options)
        {
            Set(options.LineStyle, options.LineWeight, options.Invisible);
        }

        /// <summary>
        ///     Applies the specified style options to the edge.
        /// </summary>
        /// <param name="lineStyle">
        ///     The line style to set.
        /// </param>
        /// <param name="lineWeight">
        ///     The line weight to set.
        /// </param>
        /// <param name="invisible">
        ///     Determines whether the edge should be invisible.
        /// </param>
        public virtual void Set(DotLineStyle lineStyle = default, DotLineWeight lineWeight = default, bool invisible = false)
        {
            LineStyle = lineStyle;
            LineWeight = lineWeight;
            Invisible = invisible;
        }

        /// <summary>
        ///     Copies style properties from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void CopyFrom(DotEdgeStyleAttributes attributes)
        {
            Set(attributes.LineStyle, attributes.LineWeight, attributes.Invisible);
        }
    }
}