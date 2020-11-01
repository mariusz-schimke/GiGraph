using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
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

        [DotAttributeKey(DotAttributeKeys.FontPath)]
        public virtual string Directories
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
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
        /// <param name="directories">
        ///     The directory to search for fonts.
        /// </param>
        public virtual void Set(double? size = null, DotColor color = null, string name = null, string directories = null)
        {
            Directories = directories;
            base.Set(size, color, name);
        }

        /// <summary>
        ///     Sets font properties.
        /// </summary>
        /// <param name="attributes">
        ///     The properties to set.
        /// </param>
        public virtual void Set(DotGraphFont attributes)
        {
            Directories = attributes.Directories;
            base.Set(attributes);
        }
    }
}