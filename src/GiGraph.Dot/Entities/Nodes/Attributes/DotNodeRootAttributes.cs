using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public partial class DotNodeRootAttributes : DotEntityAttributesWithMetadata<IDotNodeAttributes, DotNodeRootAttributes>, IDotNodeRootAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeRootAttributes, IDotNodeAttributes>().BuildLazy();

    public DotNodeRootAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new DotFontAttributes(attributes), new DotNodeGeometryAttributes(attributes), new DotHyperlinkAttributes(attributes),
            new DotNodeImageAttributes(attributes), new DotNodeSizeAttributes(attributes), new DotNodeStyleAttributes(attributes), new DotSvgStyleSheetAttributes(attributes)
        )
    {
    }

    protected DotNodeRootAttributes(
        DotAttributeCollection attributes,
        Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotFontAttributes fontAttributes,
        DotNodeGeometryAttributes geometryAttributes,
        DotHyperlinkAttributes hyperlinkAttributes,
        DotNodeImageAttributes imageAttributes,
        DotNodeSizeAttributes sizeAttributes,
        DotNodeStyleAttributes styleAttributes,
        DotSvgStyleSheetAttributes svgStyleSheetAttributes
    )
        : base(attributes, attributeKeyLookup)
    {
        Font = fontAttributes;
        Geometry = geometryAttributes;
        Hyperlink = hyperlinkAttributes;
        Image = imageAttributes;
        Size = sizeAttributes;
        Style = styleAttributes;
        SvgStyleSheet = svgStyleSheetAttributes;
    }

    public DotFontAttributes Font { get; }
    public DotNodeGeometryAttributes Geometry { get; }
    public DotHyperlinkAttributes Hyperlink { get; }
    public DotNodeImageAttributes Image { get; }
    public DotNodeSizeAttributes Size { get; }
    public DotNodeStyleAttributes Style { get; }
    public DotSvgStyleSheetAttributes SvgStyleSheet { get; }

    [DotAttributeKey(DotAttributeKeys.Style)]
    DotStyles? IDotNodeAttributes.Style
    {
        [DotAttributeKey(DotAttributeKeys.Style)]
        get => _attributes.GetValueAs(DotAttributeKeys.Style, out DotStyles? result) ? result : null;
        [DotAttributeKey(DotAttributeKeys.Style)]
        set => _attributes.SetValueOrRemove(DotAttributeKeys.Style, value);
    }

    [DotAttributeKey(DotAttributeKeys.Label)]
    public virtual partial DotLabel? Label { get; set; }

    [DotAttributeKey(DotAttributeKeys.Tooltip)]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    [DotAttributeKey(DotAttributeKeys.Margin)]
    public virtual partial DotPoint? Padding { get; set; }

    [DotAttributeKey(DotAttributeKeys.SortV)]
    public virtual partial int? SortIndex { get; set; }

    [DotAttributeKey(DotAttributeKeys.Comment)]
    public virtual partial string? Comment { get; set; }

    [DotAttributeKey(DotAttributeKeys.XLabel)]
    public virtual partial DotLabel? ExternalLabel { get; set; }

    [DotAttributeKey(DotAttributeKeys.LabelLoc)]
    public virtual partial DotVerticalAlignment? LabelAlignment { get; set; }

    [DotAttributeKey(DotAttributeKeys.NoJustify)]
    public virtual partial bool? DisableLabelJustification { get; set; }

    [DotAttributeKey(DotAttributeKeys.Ordering)]
    public virtual partial DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

    [DotAttributeKey(DotAttributeKeys.Shape)]
    public virtual partial DotNodeShape? Shape { get; set; }

    [DotAttributeKey(DotAttributeKeys.Group)]
    public virtual partial string? GroupName { get; set; }

    [DotAttributeKey(DotAttributeKeys.Root)]
    public virtual partial bool? IsLayoutRoot { get; set; }

    [DotAttributeKey(DotAttributeKeys.Id)]
    public virtual partial DotEscapeString? ObjectId { get; set; }
}