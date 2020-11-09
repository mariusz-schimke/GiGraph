using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public class DotNodeStyleAttributes : DotEntityCommonStyleAttributes
    {
        public DotNodeStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets or sets a border style for the node.
        /// </summary>
        public virtual DotBorderStyle Border
        {
            get => GetPart<DotBorderStyle>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Gets or sets a border weight for the node.
        /// </summary>
        public virtual DotBorderWeight Weight
        {
            get => GetPart<DotBorderWeight>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Gets or sets a corner style for the node.
        /// </summary>
        public virtual DotCornerStyle Corners
        {
            get => GetPart<DotCornerStyle>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Gets or sets a fill style for the node.
        /// </summary>
        public virtual DotNodeFillStyle Fill
        {
            get => GetPart<DotNodeFillStyle>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Applies the specified style options to the node.
        /// </summary>
        /// <param name="options">
        ///     The options to apply.
        /// </param>
        public virtual void Set(DotNodeStyleOptions options)
        {
            Set(options.Fill, options.Border, options.Weight, options.Corners, options.Invisible);
        }

        /// <summary>
        ///     Applies the specified style options to the node.
        /// </summary>
        /// <param name="fill">
        ///     The fill style to set.
        /// </param>
        /// <param name="border">
        ///     The border style to set.
        /// </param>
        /// <param name="weight">
        ///     The border weight to set.
        /// </param>
        /// <param name="corners">
        ///     The corner style to set.
        /// </param>
        /// <param name="invisible">
        ///     Determines whether the node should be invisible.
        /// </param>
        public virtual void Set(
            DotNodeFillStyle fill = DotNodeFillStyle.None,
            DotBorderStyle border = DotBorderStyle.Default,
            DotBorderWeight weight = DotBorderWeight.Normal,
            DotCornerStyle corners = DotCornerStyle.Normal,
            bool invisible = false)
        {
            Fill = fill;
            Border = border;
            Weight = weight;
            Corners = corners;
            Invisible = invisible;
        }
    }
}