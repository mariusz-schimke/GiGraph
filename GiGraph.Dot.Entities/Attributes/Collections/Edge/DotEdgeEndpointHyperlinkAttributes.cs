using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Hyperlinks;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public abstract class DotEdgeEndpointHyperlinkAttributes : DotEntityHyperlinkAttributes<IDotEdgeEndpointHyperlinkAttributes>
    {
        protected DotEdgeEndpointHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public virtual DotEscapeString Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        /// <summary>
        ///     Specifies hyperlink attributes.
        /// </summary>
        /// <param name="url">
        ///     The URL of the hyperlink.
        /// </param>
        /// <param name="target">
        ///     The target of the hyperlink. See <see cref="DotHyperlinkTargets" /> for accepted values.
        /// </param>
        /// <param name="tooltip">
        ///     The tooltip of the hyperlink.
        /// </param>
        public virtual void Set(DotEscapeString url, DotEscapeString target = null, DotEscapeString tooltip = null)
        {
            Tooltip = tooltip;
            base.Set(url, target);
        }
    }
}