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

public partial class DotEdgeRootAttributes : DotEntityRootCommonAttributes<IDotEdgeAttributes, DotEdgeRootAttributes>, IDotEdgeRootAttributes
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

    // todo: can't handle implicit implementation
    [DotAttributeKey(DotStyleAttributeOptions.StyleKey)]
    partial DotStyles? IDotEdgeAttributes.Style { get; set; }

    [DotAttributeKey(DotAttributeKeys.Comment)]
    public virtual partial string? Comment { get; set; }

    [DotAttributeKey(DotAttributeKeys.Tooltip)]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    [DotAttributeKey(DotAttributeKeys.Color)]
    public virtual partial DotColorDefinition? Color { get; set; }

    [DotAttributeKey(DotAttributeKeys.FillColor)]
    public virtual partial DotColorDefinition? FillColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.XLabel)]
    public virtual partial DotLabel? ExternalLabel { get; set; }

    [DotAttributeKey(DotAttributeKeys.PenWidth)]
    public virtual partial double? Width { get; set; }

    [DotAttributeKey(DotAttributeKeys.Weight)]
    public virtual partial double? Weight { get; set; }

    [DotAttributeKey(DotAttributeKeys.Len)]
    public virtual partial double? Length { get; set; }

    [DotAttributeKeyAttribute(DotAttributeKeys.MinLen)]
    public virtual partial int? MinLength { get; set; }

    [DotAttributeKey(DotAttributeKeys.ArrowSize)]
    public virtual partial double? ArrowheadScaleFactor { get; set; }

    [DotAttributeKey(DotAttributeKeys.Dir)]
    public virtual partial DotEdgeDirections? Directions { get; set; }

    [DotAttributeKey(DotAttributeKeys.Decorate)]
    public virtual partial bool? AttachLabel { get; set; }

    [DotAttributeKey(DotAttributeKeys.LabelFloat)]
    public virtual partial bool? AllowLabelFloating { get; set; }

    [DotAttributeKey(DotAttributeKeys.Constraint)]
    public virtual partial bool? Constrain { get; set; }
}