using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotEntityFontAttributes : DotEntityAttributes<IDotEntityFontAttributes>, IDotEntityFontAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EntityFontAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEntityFontAttributes));

        protected DotEntityFontAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup propertyAttributeKeyLookup)
            : base(attributes, propertyAttributeKeyLookup)
        {
        }

        public DotEntityFontAttributes(DotAttributeCollection attributes)
            : base(attributes, EntityFontAttributesKeyLookup)
        {
        }

        [DotAttributeKey("fontcolor")]
        public virtual DotColor Color
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey("fontname")]
        public virtual string Name
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("fontsize")]
        public virtual double? Size
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Size), v.Value, "Font size must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }
    }
}