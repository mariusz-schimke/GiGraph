using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public class DotEdgeTailHyperlinkAttributes : DotEdgeHyperlinkAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeTailHyperlinkAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeTailHyperlinkAttributes, IDotEdgeHyperlinkAttributes>().Build();

        protected DotEdgeTailHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeTailHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeTailHyperlinkAttributesKeyLookup)
        {
        }

        /// <summary>
        ///     If defined, it is output as part of the tail <see cref="DotEdgeTailAttributes.Label" /> of the edge (svg, map only). Also,
        ///     this value is used near the tail node, overriding any <see cref="IDotEdgeRootAttributes.Hyperlink" />
        ///     <see cref="IDotHyperlinkAttributes.Url" /> set for the edge.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.TailUrl)]
        public override DotEscapeString Url
        {
            get => base.Url;
            set => base.Url = value;
        }

        /// <summary>
        ///     Synonym for <see cref="Url" /> (svg, map only).
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.TailHref)]
        public override DotEscapeString Href
        {
            get => base.Href;
            set => base.Href = value;
        }

        /// <summary>
        ///     If <see cref="Url" /> is specified, this attribute determines which window of the browser is used for the URL (svg, map
        ///     only). Setting it to <see cref="DotHyperlinkTargets.NewWindow" /> will open a new window if it doesn't already exist, or
        ///     reuse it if it does. If undefined, the value of the edge's <see cref="IDotEdgeRootAttributes.Hyperlink" />
        ///     <see cref="IDotHyperlinkAttributes.Target" /> is used.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.TailTarget)]
        public override DotEscapeString Target
        {
            get => base.Target;
            set => base.Target = value;
        }

        /// <summary>
        ///     Tooltip annotation attached to the tail of an edge (svg, cmap only). This is used only if <see cref="Url" /> is specified.
        /// </summary>
        [DotAttributeKey(DotAttributeKeys.TailTooltip)]
        public override DotEscapeString Tooltip
        {
            get => base.Tooltip;
            set => base.Tooltip = value;
        }
    }
}