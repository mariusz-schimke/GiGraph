using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Hyperlinks;
using GiGraph.Dot.Entities.Types.Text;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeHyperlinkAttributes : DotHyperlinkAttributes<IDotEdgeHyperlinkAttributes>, IDotEdgeHyperlinkAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeHyperlinkAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeHyperlinkAttributes, IDotEdgeHyperlinkAttributes>().Build();

        protected DotEdgeHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeHyperlinkAttributesKeyLookup)
        {
        }

        /// <summary>
        ///     If defined, this is the link used for the non-label parts of the edge (svg, map only). Used near the head or the tail node,
        ///     unless overridden by the <see cref="DotEdgeHyperlinkAttributes.Url" /> on the <see cref="DotEdgeAttributes.Head" />
        ///     <see cref="DotEdgeHeadAttributes.Hyperlink" /> attributes, or on the <see cref="DotEdgeAttributes.Tail" />
        ///     <see cref="DotEdgeTailAttributes.Hyperlink" /> attributes of the edge. This value overrides any
        ///     <see cref="DotHyperlinkAttributes{TIEntityHyperlinkAttributes}.Url" /> specified for the edge's
        ///     <see cref="DotEntityRootCommonAttributes{TIEntityAttributeProperties}.Hyperlink" />.
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
        ///     If <see cref="Url" /> is specified, or if the edge has a
        ///     <see cref="DotEntityRootCommonAttributes{TIEntityAttributeProperties}.Hyperlink" />
        ///     <see cref="DotHyperlinkAttributes{TIEntityHyperlinkAttributes}.Url" /> attribute specified, determines which window of the
        ///     browser is used for the URL attached to the non-label part of the edge (svg, map only). Setting it to
        ///     <see cref="DotHyperlinkTargets.NewWindow" /> will open a new window if it doesn't already exist, or reuse it if it does. If
        ///     undefined, the value of the edge's <see cref="DotEntityRootCommonAttributes{TIEntityAttributeProperties}.Hyperlink" />
        ///     <see cref="DotHyperlinkAttributes{TIEntityHyperlinkAttributes}.Target" /> is used.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.EdgeTarget)]
        public override DotEscapeString Target
        {
            get => base.Target;
            set => base.Target = value;
        }

        /// <summary>
        ///     Tooltip annotation attached to the non-label part of the edge (svg, cmap only). This is used only if <see cref="Url" /> is
        ///     specified, or if the edge has a <see cref="DotEntityRootCommonAttributes{TIEntityAttributeProperties}.Hyperlink" />
        ///     <see cref="DotHyperlinkAttributes{TIEntityHyperlinkAttributes}.Url" /> specified.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.EdgeTooltip)]
        public virtual DotEscapeString Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
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

        protected virtual void SetAll(DotEscapeString url, DotEscapeString target, DotEscapeString href, DotEscapeString tooltip)
        {
            Tooltip = tooltip;
            base.SetAll(url, target, href);
        }

        /// <summary>
        ///     Specifies hyperlink properties.
        /// </summary>
        /// <param name="attributes">
        ///     The properties to set.
        /// </param>
        public virtual void Set(DotEdgeHyperlink attributes)
        {
            Tooltip = attributes.Tooltip;
            base.Set(attributes);
        }

        /// <summary>
        ///     Copies hyperlink properties from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void Set(IDotEdgeHyperlinkAttributes attributes)
        {
            SetAll(attributes.Url, attributes.Target, attributes.Href, attributes.Tooltip);
        }
    }
}