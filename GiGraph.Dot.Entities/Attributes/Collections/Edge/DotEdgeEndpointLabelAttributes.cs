using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeEndpointLabelAttributes : DotEntityAttributes<IDotEdgeEndpointLabelAttributes>, IDotEdgeEndpointLabelAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeEndpointLabelAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeEndpointLabelAttributes, IDotEdgeEndpointLabelAttributes>().Build();

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
        ///     Font attributes used for labels of the head and of the tail of the edge. If not set, default to font attributes specified for
        ///     the edge.
        /// </summary>
        public virtual DotEdgeEndpointLabelFontAttributes Font { get; }

        [DotAttributeKey(DotAttributeKeys.LabelDistance)]
        public virtual double? Distance
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Distance), v.Value, "Endpoint label distance must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.LabelAngle)]
        public virtual double? Angle
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }
    }
}