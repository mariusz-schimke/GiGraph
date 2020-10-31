using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Geometry;

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

        /// <summary>
        ///     Sets polygon geometry attributes.
        /// </summary>
        /// <param name="sides">
        ///     The number of sides.
        /// </param>
        /// <param name="regular">
        ///     Determines whether the shape should be regular.
        /// </param>
        /// <param name="skew">
        ///     The skew factor.
        /// </param>
        /// <param name="distortion">
        ///     The distortion factor.
        /// </param>
        /// <param name="rotation">
        ///     The rotation angle.
        /// </param>
        public virtual void Set(int? sides, bool? regular, double? skew, double? distortion, double? rotation)
        {
            Sides = sides;
            Regular = regular;
            Skew = skew;
            Distortion = distortion;
            Rotation = rotation;
        }

        /// <summary>
        ///     Sets polygon geometry attributes.
        /// </summary>
        /// <param name="attributes">
        ///     The attributes to set.
        /// </param>
        public virtual void Set(DotPolygon attributes)
        {
            Set(attributes.Sides, attributes.Regular, attributes.Skew, attributes.Distortion, attributes.Rotation);
        }
    }
}