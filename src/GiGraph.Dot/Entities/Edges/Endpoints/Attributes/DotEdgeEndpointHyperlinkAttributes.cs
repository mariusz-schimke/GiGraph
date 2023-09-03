using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Edges.Attributes;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

public abstract class DotEdgeEndpointHyperlinkAttributes : DotEdgeHyperlinkAttributes
{
    protected DotEdgeEndpointHyperlinkAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }
}