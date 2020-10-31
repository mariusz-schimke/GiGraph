using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public class DotNodeGeometryAttributes : DotEntityAttributes<IDotNodeGeometryAttributes>, IDotNodeGeometryAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup NodeGeometryAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeGeometryAttributes, IDotNodeGeometryAttributes>().Build();

        protected DotNodeGeometryAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotNodeGeometryAttributes(DotAttributeCollection attributes)
            : base(attributes, NodeGeometryAttributesKeyLookup)
        {
        }

        [DotAttributeKey("sides")]
        public virtual int? Sides
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Sides), v.Value, "The number of sides must be greater than or equal to 0.")
                : new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey("regular")]
        public virtual bool? Regular
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("skew")]
        public virtual double? Skew
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("distortion")]
        public virtual double? Distortion
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("orientation")]
        public virtual double? Rotation
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }
    }
}