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
    public class DotEdgeHeadRootAttributes : DotEntityAttributes<IDotEdgeEndpointAttributes>, IDotEdgeHeadRootAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> EdgeHeadRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeHeadRootAttributes, IDotEdgeEndpointAttributes>().BuildLazy();
        protected readonly DotEdgeHeadHyperlinkAttributes _hyperlinkAttributes;

        protected DotEdgeHeadRootAttributes(
            DotAttributeCollection attributes,
            Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
            DotEdgeHeadHyperlinkAttributes hyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup)
        {
            _hyperlinkAttributes = hyperlinkAttributes;
        }

        public DotEdgeHeadRootAttributes(DotAttributeCollection attributes)
            : this(attributes, EdgeHeadRootAttributesKeyLookup, new DotEdgeHeadHyperlinkAttributes(attributes))
        {
        }

        [DotAttributeKey(DotAttributeKeys.HeadLabel)]
        DotLabel IDotEdgeEndpointAttributes.Label
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.HeadClip)]
        bool? IDotEdgeEndpointAttributes.ClipToNodeBoundary
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.SameHead)]
        string IDotEdgeEndpointAttributes.GroupName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.HeadPort)]
        DotEndpointPort IDotEdgeEndpointAttributes.Port
        {
            get => GetValueAsEndpointPort(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.LHead)]
        DotClusterId IDotEdgeEndpointAttributes.ClusterId
        {
            get => GetValueAsClusterId(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Arrowhead)]
        DotArrowheadDefinition IDotEdgeEndpointAttributes.Arrowhead
        {
            get => GetValueAsArrowheadDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        DotEdgeHeadHyperlinkAttributes IDotEdgeHeadRootAttributes.Hyperlink => _hyperlinkAttributes;
    }
}