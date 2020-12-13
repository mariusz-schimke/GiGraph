using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Types.Geometry;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public class DotNodeSizeAttributes : DotEntityAttributes<IDotNodeSizeAttributes>, IDotNodeSizeAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup NodeSizeAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeSizeAttributes, IDotNodeSizeAttributes>().Build();

        protected DotNodeSizeAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotNodeSizeAttributes(DotAttributeCollection attributes)
            : base(attributes, NodeSizeAttributesKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotNodeSizeAttributes.Width" />
        [DotAttributeKey(DotAttributeKeys.Width)]
        public virtual double? Width
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Width), v.Value, "The width must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotNodeSizeAttributes.Height" />
        [DotAttributeKey(DotAttributeKeys.Height)]
        public virtual double? Height
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Height), v.Value, "The height must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotNodeSizeAttributes.Mode" />
        [DotAttributeKey(DotAttributeKeys.FixedSize)]
        public virtual DotNodeSizing? Mode
        {
            get => GetValueAs<DotNodeSizing>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotNodeSizing?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotNodeSizingAttribute(k, v.Value));
        }

        /// <summary>
        ///     Sets size attributes.
        /// </summary>
        /// <paramref name="width">
        ///     The width to set.
        /// </paramref>
        /// <paramref name="height">
        ///     The width to set.
        /// </paramref>
        public virtual void Set(double? width, double? height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        ///     Sets size attributes.
        /// </summary>
        /// <paramref name="width">
        ///     The width to set.
        /// </paramref>
        /// <paramref name="height">
        ///     The width to set.
        /// </paramref>
        /// <paramref name="mode">
        ///     The sizing mode to set.
        /// </paramref>
        public virtual void Set(double? width, double? height, DotNodeSizing? mode)
        {
            Set(width, height);
            Mode = mode;
        }

        /// <summary>
        ///     Sets size attributes.
        /// </summary>
        /// <param name="attributes">
        ///     The attributes to set.
        /// </param>
        public virtual void Set(DotSize attributes)
        {
            Set(attributes.Width, attributes.Height);
        }

        /// <summary>
        ///     Sets size attributes.
        /// </summary>
        /// <param name="attributes">
        ///     The attributes to set.
        /// </param>
        public virtual void Set(DotNodeSize attributes)
        {
            Set(attributes.Width, attributes.Height, attributes.Mode);
        }

        /// <summary>
        ///     Copies size properties from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void Set(IDotNodeSizeAttributes attributes)
        {
            Set(attributes.Width, attributes.Height, attributes.Mode);
        }
    }
}