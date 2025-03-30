using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphRootAttributes : DotEntityAttributesWithMetadata<IDotGraphAttributes, DotGraphRootAttributes>, IDotGraphRootAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphRootAttributes, IDotGraphAttributes>().BuildLazy();

    public DotGraphRootAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new DotGraphClustersAttributes(attributes), new DotHyperlinkAttributes(attributes), new DotGraphFontAttributes(attributes),
            new DotGraphSvgStyleSheetAttributes(attributes), new DotGraphLayoutAttributes(attributes), new DotGraphCanvasAttributes(attributes), new DotLabelAlignmentAttributes(attributes)
        )
    {
    }

    protected DotGraphRootAttributes(
        DotAttributeCollection attributes,
        Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotGraphClustersAttributes clusterAttributes,
        DotHyperlinkAttributes hyperlinkAttributes,
        DotGraphFontAttributes fontAttributes,
        DotGraphSvgStyleSheetAttributes svgStyleSheetAttributes,
        DotGraphLayoutAttributes layoutAttributes,
        DotGraphCanvasAttributes canvasAttributes,
        DotLabelAlignmentAttributes labelAlignmentAttributes
    )
        : base(attributes, attributeKeyLookup)
    {
        Clusters = clusterAttributes;
        Font = fontAttributes;
        SvgStyleSheet = svgStyleSheetAttributes;
        Layout = layoutAttributes;
        Canvas = canvasAttributes;
        LabelAlignment = labelAlignmentAttributes;
        Hyperlink = hyperlinkAttributes;
    }

    public DotGraphClustersAttributes Clusters { get; }
    public DotGraphFontAttributes Font { get; }
    public DotGraphSvgStyleSheetAttributes SvgStyleSheet { get; }
    public DotGraphLayoutAttributes Layout { get; }
    public DotGraphCanvasAttributes Canvas { get; }
    public DotLabelAlignmentAttributes LabelAlignment { get; }
    public DotHyperlinkAttributes Hyperlink { get; }

    [DotAttributeKey(DotAttributeKeys.Style)]
    DotStyles? IDotGraphAttributes.Style
    {
        [DotAttributeKey(DotAttributeKeys.Style)]
        get => _attributes.GetValueAs(DotAttributeKeys.Style, out DotStyles? result) ? result : null;
        [DotAttributeKey(DotAttributeKeys.Style)]
        set => _attributes.SetValueOrRemove(DotAttributeKeys.Style, value);
    }

    [DotAttributeKey(DotAttributeKeys.Label)]
    public virtual partial DotLabel? Label { get; set; }

    [DotAttributeKey(DotAttributeKeys.NoJustify)]
    public virtual partial bool? DisableLabelJustification { get; set; }

    [DotAttributeKey(DotAttributeKeys.Splines)]
    public virtual partial DotEdgeShape? EdgeShape { get; set; }

    [DotAttributeKey(DotAttributeKeys.Comment)]
    public virtual partial string? Comment { get; set; }

    [DotAttributeKey(DotAttributeKeys.Charset)]
    public virtual partial string? Charset { get; set; }

    [DotAttributeKey(DotAttributeKeys.ImagePath)]
    public virtual partial string? ImageDirectories { get; set; }

    [DotAttributeKey(DotAttributeKeys.Root)]
    public virtual partial DotId? RootNodeId { get; set; }

    [DotAttributeKey(DotAttributeKeys.Tooltip)]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    [DotAttributeKey(DotAttributeKeys.Id)]
    public virtual partial DotEscapeString? ObjectId { get; set; }
}