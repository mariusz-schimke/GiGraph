using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common
{
    public abstract class DotFontAttributes<TIEntityFontAttributes> : DotEntityAttributesWithMetadata<TIEntityFontAttributes>, IDotFontAttributes
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
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotFontAttributes.Size" />
        [DotAttributeKey(DotAttributeKeys.FontSize)]
        public virtual double? Size
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set
            {
                if (value < 0.0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Size), value, "Font size must be greater than or equal to 0.");
                }

                SetOrRemove(MethodBase.GetCurrentMethod(), value);
            }
        }

        /// <inheritdoc cref="IDotFontAttributes.Color" />
        [DotAttributeKey(DotAttributeKeys.FontColor)]
        public virtual DotColor Color
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
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
        /// <param name="attributes">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void Set(IDotFontAttributes attributes)
        {
            Set(attributes.Name, attributes.Size, attributes.Color);
        }
    }
}