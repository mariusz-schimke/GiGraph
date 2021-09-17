using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes
{
    public abstract class DotEdgeEndpointAttributes : DotEntityAttributes<IDotEdgeEndpointAttributes, DotEdgeEndpointAttributes>, IDotEdgeEndpointRootAttributes
    {
        protected DotEdgeEndpointAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
            DotEdgeEndpointHyperlinkAttributes hyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup)
        {
            Hyperlink = hyperlinkAttributes;
        }

        /// <inheritdoc cref="IDotEdgeEndpointRootAttributes.Hyperlink" />
        public virtual DotEdgeEndpointHyperlinkAttributes Hyperlink { get; }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Label" />
        public virtual DotLabel Label
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClipToNodeBoundary" />
        public virtual bool? ClipToNodeBoundary
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.GroupName" />
        public virtual string GroupName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Port" />
        public virtual DotEndpointPort Port
        {
            get => GetValueAsEndpointPort(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClusterId" />
        public virtual DotClusterId ClusterId
        {
            get => GetValueAsClusterId(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Arrowhead" />
        public virtual DotArrowheadDefinition Arrowhead
        {
            get => GetValueAsArrowheadDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}