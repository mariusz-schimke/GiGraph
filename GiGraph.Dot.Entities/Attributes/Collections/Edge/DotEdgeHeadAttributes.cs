using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Identifiers;
using GiGraph.Dot.Entities.Types.Labels;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
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

        /// <summary>
        ///     Hyperlink properties of the head of the edge. If defined, the hyperlink is output as part of the head's <see cref="Label" />.
        ///     Also, this value is used near the head, overriding hyperlink properties set on the edge.
        /// </summary>
        public virtual DotEdgeHeadHyperlinkAttributes Hyperlink => (DotEdgeHeadHyperlinkAttributes) _hyperlink;

        /// <inheritdoc />
        [DotAttributeKey(DotAttributeKeys.HeadLabel)]
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        /// <inheritdoc />
        [DotAttributeKey(DotAttributeKeys.HeadClip)]
        public override bool? ClipToNodeBoundary
        {
            get => base.ClipToNodeBoundary;
            set => base.ClipToNodeBoundary = value;
        }

        /// <inheritdoc />
        [DotAttributeKey(DotAttributeKeys.SameHead)]
        public override string GroupName
        {
            get => base.GroupName;
            set => base.GroupName = value;
        }

        /// <inheritdoc />
        [DotAttributeKey(DotAttributeKeys.HeadPort)]
        public override DotEndpointPort Port
        {
            get => base.Port;
            set => base.Port = value;
        }

        /// <inheritdoc />
        [DotAttributeKey(DotAttributeKeys.LHead)]
        public override DotClusterId ClusterId
        {
            get => base.ClusterId;
            set => base.ClusterId = value;
        }

        /// <inheritdoc />
        [DotAttributeKey(DotAttributeKeys.Arrowhead)]
        public override DotArrowheadDefinition Arrowhead
        {
            get => base.Arrowhead;
            set => base.Arrowhead = value;
        }
    }
}