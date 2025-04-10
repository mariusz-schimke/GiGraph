using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public partial class DotEdgeRootAttributes : DotEntityAttributesWithMetadata<IDotEdgeAttributes, DotEdgeRootAttributes>, IDotEdgeRootAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeRootAttributes, IDotEdgeAttributes>().BuildLazy();

    public DotEdgeRootAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new DotEdgeHeadAttributes(attributes), new DotEdgeTailAttributes(attributes), new DotFontAttributes(attributes), new DotHyperlinkAttributes(attributes),
            new DotEdgeEndpointLabelsAttributes(attributes), new DotEdgeLabelHyperlinkAttributes(attributes), new DotEdgeHyperlinkAttributes(attributes), new DotEdgeStyleAttributes(attributes),
            new DotSvgStyleSheetAttributes(attributes)
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
        DotEdgeStyleAttributes edgeStyleAttributes,
        DotSvgStyleSheetAttributes svgStyleSheetAttributes
    )
        : base(attributes, attributeKeyLookup)
    {
        Head = headAttributes;
        Tail = tailAttributes;
        Font = fontAttributes;
        Style = edgeStyleAttributes;
        SvgStyleSheet = svgStyleSheetAttributes;
        Hyperlink = hyperlinkAttributes;
        EndpointLabels = endpointLabelsAttributes;
        EdgeHyperlink = edgeHyperlinkAttributes;
        LabelHyperlink = labelHyperlinkAttributes;
    }

    /// <inheritdoc cref="IDotEdgeRootAttributes.Head"/>
    public DotEdgeHeadAttributes Head { get; }

    /// <inheritdoc cref="IDotEdgeRootAttributes.Tail"/>
    public DotEdgeTailAttributes Tail { get; }

    /// <inheritdoc cref="IDotEdgeRootAttributes.Font"/>
    public DotFontAttributes Font { get; }

    /// <inheritdoc cref="IDotEdgeRootAttributes.EndpointLabels"/>
    public DotEdgeEndpointLabelsAttributes EndpointLabels { get; }

    /// <inheritdoc cref="IDotEdgeRootAttributes.Hyperlink"/>
    public DotHyperlinkAttributes Hyperlink { get; }

    /// <inheritdoc cref="IDotEdgeRootAttributes.EdgeHyperlink"/>
    public DotEdgeHyperlinkAttributes EdgeHyperlink { get; }

    /// <inheritdoc cref="IDotEdgeRootAttributes.LabelHyperlink"/>
    public DotEdgeLabelHyperlinkAttributes LabelHyperlink { get; }

    /// <inheritdoc cref="IDotEdgeRootAttributes.Style"/>
    public DotEdgeStyleAttributes Style { get; }

    /// <inheritdoc cref="IDotEdgeRootAttributes.SvgStyleSheet"/>
    public DotSvgStyleSheetAttributes SvgStyleSheet { get; }

    [DotAttributeKey(DotAttributeKeys.Style)]
    DotStyles? IDotEdgeAttributes.Style
    {
        [DotAttributeKey(DotAttributeKeys.Style)]
        get => _attributes.GetValueAs(DotAttributeKeys.Style, out DotStyles? result) ? result : null;
        [DotAttributeKey(DotAttributeKeys.Style)]
        set => _attributes.SetValueOrRemove(DotAttributeKeys.Style, value);
    }

    /// <inheritdoc cref="IDotEdgeAttributes.Label"/>
    [DotAttributeKey(DotAttributeKeys.Label)]
    public virtual partial DotLabel? Label { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.Comment"/>
    [DotAttributeKey(DotAttributeKeys.Comment)]
    public virtual partial string? Comment { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.Tooltip"/>
    [DotAttributeKey(DotAttributeKeys.Tooltip)]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.ExternalLabel"/>
    [DotAttributeKey(DotAttributeKeys.XLabel)]
    public virtual partial DotLabel? ExternalLabel { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.Weight"/>
    [DotAttributeKey(DotAttributeKeys.Weight)]
    public virtual partial double? Weight { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.Length"/>
    [DotAttributeKey(DotAttributeKeys.Len)]
    public virtual partial double? Length { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.MinLength"/>
    [DotAttributeKey(DotAttributeKeys.MinLen)]
    public virtual partial int? MinLength { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.ArrowheadScaleFactor"/>
    [DotAttributeKey(DotAttributeKeys.ArrowSize)]
    public virtual partial double? ArrowheadScaleFactor { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.Directions"/>
    [DotAttributeKey(DotAttributeKeys.Dir)]
    public virtual partial DotEdgeDirections? Directions { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.DrawLabelConnector"/>
    [DotAttributeKey(DotAttributeKeys.Decorate)]
    public virtual partial bool? DrawLabelConnector { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.EnableLabelFloating"/>
    [DotAttributeKey(DotAttributeKeys.LabelFloat)]
    public virtual partial bool? EnableLabelFloating { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.DisableLabelJustification"/>
    [DotAttributeKey(DotAttributeKeys.NoJustify)]
    public virtual partial bool? DisableLabelJustification { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.IncludeInNodeRanking"/>
    [DotAttributeKey(DotAttributeKeys.Constraint)]
    public virtual partial bool? IncludeInNodeRanking { get; set; }

    /// <inheritdoc cref="IDotEdgeAttributes.ObjectId"/>
    [DotAttributeKey(DotAttributeKeys.Id)]
    public virtual partial DotEscapeString? ObjectId { get; set; }
}