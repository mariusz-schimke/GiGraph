using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes
{
    public abstract class DotEdgeEndpointRootAttributes : DotEntityAttributes, IDotEdgeEndpointAttributes
    {
        protected DotEdgeEndpointRootAttributes(DotEntityAttributes source)
            : base(source)
        {
        }

        protected DotEdgeEndpointRootAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public abstract DotLabel Label { get; set; }
        public abstract DotEndpointPort Port { get; set; }
        public abstract DotClusterId ClusterId { get; set; }
        public abstract bool? ClipToNodeBoundary { get; set; }
        public abstract string GroupName { get; set; }
        public abstract DotArrowheadDefinition Arrowhead { get; set; }
    }
}