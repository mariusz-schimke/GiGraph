using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeEndpointLabelFontAttributes : DotEntityFontAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeEndpointLabelFontAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEdgeEndpointLabelFontAttributes));

        protected DotEdgeEndpointLabelFontAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup propertyAttributeKeyLookup)
            : base(attributes, propertyAttributeKeyLookup)
        {
        }

        public DotEdgeEndpointLabelFontAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeEndpointLabelFontAttributesKeyLookup)
        {
        }

        /// <summary>
        ///     Font used for the head <see cref="IDotEdgeHeadAttributes.Label" /> and the tail <see cref="IDotEdgeTailAttributes.Label" />
        ///     of the edge. If not set, defaults to the edge's font name (<see cref="IDotEntityFontAttributes.Name" />).
        /// </summary>
        [DotAttributeKey("labelfontname")]
        public override string Name
        {
            get => base.Name;
            set => base.Name = value;
        }

        /// <summary>
        ///     Color used for the head <see cref="IDotEdgeHeadAttributes.Label" /> and the tail <see cref="IDotEdgeTailAttributes.Label" />
        ///     of the edge. If not set, defaults to the edge's font color (<see cref="IDotEntityFontAttributes.Color" />).
        /// </summary>
        [DotAttributeKey("labelfontcolor")]
        public override DotColor Color
        {
            get => base.Color;
            set => base.Color = value;
        }

        /// <summary>
        ///     Font size, in points, used for the head <see cref="IDotEdgeHeadAttributes.Label" /> and the tail
        ///     <see cref="IDotEdgeTailAttributes.Label" /> of the edge. If not set, defaults to the edge's font size (
        ///     <see cref="IDotEntityFontAttributes.Size" />).
        /// </summary>
        [DotAttributeKey("labelfontsize")]
        public override double? Size
        {
            get => base.Size;
            set => base.Size = value;
        }
    }
}