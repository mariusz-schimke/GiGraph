using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public class DotEdgeEndpointLabelsAttributes : DotEntityAttributesWithMetadata<IDotEdgeEndpointLabelsAttributes, DotEdgeEndpointLabelsAttributes>, IDotEdgeEndpointLabelsAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeEndpointLabelsAttributes, IDotEdgeEndpointLabelsAttributes>().BuildLazy();

    public DotEdgeEndpointLabelsAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new(attributes))
    {
    }

    protected DotEdgeEndpointLabelsAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotEdgeEndpointLabelsFontAttributes fontAttributes
    )
        : base(attributes, attributeKeyLookup)
    {
        Font = fontAttributes;
    }

    /// <summary>
    ///     Font attributes used for labels of the head and of the tail of the edge. If not set, default to font attributes specified for
    ///     the edge.
    /// </summary>
    public DotEdgeEndpointLabelsFontAttributes Font { get; }

    /// <inheritdoc cref="IDotEdgeEndpointLabelsAttributes.Distance" />
    [DotAttributeKey(DotAttributeKeys.LabelDistance)]
    public virtual double? Distance
    {
        get => GetValueAsDouble(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    /// <inheritdoc cref="IDotEdgeEndpointLabelsAttributes.Angle" />
    [DotAttributeKey(DotAttributeKeys.LabelAngle)]
    public virtual double? Angle
    {
        get => GetValueAsDouble(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }
}