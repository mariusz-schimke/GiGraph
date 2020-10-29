using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Hyperlinks;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeHyperlinkAttributes : DotEntityHyperlinkAttributes<IDotEdgeHyperlinkAttributes>, IDotEdgeHyperlinkAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeHyperlinkAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEdgeHyperlinkAttributes));

        protected DotEdgeHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeHyperlinkAttributesKeyLookup)
        {
        }

        /// <summary>
        ///     If defined, this is the link used for the non-label parts of the edge. This value overrides any URL specified for the edge.
        ///     Also, this value is used near the head or the tail node, unless overridden by their own head or tail URL attributes.
        /// </summary>
        [DotAttributeKey("edgeURL")]
        public override DotEscapeString Url
        {
            get => base.Url;
            set => base.Url = value;
        }

        /// <summary>
        ///     Synonym for <see cref="Url" />.
        /// </summary>
        [DotAttributeKey("edgehref")]
        public override DotEscapeString Href
        {
            get => base.Href;
            set => base.Href = value;
        }

        /// <summary>
        ///     If <see cref="Url" /> is specified, or if the edge has a hyperlink <see cref="DotEntityHyperlinkAttributes.Url" /> attribute
        ///     specified, determines which window of the browser is used for the URL attached to the non-label part of the edge. Setting it
        ///     to <see cref="DotHyperlinkTargets.NewWindow" /> will open a new window if it doesn't already exist, or reuse it if it does.
        ///     If undefined, the value of the edge's hyperlink target is used.
        /// </summary>
        [DotAttributeKey("edgetarget")]
        public override DotEscapeString Target
        {
            get => base.Target;
            set => base.Target = value;
        }

        /// <summary>
        ///     Tooltip annotation attached to the non-label part of the edge. This is used only if <see cref="Url" /> is specified, or if
        ///     the edge has a hyperlink <see cref="DotEntityHyperlinkAttributes.Url" /> attribute specified.
        /// </summary>
        [DotAttributeKey("edgetooltip")]
        public virtual DotEscapeString Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        /// <summary>
        ///     Specifies hyperlink properties.
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

        /// <summary>
        ///     Specifies hyperlink properties.
        /// </summary>
        /// <param name="attributes">
        ///     The properties to set.
        /// </param>
        public virtual void Set(IDotEdgeHyperlinkAttributes attributes)
        {
            Set(attributes.Url, attributes.Target, attributes.Tooltip);
        }
    }
}