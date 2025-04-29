using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphRootAttributes : DotEntityAttributesWithMetadata<IDotGraphAttributes, DotGraphRootAttributes>, IDotGraphRootAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphRootAttributes, IDotGraphAttributes>().BuildLazy();

    public DotGraphRootAttributes(DotAttributeCollection attributes)
        : this(
            attributes,
            AttributeKeyLookup,
            new DotGraphClustersAttributes(attributes),
            new DotGraphStyleAttributes(attributes),
            new DotHyperlinkAttributes(attributes),
            new DotGraphFontAttributes(attributes),
            new DotGraphSvgStyleSheetAttributes(attributes),
            new DotGraphLayoutAttributes(attributes),
            new DotGraphCanvasAttributes(attributes),
            new DotLabelOptionsAttributes(attributes)
        )
    {
    }

    protected DotGraphRootAttributes(
        DotAttributeCollection attributes,
        Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotGraphClustersAttributes clusterAttributes,
        DotGraphStyleAttributes styleAttributes,
        DotHyperlinkAttributes hyperlinkAttributes,
        DotGraphFontAttributes fontAttributes,
        DotGraphSvgStyleSheetAttributes svgStyleSheetAttributes,
        DotGraphLayoutAttributes layoutAttributes,
        DotGraphCanvasAttributes canvasAttributes,
        DotLabelOptionsAttributes labelOptionsAttributes
    )
        : base(attributes, attributeKeyLookup)
    {
        Clusters = clusterAttributes;
        Style = styleAttributes;
        Font = fontAttributes;
        SvgStyleSheet = svgStyleSheetAttributes;
        Layout = layoutAttributes;
        Canvas = canvasAttributes;
        LabelOptions = labelOptionsAttributes;
        Hyperlink = hyperlinkAttributes;
    }

    /// <inheritdoc cref="IDotGraphRootAttributes.Clusters"/>
    public DotGraphClustersAttributes Clusters { get; }

    /// <inheritdoc cref="IDotGraphRootAttributes.Style"/>
    public DotGraphStyleAttributes Style { get; }

    /// <inheritdoc cref="IDotGraphRootAttributes.Font"/>
    public DotGraphFontAttributes Font { get; }

    /// <inheritdoc cref="IDotGraphRootAttributes.SvgStyleSheet"/>
    public DotGraphSvgStyleSheetAttributes SvgStyleSheet { get; }

    /// <inheritdoc cref="IDotGraphRootAttributes.Layout"/>
    public DotGraphLayoutAttributes Layout { get; }

    /// <inheritdoc cref="IDotGraphRootAttributes.Canvas"/>
    public DotGraphCanvasAttributes Canvas { get; }

    /// <inheritdoc cref="IDotGraphRootAttributes.LabelOptions"/>
    public DotLabelOptionsAttributes LabelOptions { get; }

    /// <inheritdoc cref="IDotGraphRootAttributes.Hyperlink"/>
    public DotHyperlinkAttributes Hyperlink { get; }

    /// <inheritdoc cref="IDotGraphAttributes.Label"/>
    [DotAttributeKey(DotAttributeKeys.Label)]
    public virtual partial DotLabel? Label { get; set; }

    /// <inheritdoc cref="IDotGraphAttributes.Comment"/>
    [DotAttributeKey(DotAttributeKeys.Comment)]
    public virtual partial string? Comment { get; set; }

    /// <inheritdoc cref="IDotGraphAttributes.Charset"/>
    [DotAttributeKey(DotAttributeKeys.Charset)]
    public virtual partial string? Charset { get; set; }

    /// <inheritdoc cref="IDotGraphAttributes.ImageDirectories"/>
    [DotAttributeKey(DotAttributeKeys.ImagePath)]
    public virtual partial string? ImageDirectories { get; set; }

    /// <inheritdoc cref="IDotGraphAttributes.Tooltip"/>
    [DotAttributeKey(DotAttributeKeys.Tooltip)]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    /// <inheritdoc cref="IDotGraphAttributes.ObjectId"/>
    [DotAttributeKey(DotAttributeKeys.Id)]
    public virtual partial DotEscapeString? ObjectId { get; set; }
}