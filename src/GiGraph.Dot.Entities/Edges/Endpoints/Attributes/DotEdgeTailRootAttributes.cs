using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes
{
    public class DotEdgeTailRootAttributes : DotEntityAttributesAccessor<IDotEdgeEndpointAttributes>, IDotEdgeTailRootAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> EdgeTailRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeTailRootAttributes, IDotEdgeEndpointAttributes>().BuildLazy();
        protected readonly DotEdgeTailHyperlinkAttributes _hyperlinkAttributes;

        protected DotEdgeTailRootAttributes(
            DotAttributeCollection attributes,
            Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
            DotEdgeTailHyperlinkAttributes hyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup)
        {
            _hyperlinkAttributes = hyperlinkAttributes;
        }

        public DotEdgeTailRootAttributes(DotAttributeCollection attributes)
            : this(attributes, EdgeTailRootAttributesKeyLookup, new DotEdgeTailHyperlinkAttributes(attributes))
        {
        }

        [DotAttributeKey(DotAttributeKeys.TailLabel)]
        DotLabel IDotEdgeEndpointAttributes.Label
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.TailClip)]
        bool? IDotEdgeEndpointAttributes.ClipToNodeBoundary
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.SameTail)]
        string IDotEdgeEndpointAttributes.GroupName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.TailPort)]
        DotEndpointPort IDotEdgeEndpointAttributes.Port
        {
            get => GetValueAsEndpointPort(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.LTail)]
        DotClusterId IDotEdgeEndpointAttributes.ClusterId
        {
            get => GetValueAsClusterId(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.ArrowTail)]
        DotArrowheadDefinition IDotEdgeEndpointAttributes.Arrowhead
        {
            get => GetValueAsArrowheadDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        DotEdgeTailHyperlinkAttributes IDotEdgeTailRootAttributes.Hyperlink => _hyperlinkAttributes;
    }
}