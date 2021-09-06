using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public class DotEdgeTailRootAttributes : DotEdgeEndpointRootAttributes, IDotEdgeTailRootAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeTailAttributesLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeTailRootAttributes, IDotEdgeEndpointAttributes>().Build();

        protected DotEdgeTailRootAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEdgeTailHyperlinkAttributes edgeTailHyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup, edgeTailHyperlinkAttributes)
        {
        }

        public DotEdgeTailRootAttributes(DotAttributeCollection attributes)
            : this(attributes, EdgeTailAttributesLookup, new DotEdgeTailHyperlinkAttributes(attributes))
        {
        }

        [DotAttributeKey(DotAttributeKeys.TailLabel)]
        protected override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        [DotAttributeKey(DotAttributeKeys.TailClip)]
        protected override bool? ClipToNodeBoundary
        {
            get => base.ClipToNodeBoundary;
            set => base.ClipToNodeBoundary = value;
        }

        [DotAttributeKey(DotAttributeKeys.SameTail)]
        protected override string GroupName
        {
            get => base.GroupName;
            set => base.GroupName = value;
        }

        [DotAttributeKey(DotAttributeKeys.TailPort)]
        protected override DotEndpointPort Port
        {
            get => base.Port;
            set => base.Port = value;
        }

        [DotAttributeKey(DotAttributeKeys.LTail)]
        protected override DotClusterId ClusterId
        {
            get => base.ClusterId;
            set => base.ClusterId = value;
        }

        [DotAttributeKey(DotAttributeKeys.ArrowTail)]
        protected override DotArrowheadDefinition Arrowhead
        {
            get => base.Arrowhead;
            set => base.Arrowhead = value;
        }

        DotEdgeTailHyperlinkAttributes IDotEdgeTailRootAttributes.Hyperlink => (DotEdgeTailHyperlinkAttributes) _hyperlink;
    }
}