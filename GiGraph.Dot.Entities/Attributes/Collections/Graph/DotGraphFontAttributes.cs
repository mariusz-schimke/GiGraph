using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Metadata;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Fonts;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public class DotGraphFontAttributes : DotEntityFontAttributes<IDotGraphFontAttributes>, IDotGraphFontAttributes
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
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
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
        public virtual void Set(string name = null, double? size = null, DotColor color = null, string directories = null)
        {
            base.Set(name, size, color);
            Directories = directories;
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
        }
        
        /// <summary>
        ///     Copies font properties from the specified instance.
        /// </summary>
        /// <param name="source">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void CopyFrom(IDotGraphFontAttributes source)
        {
            Set(source.Name, source.Size, source.Color, source.Directories);
        }
    }
}