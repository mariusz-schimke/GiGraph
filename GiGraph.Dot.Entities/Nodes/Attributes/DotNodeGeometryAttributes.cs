using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Geometry;

namespace GiGraph.Dot.Entities.Nodes.Attributes
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

        /// <inheritdoc cref="IDotNodeGeometryAttributes.Sides" />
        [DotAttributeKey(DotAttributeKeys.Sides)]
        public virtual int? Sides
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v!.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Sides), v!.Value, "The number of sides must be greater than or equal to 0.")
                : new DotIntAttribute(k, v!.Value));
        }

        /// <inheritdoc cref="IDotNodeGeometryAttributes.Regular" />
        [DotAttributeKey(DotAttributeKeys.Regular)]
        public virtual bool? Regular
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemoveBoolAttribute(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotNodeGeometryAttributes.Peripheries" />
        [DotAttributeKey(DotAttributeKeys.Peripheries)]
        public virtual int? Peripheries
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemovePeripheries(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotNodeGeometryAttributes.Rotation" />
        [DotAttributeKey(DotAttributeKeys.Orientation)]
        public virtual double? Rotation
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemoveNumericAttribute(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotNodeGeometryAttributes.Skew" />
        [DotAttributeKey(DotAttributeKeys.Skew)]
        public virtual double? Skew
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemoveNumericAttribute(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotNodeGeometryAttributes.Distortion" />
        [DotAttributeKey(DotAttributeKeys.Distortion)]
        public virtual double? Distortion
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemoveNumericAttribute(MethodBase.GetCurrentMethod(), value);
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
        /// <param name="peripheries">
        ///     The number of peripheries.
        /// </param>
        /// <param name="rotation">
        ///     The rotation angle.
        /// </param>
        /// <param name="skew">
        ///     The skew factor.
        /// </param>
        /// <param name="distortion">
        ///     The distortion factor.
        /// </param>
        public virtual void Set(int? sides = null, bool? regular = null, int? peripheries = null, double? rotation = null, double? skew = null, double? distortion = null)
        {
            Sides = sides;
            Regular = regular;
            Peripheries = peripheries;
            Rotation = rotation;
            Skew = skew;
            Distortion = distortion;
        }

        /// <summary>
        ///     Sets polygon geometry attributes.
        /// </summary>
        /// <param name="attributes">
        ///     The attributes to set.
        /// </param>
        public virtual void Set(DotPolygon attributes)
        {
            Set(attributes.Sides, attributes.Regular, attributes.Peripheries, attributes.Rotation, attributes.Skew, attributes.Distortion);
        }

        /// <summary>
        ///     Copies geometry properties from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void Set(IDotNodeGeometryAttributes attributes)
        {
            Set(attributes.Sides, attributes.Regular, attributes.Peripheries, attributes.Rotation, attributes.Skew, attributes.Distortion);
        }
    }
}