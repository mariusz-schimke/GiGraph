using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

public partial class DotClusterRootAttributes : DotEntityAttributesWithMetadata<IDotClusterAttributes, DotClusterRootAttributes>, IDotClusterRootAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotClusterRootAttributes, IDotClusterAttributes>().BuildLazy();

    public DotClusterRootAttributes(DotAttributeCollection attributes)
        : this(
            attributes,
            AttributeKeyLookup,
            new DotHyperlinkAttributes(attributes),
            new DotFontAttributes(attributes),
            new DotClusterStyleAttributes(attributes),
            new DotSvgStyleSheetAttributes(attributes),
            new DotLabelOptionsAttributes(attributes),
            new DotClusterLayoutAttributes(attributes)
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
        DotLabelOptionsAttributes labelOptionsAttributes,
        DotClusterLayoutAttributes layoutAttributes
    )
        : base(attributes, attributeKeyLookup)
    {
        Font = fontAttributes;
        Style = styleAttributes;
        LabelOptions = labelOptionsAttributes;
        SvgStyleSheet = svgStyleSheetAttributes;
        Hyperlink = hyperlinkAttributes;
        Layout = layoutAttributes;
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

    /// <inheritdoc cref="IDotClusterRootAttributes.LabelOptions"/>
    public DotLabelOptionsAttributes LabelOptions { get; }

    /// <inheritdoc cref="IDotClusterRootAttributes.SvgStyleSheet"/>
    public DotSvgStyleSheetAttributes SvgStyleSheet { get; }

    /// <inheritdoc cref="IDotClusterRootAttributes.Hyperlink"/>
    public DotHyperlinkAttributes Hyperlink { get; }

    /// <inheritdoc cref="IDotClusterRootAttributes.Layout"/>
    public DotClusterLayoutAttributes Layout { get; }

    /// <inheritdoc cref="IDotClusterAttributes.Label"/>
    [DotAttributeKey(DotAttributeKeys.Label)]
    public virtual partial DotLabel? Label { get; set; }

    /// <inheritdoc cref="IDotClusterAttributes.Tooltip"/>
    [DotAttributeKey(DotAttributeKeys.Tooltip)]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    /// <inheritdoc cref="IDotClusterAttributes.Padding"/>
    [DotAttributeKey(DotAttributeKeys.Margin)]
    public virtual partial DotPoint? Padding { get; set; }

    /// <inheritdoc cref="IDotClusterAttributes.ObjectId"/>
    [DotAttributeKey(DotAttributeKeys.Id)]
    public virtual partial DotEscapeString? ObjectId { get; set; }
}