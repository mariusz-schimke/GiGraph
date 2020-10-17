using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeEndpointLabelAttributes : DotEntityAttributes<IDotEdgeEndpointLabelAttributes>, IDotEdgeEndpointLabelAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeEndpointLabelAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEdgeEndpointLabelAttributes));

        protected DotEdgeEndpointLabelAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEdgeEndpointLabelFontAttributes fontAttributes
        )
            : base(attributes, attributeKeyLookup)
        {
            Font = fontAttributes;
        }

        public DotEdgeEndpointLabelAttributes(DotAttributeCollection attributes)
            : this(attributes, EdgeEndpointLabelAttributesKeyLookup, new DotEdgeEndpointLabelFontAttributes(attributes))
        {
        }

        /// <summary>
        ///     Font properties used for the head and the tail of the edge. If not set, default to the font properties specified for the
        ///     edge.
        /// </summary>
        public virtual DotEdgeEndpointLabelFontAttributes Font { get; }

        [DotAttributeKey("labeldistance")]
        public virtual double? Distance
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Distance), v.Value, "Endpoint label distance must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("labelangle")]
        public virtual double? Angle
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }
    }
}