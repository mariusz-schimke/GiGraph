using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Graphs;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public class DotGraphFontAttributes : DotFontAttributes<IDotGraphFontAttributes>, IDotGraphFontAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphFontAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphFontAttributes, IDotGraphFontAttributes>().Build();

        protected DotGraphFontAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotGraphFontAttributes(DotAttributeCollection attributes)
            : base(attributes, GraphFontAttributesKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotGraphFontAttributes.Directories" />
        [DotAttributeKey(DotAttributeKeys.FontPath)]
        public virtual string Directories
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphFontAttributes.Convention" />
        [DotAttributeKey(DotAttributeKeys.FontNames)]
        public virtual DotFontConvention? Convention
        {
            get => GetValueAs<DotFontConvention>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
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
        /// <param name="directories">
        ///     The directories to search for fonts.
        /// </param>
        /// <param name="convention">
        ///     The font convention to use.
        /// </param>
        public virtual void Set(string name = null, double? size = null, DotColor color = null, string directories = null, DotFontConvention? convention = null)
        {
            base.Set(name, size, color);
            Directories = directories;
            Convention = convention;
        }

        /// <summary>
        ///     Sets font properties.
        /// </summary>
        /// <param name="attributes">
        ///     The properties to set.
        /// </param>
        public virtual void Set(DotGraphFont attributes)
        {
            base.Set(attributes);
            Directories = attributes.Directories;
            Convention = attributes.Convention;
        }

        /// <summary>
        ///     Copies font properties from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void Set(IDotGraphFontAttributes attributes)
        {
            Set(attributes.Name, attributes.Size, attributes.Color, attributes.Directories);
        }
    }
}