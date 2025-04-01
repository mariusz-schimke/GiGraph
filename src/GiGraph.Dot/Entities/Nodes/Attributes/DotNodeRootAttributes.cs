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

    /// <inheritdoc cref="IDotNodeRootAttributes.Font"/>
    public DotFontAttributes Font { get; }

    /// <inheritdoc cref="IDotNodeRootAttributes.Geometry"/>
    public DotNodeGeometryAttributes Geometry { get; }

    /// <inheritdoc cref="IDotNodeRootAttributes.Hyperlink"/>
    public DotHyperlinkAttributes Hyperlink { get; }

    /// <inheritdoc cref="IDotNodeRootAttributes.Image"/>
    public DotNodeImageAttributes Image { get; }

    /// <inheritdoc cref="IDotNodeRootAttributes.Size"/>
    public DotNodeSizeAttributes Size { get; }

    /// <inheritdoc cref="IDotNodeRootAttributes.Style"/>
    public DotNodeStyleAttributes Style { get; }

    /// <inheritdoc cref="IDotNodeRootAttributes.SvgStyleSheet"/>
    public DotSvgStyleSheetAttributes SvgStyleSheet { get; }

    [DotAttributeKey(DotAttributeKeys.Style)]
    DotStyles? IDotNodeAttributes.Style
    {
        [DotAttributeKey(DotAttributeKeys.Style)]
        get => _attributes.GetValueAs(DotAttributeKeys.Style, out DotStyles? result) ? result : null;
        [DotAttributeKey(DotAttributeKeys.Style)]
        set => _attributes.SetValueOrRemove(DotAttributeKeys.Style, value);
    }

    /// <inheritdoc cref="IDotNodeAttributes.Label"/>
    [DotAttributeKey(DotAttributeKeys.Label)]
    public virtual partial DotLabel? Label { get; set; }

    /// <inheritdoc cref="IDotNodeAttributes.Tooltip"/>
    [DotAttributeKey(DotAttributeKeys.Tooltip)]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    /// <inheritdoc cref="IDotNodeAttributes.Padding"/>
    [DotAttributeKey(DotAttributeKeys.Margin)]
    public virtual partial DotPoint? Padding { get; set; }

    /// <inheritdoc cref="IDotNodeAttributes.SortIndex"/>
    [DotAttributeKey(DotAttributeKeys.SortV)]
    public virtual partial int? SortIndex { get; set; }

    /// <inheritdoc cref="IDotNodeAttributes.Comment"/>
    [DotAttributeKey(DotAttributeKeys.Comment)]
    public virtual partial string? Comment { get; set; }

    /// <inheritdoc cref="IDotNodeAttributes.ExternalLabel"/>
    [DotAttributeKey(DotAttributeKeys.XLabel)]
    public virtual partial DotLabel? ExternalLabel { get; set; }

    /// <inheritdoc cref="IDotNodeAttributes.LabelAlignment"/>
    [DotAttributeKey(DotAttributeKeys.LabelLoc)]
    public virtual partial DotVerticalAlignment? LabelAlignment { get; set; }

    /// <inheritdoc cref="IDotNodeAttributes.DisableLabelJustification"/>
    [DotAttributeKey(DotAttributeKeys.NoJustify)]
    public virtual partial bool? DisableLabelJustification { get; set; }

    /// <inheritdoc cref="IDotNodeAttributes.EdgeOrderingMode"/>
    [DotAttributeKey(DotAttributeKeys.Ordering)]
    public virtual partial DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

    /// <inheritdoc cref="IDotNodeAttributes.Shape"/>
    [DotAttributeKey(DotAttributeKeys.Shape)]
    public virtual partial DotNodeShape? Shape { get; set; }

    /// <inheritdoc cref="IDotNodeAttributes.GroupName"/>
    [DotAttributeKey(DotAttributeKeys.Group)]
    public virtual partial string? GroupName { get; set; }

    /// <inheritdoc cref="IDotNodeAttributes.IsLayoutRoot"/>
    [DotAttributeKey(DotAttributeKeys.Root)]
    public virtual partial bool? IsLayoutRoot { get; set; }

    /// <inheritdoc cref="IDotNodeAttributes.ObjectId"/>
    [DotAttributeKey(DotAttributeKeys.Id)]
    public virtual partial DotEscapeString? ObjectId { get; set; }
}