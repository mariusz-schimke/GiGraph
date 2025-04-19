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

    /// <inheritdoc cref="IDotClusterRootAttributes.Font"/>
    public DotFontAttributes Font { get; }

    /// <inheritdoc cref="IDotClusterRootAttributes.Style"/>
    public DotClusterStyleAttributes Style { get; }

    /// <inheritdoc cref="IDotClusterRootAttributes.LabelAlignment"/>
    public DotLabelAlignmentAttributes LabelAlignment { get; }

    /// <inheritdoc cref="IDotClusterRootAttributes.SvgStyleSheet"/>
    public DotSvgStyleSheetAttributes SvgStyleSheet { get; }

    /// <inheritdoc cref="IDotClusterRootAttributes.Hyperlink"/>
    public DotHyperlinkAttributes Hyperlink { get; }

    [DotAttributeKey(DotAttributeKeys.Style)]
    DotStyles? IDotClusterAttributes.Style
    {
        [DotAttributeKey(DotAttributeKeys.Style)]
        get => _attributes.GetValueAs(DotAttributeKeys.Style, out DotStyles? result) ? result : null;
        [DotAttributeKey(DotAttributeKeys.Style)]
        set => _attributes.SetValueOrRemove(DotAttributeKeys.Style, value);
    }

    /// <inheritdoc cref="IDotClusterAttributes.Label"/>
    [DotAttributeKey(DotAttributeKeys.Label)]
    public virtual partial DotLabel? Label { get; set; }

    /// <inheritdoc cref="IDotClusterAttributes.DisableLabelJustification"/>
    [DotAttributeKey(DotAttributeKeys.NoJustify)]
    public virtual partial bool? DisableLabelJustification { get; set; }

    /// <inheritdoc cref="IDotClusterAttributes.NodeRank"/>
    [DotAttributeKey(DotAttributeKeys.Rank)]
    public virtual partial DotRank? NodeRank { get; set; }

    /// <inheritdoc cref="IDotClusterAttributes.Peripheries"/>
    [DotAttributeKey(DotAttributeKeys.Peripheries)]
    public virtual partial int? Peripheries { get; set; }

    /// <inheritdoc cref="IDotClusterAttributes.Tooltip"/>
    [DotAttributeKey(DotAttributeKeys.Tooltip)]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    /// <inheritdoc cref="IDotClusterAttributes.Padding"/>
    [DotAttributeKey(DotAttributeKeys.Margin)]
    public virtual partial DotPoint? Padding { get; set; }

    /// <inheritdoc cref="IDotClusterAttributes.SortIndex"/>
    [DotAttributeKey(DotAttributeKeys.SortV)]
    public virtual partial int? SortIndex { get; set; }

    /// <inheritdoc cref="IDotClusterAttributes.ObjectId"/>
    [DotAttributeKey(DotAttributeKeys.Id)]
    public virtual partial DotEscapeString? ObjectId { get; set; }
}