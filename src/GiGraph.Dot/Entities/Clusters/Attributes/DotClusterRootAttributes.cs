using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Ranks;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

public partial class DotClusterRootAttributes : DotEntityAttributesWithMetadata<IDotClusterAttributes, DotClusterRootAttributes>, IDotClusterRootAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotClusterRootAttributes, IDotClusterAttributes>().BuildLazy();

    public DotClusterRootAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new DotHyperlinkAttributes(attributes), new DotFontAttributes(attributes),
            new DotClusterStyleAttributes(attributes), new DotSvgStyleSheetAttributes(attributes), new DotLabelAlignmentAttributes(attributes)
        )
    {
    }

    protected DotClusterRootAttributes(
        DotAttributeCollection attributes,
        Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotHyperlinkAttributes hyperlinkAttributes,
        DotFontAttributes fontAttributes,
        DotClusterStyleAttributes styleAttributes,
        DotSvgStyleSheetAttributes svgStyleSheetAttributes,
        DotLabelAlignmentAttributes labelAlignmentAttributes
    )
        : base(attributes, attributeKeyLookup)
    {
        Font = fontAttributes;
        Style = styleAttributes;
        LabelAlignment = labelAlignmentAttributes;
        SvgStyleSheet = svgStyleSheetAttributes;
        Hyperlink = hyperlinkAttributes;
    }

    [DotAttributeKey(DotAttributeKeys.Cluster)]
    bool? IDotClusterAttributes.IsCluster
    {
        [DotAttributeKey(DotAttributeKeys.Cluster)]
        get => _attributes.GetValueAs(DotAttributeKeys.Cluster, out bool? result) ? result : null;
        [DotAttributeKey(DotAttributeKeys.Cluster)]
        set => _attributes.SetValueOrRemove(DotAttributeKeys.Cluster, value);
    }

    public DotFontAttributes Font { get; }
    public DotClusterStyleAttributes Style { get; }
    public DotLabelAlignmentAttributes LabelAlignment { get; }
    public DotSvgStyleSheetAttributes SvgStyleSheet { get; }
    public DotHyperlinkAttributes Hyperlink { get; }

    [DotAttributeKey(DotAttributeKeys.Style)]
    DotStyles? IDotClusterAttributes.Style
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

    [DotAttributeKey(DotAttributeKeys.Rank)]
    public virtual partial DotRankAlignment? NodeRankAlignment { get; set; }

    [DotAttributeKey(DotAttributeKeys.Peripheries)]
    public virtual partial int? Peripheries { get; set; }

    [DotAttributeKey(DotAttributeKeys.Tooltip)]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    [DotAttributeKey(DotAttributeKeys.Margin)]
    public virtual partial DotPoint? Padding { get; set; }

    [DotAttributeKey(DotAttributeKeys.SortV)]
    public virtual partial int? SortIndex { get; set; }

    [DotAttributeKey(DotAttributeKeys.Id)]
    public virtual partial DotEscapeString? ObjectId { get; set; }
}