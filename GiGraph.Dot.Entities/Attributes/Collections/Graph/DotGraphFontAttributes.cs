using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public class DotGraphFontAttributes : DotEntityFontAttributes<IDotGraphFontAttributes>, IDotGraphFontAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphFontAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotGraphFontAttributes));

        protected DotGraphFontAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotGraphFontAttributes(DotAttributeCollection attributes)
            : base(attributes, GraphFontAttributesKeyLookup)
        {
        }

        [DotAttributeKey("fontpath")]
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
    }
}