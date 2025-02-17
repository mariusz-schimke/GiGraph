using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.ClusterNode;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Ranks;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

public partial class DotClusterRootAttributes : DotClusterNodeRootCommonAttributes<IDotClusterAttributes, DotClusterRootAttributes>, IDotClusterRootAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotClusterRootAttributes, IDotClusterAttributes>().BuildLazy();

    public DotClusterRootAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new(attributes), new(attributes), new(attributes), new(attributes), new(attributes))
    {
    }

    protected DotClusterRootAttributes(
        DotAttributeCollection attributes,
        Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotHyperlinkAttributes hyperlinkAttributes,
        DotFontAttributes fontAttributes,
        DotClusterStyleAttributeOptions styleAttributeOptions,
        DotSvgStyleSheetAttributes svgStyleSheetAttributes,
        DotLabelAlignmentAttributes labelAlignmentAttributes
    )
        : base(attributes, attributeKeyLookup, hyperlinkAttributes, svgStyleSheetAttributes)
    {
        Font = fontAttributes;
        Style = styleAttributeOptions;
        LabelAlignment = labelAlignmentAttributes;
    }

    [DotAttributeKey(DotAttributeKeys.Cluster)]
    bool? IDotClusterAttributes.IsCluster
    {
        get => _attributes.GetValue(DotAttributeKeys.Cluster, out bool? result) ? result : null;
        set => _attributes.SetOrRemove(DotAttributeKeys.Cluster, value);
    }

    public DotFontAttributes Font { get; }
    public DotClusterStyleAttributeOptions Style { get; }
    public DotLabelAlignmentAttributes LabelAlignment { get; }

    [DotAttributeKey(DotStyleAttributeOptions.StyleKey)]
    DotStyles? IDotClusterAttributes.Style
    {
        get => _attributes.GetValue(DotStyleAttributeOptions.StyleKey, out DotStyles? result) ? result : null;
        set => _attributes.SetOrRemove(DotStyleAttributeOptions.StyleKey, value);
    }

    [DotAttributeKey(DotAttributeKeys.Rank)]
    public virtual partial DotRank? NodeRank { get; set; }

    [DotAttributeKey(DotAttributeKeys.PenColor)]
    public virtual partial DotColor? BorderColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.BgColor)]
    public virtual partial DotColorDefinition? BackgroundColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.Peripheries)]
    public virtual partial int? Peripheries { get; set; }
}