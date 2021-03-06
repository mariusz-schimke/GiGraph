using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Types.Hyperlinks;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeLabelHyperlinkAttributes : DotEdgeHyperlinkAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeLabelHyperlinkAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeLabelHyperlinkAttributes, IDotEdgeHyperlinkAttributes>().Build();

        protected DotEdgeLabelHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeLabelHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeLabelHyperlinkAttributesKeyLookup)
        {
        }

        /// <summary>
        ///     If defined, this is the link used for the label of the edge (svg, map only). This value overrides any
        ///     <see cref="DotEntityRootCommonAttributes{TIEntityAttributeProperties}.Hyperlink" />
        ///     <see cref="DotHyperlinkAttributes{TIEntityHyperlinkAttributes}.Url" /> defined for the edge.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.LabelUrl)]
        public override DotEscapeString Url
        {
            get => base.Url;
            set => base.Url = value;
        }

        /// <summary>
        ///     Synonym for <see cref="Url" /> (svg, map only).
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.LabelHref)]
        public override DotEscapeString Href
        {
            get => base.Href;
            set => base.Href = value;
        }

        /// <summary>
        ///     If <see cref="Url" /> is specified, or if the edge has a
        ///     <see cref="DotEntityRootCommonAttributes{TIEntityAttributeProperties}.Hyperlink" />
        ///     <see cref="DotHyperlinkAttributes{TIEntityHyperlinkAttributes}.Url" /> specified, this attribute determines which window of
        ///     the browser is used for the URL attached to the label (svg, map only). Setting it to
        ///     <see cref="DotHyperlinkTargets.NewWindow" /> will open a new window if it doesn't already exist, or reuse it if it does. If
        ///     undefined, the value of the edge's <see cref="DotEntityRootCommonAttributes{TIEntityAttributeProperties}.Hyperlink" />
        ///     <see cref="DotHyperlinkAttributes{TIEntityHyperlinkAttributes}.Target" /> is used.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.LabelTarget)]
        public override DotEscapeString Target
        {
            get => base.Target;
            set => base.Target = value;
        }

        /// <summary>
        ///     Tooltip annotation attached to the label of the edge (svg, cmap only). This is used only if <see cref="Url" /> is specified,
        ///     or if the edge has a <see cref="DotEntityRootCommonAttributes{TIEntityAttributeProperties}.Hyperlink" />
        ///     <see cref="DotHyperlinkAttributes{TIEntityHyperlinkAttributes}.Url" /> specified.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.LabelTooltip)]
        public override DotEscapeString Tooltip
        {
            get => base.Tooltip;
            set => base.Tooltip = value;
        }
    }
}