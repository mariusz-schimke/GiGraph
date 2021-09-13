using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public class DotEdgeHyperlinkAttributes : DotHyperlinkAttributes<IDotEdgeHyperlinkAttributes, DotEdgeHyperlinkAttributes>, IDotEdgeHyperlinkAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> EdgeHyperlinkAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeHyperlinkAttributes, IDotEdgeHyperlinkAttributes>().BuildLazy();

        protected DotEdgeHyperlinkAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeHyperlinkAttributesKeyLookup)
        {
        }

        /// <summary>
        ///     If defined, this is the link used for the non-label parts of the edge (svg, map only). Used near the head or the tail node,
        ///     unless overridden by the <see cref="IDotHyperlinkAttributes.Url" /> on the head
        ///     <see cref="IDotEdgeHeadRootAttributes.Hyperlink" /> attributes, or on the tail
        ///     <see cref="IDotEdgeTailRootAttributes.Hyperlink" /> attributes of the edge. This value overrides any
        ///     <see cref="IDotHyperlinkAttributes.Url" /> specified for the edge's <see cref="IDotEdgeRootAttributes.Hyperlink" />.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.EdgeUrl)]
        public override DotEscapeString Url
        {
            get => base.Url;
            set => base.Url = value;
        }

        /// <summary>
        ///     Synonym for <see cref="Url" /> (svg, map only).
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.EdgeHref)]
        public override DotEscapeString Href
        {
            get => base.Href;
            set => base.Href = value;
        }

        /// <summary>
        ///     If <see cref="Url" /> is specified, or if the edge has a <see cref="IDotEdgeRootAttributes.Hyperlink" />
        ///     <see cref="IDotHyperlinkAttributes.Url" /> attribute specified, determines which window of the browser is used for the URL
        ///     attached to the non-label part of the edge (svg, map only). Setting it to <see cref="DotHyperlinkTargets.NewWindow" /> will
        ///     open a new window if it doesn't already exist, or reuse it if it does. If undefined, the value of the edge's
        ///     <see cref="IDotEdgeRootAttributes.Hyperlink" /> <see cref="IDotHyperlinkAttributes.Target" /> is used.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.EdgeTarget)]
        public override DotEscapeString Target
        {
            get => base.Target;
            set => base.Target = value;
        }

        /// <summary>
        ///     Tooltip annotation attached to the non-label part of the edge (svg, cmap only). This is used only if <see cref="Url" /> is
        ///     specified, or if the edge has a <see cref="IDotEdgeRootAttributes.Hyperlink" /> <see cref="IDotHyperlinkAttributes.Url" />
        ///     specified.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.EdgeTooltip)]
        public virtual DotEscapeString Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
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

        protected virtual void SetAll(DotEscapeString url, DotEscapeString target, DotEscapeString href, DotEscapeString tooltip)
        {
            Tooltip = tooltip;
            base.SetAll(url, target, href);
        }

        /// <summary>
        ///     Specifies hyperlink attributes.
        /// </summary>
        /// <param name="attributes">
        ///     The attributes to set.
        /// </param>
        public virtual void Set(DotEdgeHyperlink attributes)
        {
            Tooltip = attributes.Tooltip;
            base.Set(attributes);
        }

        /// <summary>
        ///     Copies hyperlink attributes from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the attributes from.
        /// </param>
        public virtual void Set(IDotEdgeHyperlinkAttributes attributes)
        {
            SetAll(attributes.Url, attributes.Target, attributes.Href, attributes.Tooltip);
        }
    }
}