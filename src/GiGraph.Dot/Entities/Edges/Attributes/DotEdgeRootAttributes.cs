using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public class DotEdgeRootAttributes : DotEntityRootCommonAttributes<IDotEdgeAttributes, DotEdgeRootAttributes>, IDotEdgeRootAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeRootAttributes, IDotEdgeAttributes>().BuildLazy();

    public DotEdgeRootAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new(attributes), new(attributes), new(attributes), new(attributes),
            new(attributes), new(attributes), new(attributes), new(attributes), new(attributes)
        )
    {
    }

    protected DotEdgeRootAttributes(
        DotAttributeCollection attributes,
        Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotEdgeHeadAttributes headAttributes,
        DotEdgeTailAttributes tailAttributes,
        DotFontAttributes fontAttributes,
        DotHyperlinkAttributes hyperlinkAttributes,
        DotEdgeEndpointLabelsAttributes endpointLabelsAttributes,
        DotEdgeLabelHyperlinkAttributes labelHyperlinkAttributes,
        DotEdgeHyperlinkAttributes edgeHyperlinkAttributes,
        DotEdgeStyleAttributeOptions edgeStyleAttributeOptions,
        DotSvgStyleSheetAttributes svgStyleSheetAttributes
    )
        : base(attributes, attributeKeyLookup, hyperlinkAttributes)
    {
        Head = headAttributes;
        Tail = tailAttributes;
        Font = fontAttributes;
        Style = edgeStyleAttributeOptions;
        SvgStyleSheet = svgStyleSheetAttributes;
        EndpointLabels = endpointLabelsAttributes;
        EdgeHyperlink = edgeHyperlinkAttributes;
        LabelHyperlink = labelHyperlinkAttributes;
    }

    public DotEdgeHeadAttributes Head { get; }
    public DotEdgeTailAttributes Tail { get; }

    public DotFontAttributes Font { get; }
    public DotEdgeEndpointLabelsAttributes EndpointLabels { get; }
    public DotEdgeHyperlinkAttributes EdgeHyperlink { get; }
    public DotEdgeLabelHyperlinkAttributes LabelHyperlink { get; }
    public DotEdgeStyleAttributeOptions Style { get; }
    public DotSvgStyleSheetAttributes SvgStyleSheet { get; }

    [DotAttributeKey(DotStyleAttributeOptions.StyleKey)]
    DotStyles? IDotEdgeAttributes.Style
    {
        get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    [DotAttributeKey(DotAttributeKeys.Comment)]
    public virtual string? Comment
    {
        get => GetValueAsString(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.Tooltip)]
    public virtual DotEscapeString? Tooltip
    {
        get => GetValueAsEscapeString(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.Color)]
    public virtual DotColorDefinition? Color
    {
        get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.FillColor)]
    public virtual DotColorDefinition? FillColor
    {
        get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.XLabel)]
    public virtual DotLabel? ExternalLabel
    {
        get => GetValueAsLabel(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.PenWidth)]
    public virtual double? Width
    {
        get => GetValueAsDouble(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.Weight)]
    public virtual double? Weight
    {
        get => GetValueAsDouble(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.Len)]
    public virtual double? Length
    {
        get => GetValueAsDouble(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.MinLen)]
    public virtual int? MinLength
    {
        get => GetValueAsInt(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.ArrowSize)]
    public virtual double? ArrowheadScaleFactor
    {
        get => GetValueAsDouble(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.Dir)]
    public virtual DotEdgeDirections? Directions
    {
        get => GetValueAs<DotEdgeDirections>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    [DotAttributeKey(DotAttributeKeys.Decorate)]
    public virtual bool? AttachLabel
    {
        get => GetValueAsBool(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.LabelFloat)]
    public virtual bool? AllowLabelFloating
    {
        get => GetValueAsBool(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.Constraint)]
    public virtual bool? Constrain
    {
        get => GetValueAsBool(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }
}