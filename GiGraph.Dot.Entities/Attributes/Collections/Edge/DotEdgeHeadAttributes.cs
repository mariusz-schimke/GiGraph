using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Metadata;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    // TODO: upewnić się, że w VS właściwości przesłonięte mają komentarze (podobnie te z interfejsów)
    public class DotEdgeHeadAttributes : DotEdgeEndpointAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeHeadAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeHeadAttributes, IDotEdgeEndpointAttributes>().Build();

        protected DotEdgeHeadAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEdgeHeadHyperlinkAttributes edgeHeadHyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup, edgeHeadHyperlinkAttributes)
        {
        }

        public DotEdgeHeadAttributes(DotAttributeCollection attributes)
            : this(attributes, EdgeHeadAttributesKeyLookup, new DotEdgeHeadHyperlinkAttributes(attributes))
        {
        }

        [DotAttributeKey(DotAttributeKeys.HeadLabel)]
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        [DotAttributeKey(DotAttributeKeys.HeadClip)]
        public override bool? ClipToNodeBoundary
        {
            get => base.ClipToNodeBoundary;
            set => base.ClipToNodeBoundary = value;
        }

        [DotAttributeKey(DotAttributeKeys.SameHead)]
        public override string GroupName
        {
            get => base.GroupName;
            set => base.GroupName = value;
        }

        [DotAttributeKey(DotAttributeKeys.HeadPort)]
        public override DotEndpointPort Port
        {
            get => base.Port;
            set => base.Port = value;
        }

        [DotAttributeKey(DotAttributeKeys.LHead)]
        public override string ClusterId
        {
            get => base.ClusterId;
            set => base.ClusterId = value;
        }

        [DotAttributeKey(DotAttributeKeys.Arrowhead)]
        public override DotArrowheadDefinition Arrowhead
        {
            get => base.Arrowhead;
            set => base.Arrowhead = value;
        }
    }
}