using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Fonts;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public abstract class DotFontAttributes<TIEntityFontAttributes> : DotEntityAttributes<TIEntityFontAttributes>, IDotFontAttributes
        where TIEntityFontAttributes : IDotFontAttributes
    {
        protected DotFontAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotFontAttributes.Name" />
        [DotAttributeKey(DotAttributeKeys.FontName)]
        public virtual string Name
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotFontAttributes.Size" />
        [DotAttributeKey(DotAttributeKeys.FontSize)]
        public virtual double? Size
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Size), v.Value, "Font size must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotFontAttributes.Color" />
        [DotAttributeKey(DotAttributeKeys.FontColor)]
        public virtual DotColor Color
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        /// <summary>
        ///     Sets font properties.
        /// </summary>
        /// <param name="name">
        ///     Font name.
        /// </param>
        /// <param name="size">
        ///     Font size.
        /// </param>
        /// <param name="color">
        ///     Font color.
        /// </param>
        public virtual void Set(string name = null, double? size = null, DotColor color = null)
        {
            Size = size;
            Color = color;
            Name = name;
        }

        /// <summary>
        ///     Sets font properties.
        /// </summary>
        /// <param name="attributes">
        ///     The properties to set.
        /// </param>
        public virtual void Set(DotFont attributes)
        {
            Set(attributes.Name, attributes.Size, attributes.Color);
        }

        /// <summary>
        ///     Copies font properties from the specified instance.
        /// </summary>
        /// <param name="source">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void CopyFrom(IDotFontAttributes source)
        {
            Set(source.Name, source.Size, source.Color);
        }
    }
}