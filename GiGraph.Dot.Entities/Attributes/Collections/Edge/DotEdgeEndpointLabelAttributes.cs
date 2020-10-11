using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeEndpointLabelAttributes : DotEntityAttributes<IDotEdgeEndpointLabelAttributes>, IDotEdgeEndpointLabelAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup MemberAttributeKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEdgeEndpointLabelAttributes));

        protected DotEdgeEndpointLabelAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup propertyAttributeKeyLookup, DotEdgeEndpointLabelFontAttributes fontAttributes)
            : base(attributes, propertyAttributeKeyLookup)
        {
            Font = fontAttributes;
        }

        public DotEdgeEndpointLabelAttributes(DotAttributeCollection attributes)
            : this(attributes, MemberAttributeKeyLookup, new DotEdgeEndpointLabelFontAttributes(attributes))
        {
        }

        // todo: adjust 'see' references in comment
        /// <summary>
        ///     Font properties used for the head <see cref="IDotEdgeHeadAttributes.Label" /> and the tail
        ///     <see cref="IDotEdgeTailAttributes.Label" /> of the edge. If not set, defaults to the edge's font properties (
        ///     <see cref="IDotEdgeAttributes.Font" />).
        /// </summary>
        public virtual DotEdgeEndpointLabelFontAttributes Font { get; }
        
        [DotAttributeKey("labeldistance")]
        public virtual double? Distance
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(IDotEdgeEndpointLabelAttributes.Distance), v.Value, "Endpoint label distance must be greater than or equal to 0.")
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