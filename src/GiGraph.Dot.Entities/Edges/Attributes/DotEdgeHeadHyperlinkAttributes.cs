using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public class DotEdgeHeadHyperlinkAttributes : DotEdgeHyperlinkAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeHeadHyperlinkAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeHeadHyperlinkAttributes, IDotEdgeHyperlinkAttributes>().Build();

        protected DotEdgeHeadHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeHeadHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeHeadHyperlinkAttributesKeyLookup)
        {
        }

        /// <summary>
        ///     If defined, it is output as part of the head <see cref="DotEdgeHeadAttributes.Label" /> of the edge (svg, map only). Also,
        ///     this value is used near the head node, overriding any <see cref="IDotEdgeAttributesRoot.Hyperlink" />
        ///     <see cref="IDotHyperlinkAttributes.Url" /> set for the edge.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.HeadUrl)]
        public override DotEscapeString Url
        {
            get => base.Url;
            set => base.Url = value;
        }

        /// <summary>
        ///     Synonym for <see cref="Url" /> (svg, map only).
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.HeadHref)]
        public override DotEscapeString Href
        {
            get => base.Href;
            set => base.Href = value;
        }

        /// <summary>
        ///     If <see cref="Url" /> is specified, this attribute determines which window of the browser is used for the URL (svg, map
        ///     only). Setting it to <see cref="DotHyperlinkTargets.NewWindow" /> will open a new window if it doesn't already exist, or
        ///     reuse it if it does. If undefined, the value of the edge's <see cref="IDotEdgeAttributesRoot.Hyperlink" />
        ///     <see cref="IDotHyperlinkAttributes.Target" /> is used.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.HeadTarget)]
        public override DotEscapeString Target
        {
            get => base.Target;
            set => base.Target = value;
        }

        /// <summary>
        ///     Tooltip annotation attached to the head of an edge (svg, cmap only). This is used only if <see cref="Url" /> is specified.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.HeadTooltip)]
        public override DotEscapeString Tooltip
        {
            get => base.Tooltip;
            set => base.Tooltip = value;
        }
    }
}