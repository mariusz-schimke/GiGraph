using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Hyperlinks;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
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
        ///     If defined, it is output as part of the <see cref="DotEdgeAttributes.Tail" /> <see cref="DotEdgeTailAttributes.Label" /> of
        ///     the edge (svg, map only). Also, this value is used near the tail node, overriding any
        ///     <see cref="DotEntityCommonAttributes{IDotEdgeAttributes}.Hyperlink" />
        ///     <see cref="DotEntityHyperlinkAttributes{TIEntityHyperlinkAttributes}.Url" /> set for the edge.
        /// </summary>
        [DotAttributeKey("tailURL")]
        public override DotEscapeString Url
        {
            get => base.Url;
            set => base.Url = value;
        }

        /// <summary>
        ///     Synonym for <see cref="Url" />.
        /// </summary>
        [DotAttributeKey("tailhref")]
        public override DotEscapeString Href
        {
            get => base.Href;
            set => base.Href = value;
        }

        /// <summary>
        ///     If <see cref="Url" /> is specified, this attribute determines which window of the browser is used for the URL. Setting it to
        ///     <see cref="DotHyperlinkTargets.NewWindow" /> will open a new window if it doesn't already exist, or reuse it if it does. If
        ///     undefined, the value of the edge's <see cref="DotEntityCommonAttributes{IDotEdgeAttributes}.Hyperlink" />
        ///     <see cref="DotEntityHyperlinkAttributes{TIEntityHyperlinkAttributes}.Target" /> is used.
        /// </summary>
        [DotAttributeKey("tailtarget")]
        public override DotEscapeString Target
        {
            get => base.Target;
            set => base.Target = value;
        }

        /// <summary>
        ///     Tooltip annotation attached to the tail of an edge. This is used only if <see cref="Url" /> is specified.
        /// </summary>
        [DotAttributeKey("tailtooltip")]
        public override DotEscapeString Tooltip
        {
            get => base.Tooltip;
            set => base.Tooltip = value;
        }
    }
}