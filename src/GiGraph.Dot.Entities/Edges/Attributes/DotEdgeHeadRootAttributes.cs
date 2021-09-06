using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public class DotEdgeHeadRootAttributes : DotEdgeEndpointRootAttributes, IDotEdgeHeadRootAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeHeadAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeHeadRootAttributes, IDotEdgeEndpointAttributes>().Build();

        protected DotEdgeHeadRootAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEdgeHeadHyperlinkAttributes edgeHeadHyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup, edgeHeadHyperlinkAttributes)
        {
        }

        public DotEdgeHeadRootAttributes(DotAttributeCollection attributes)
            : this(attributes, EdgeHeadAttributesKeyLookup, new DotEdgeHeadHyperlinkAttributes(attributes))
        {
        }

        [DotAttributeKey(DotAttributeKeys.HeadLabel)]
        protected override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        [DotAttributeKey(DotAttributeKeys.HeadClip)]
        protected override bool? ClipToNodeBoundary
        {
            get => base.ClipToNodeBoundary;
            set => base.ClipToNodeBoundary = value;
        }

        [DotAttributeKey(DotAttributeKeys.SameHead)]
        protected override string GroupName
        {
            get => base.GroupName;
            set => base.GroupName = value;
        }

        [DotAttributeKey(DotAttributeKeys.HeadPort)]
        protected override DotEndpointPort Port
        {
            get => base.Port;
            set => base.Port = value;
        }

        [DotAttributeKey(DotAttributeKeys.LHead)]
        protected override DotClusterId ClusterId
        {
            get => base.ClusterId;
            set => base.ClusterId = value;
        }

        [DotAttributeKey(DotAttributeKeys.Arrowhead)]
        protected override DotArrowheadDefinition Arrowhead
        {
            get => base.Arrowhead;
            set => base.Arrowhead = value;
        }

        DotEdgeHeadHyperlinkAttributes IDotEdgeHeadRootAttributes.Hyperlink => (DotEdgeHeadHyperlinkAttributes) _hyperlink;
    }
}