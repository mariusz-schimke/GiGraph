using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeTailAttributes : DotEdgeEndpointAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeTailAttributesLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeTailAttributes, IDotEdgeEndpointAttributes>().Build();

        protected DotEdgeTailAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEdgeTailHyperlinkAttributes edgeTailHyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup, edgeTailHyperlinkAttributes)
        {
        }

        public DotEdgeTailAttributes(DotAttributeCollection attributes)
            : this(attributes, EdgeTailAttributesLookup, new DotEdgeTailHyperlinkAttributes(attributes))
        {
        }

        /// <summary>
        ///     Hyperlink properties of the tail of the edge. If defined, the hyperlink is output as part of the tail's <see cref="Label" />.
        ///     Also, this value is used near the tail, overriding hyperlink properties set on the edge.
        /// </summary>
        public virtual DotEdgeTailHyperlinkAttributes Hyperlink => (DotEdgeTailHyperlinkAttributes) _hyperlink;

        /// <inheritdoc />
        [DotAttributeKey(DotAttributeKeys.TailLabel)]
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        /// <inheritdoc />
        [DotAttributeKey(DotAttributeKeys.TailClip)]
        public override bool? ClipToNodeBoundary
        {
            get => base.ClipToNodeBoundary;
            set => base.ClipToNodeBoundary = value;
        }

        /// <inheritdoc />
        [DotAttributeKey(DotAttributeKeys.SameTail)]
        public override string GroupName
        {
            get => base.GroupName;
            set => base.GroupName = value;
        }

        /// <inheritdoc />
        [DotAttributeKey(DotAttributeKeys.TailPort)]
        public override DotEndpointPort Port
        {
            get => base.Port;
            set => base.Port = value;
        }

        /// <inheritdoc />
        [DotAttributeKey(DotAttributeKeys.LTail)]
        public override string ClusterId
        {
            get => base.ClusterId;
            set => base.ClusterId = value;
        }

        /// <inheritdoc />
        [DotAttributeKey(DotAttributeKeys.ArrowTail)]
        public override DotArrowheadDefinition Arrowhead
        {
            get => base.Arrowhead;
            set => base.Arrowhead = value;
        }
    }
}