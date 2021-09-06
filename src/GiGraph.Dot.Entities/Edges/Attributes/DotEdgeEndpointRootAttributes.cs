using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public abstract class DotEdgeEndpointRootAttributes : DotEntityAttributes<IDotEdgeEndpointAttributes>, IDotEdgeEndpointAttributes
    {
        protected readonly DotEdgeHyperlinkAttributes _hyperlink;

        protected DotEdgeEndpointRootAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEdgeHyperlinkAttributes hyperlink
        )
            : base(attributes, attributeKeyLookup)
        {
            _hyperlink = hyperlink;
        }

        protected virtual DotLabel Label
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        protected virtual bool? ClipToNodeBoundary
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        protected virtual string GroupName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        protected virtual DotEndpointPort Port
        {
            get => GetValueAsEndpointPort(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        protected virtual DotClusterId ClusterId
        {
            get => GetValueAsClusterId(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        protected virtual DotArrowheadDefinition Arrowhead
        {
            get => GetValueAsArrowheadDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        DotLabel IDotEdgeEndpointAttributes.Label
        {
            get => Label;
            set => Label = value;
        }

        DotEndpointPort IDotEdgeEndpointAttributes.Port
        {
            get => Port;
            set => Port = value;
        }

        DotClusterId IDotEdgeEndpointAttributes.ClusterId
        {
            get => ClusterId;
            set => ClusterId = value;
        }

        bool? IDotEdgeEndpointAttributes.ClipToNodeBoundary
        {
            get => ClipToNodeBoundary;
            set => ClipToNodeBoundary = value;
        }

        string IDotEdgeEndpointAttributes.GroupName
        {
            get => GroupName;
            set => GroupName = value;
        }

        DotArrowheadDefinition IDotEdgeEndpointAttributes.Arrowhead
        {
            get => Arrowhead;
            set => Arrowhead = value;
        }
    }
}