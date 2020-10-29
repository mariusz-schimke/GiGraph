using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Fonts;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract class DotEntityFontAttributes<TIEntityFontAttributes> : DotEntityAttributes<TIEntityFontAttributes>, IDotEntityFontAttributes
        where TIEntityFontAttributes : IDotEntityFontAttributes
    {
        protected DotEntityFontAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
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

        [DotAttributeKey("fontcolor")]
        public virtual DotColor Color
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        /// <summary>
        ///     Sets font properties.
        /// </summary>
        /// <param name="size">
        ///     Font size.
        /// </param>
        /// <param name="color">
        ///     Font color.
        /// </param>
        /// <param name="name">
        ///     Font name.
        /// </param>
        public virtual void Set(double? size = null, DotColor color = null, string name = null)
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
            Set(attributes.Size, attributes.Color, attributes.Name);
        }
    }
}