using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.ClusterNode;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public partial class DotNodeRootAttributes : DotClusterNodeRootCommonAttributes<IDotNodeAttributes, DotNodeRootAttributes>, IDotNodeRootAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeRootAttributes, IDotNodeAttributes>().BuildLazy();

    public DotNodeRootAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new(attributes), new(attributes), new(attributes), new(attributes), new(attributes), new(attributes), new(attributes))
    {
    }

    protected DotNodeRootAttributes(
        DotAttributeCollection attributes,
        Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotHyperlinkAttributes hyperlinkAttributes,
        DotFontAttributes fontAttributes,
        DotNodeStyleAttributeOptions styleAttributeOptions,
        DotNodeImageAttributes imageAttributes,
        DotNodeGeometryAttributes geometryAttributes,
        DotNodeSizeAttributes sizeAttributes,
        DotSvgStyleSheetAttributes svgStyleSheetAttributes
    )
        : base(attributes, attributeKeyLookup, hyperlinkAttributes, svgStyleSheetAttributes)
    {
        Font = fontAttributes;
        Style = styleAttributeOptions;
        Image = imageAttributes;
        Geometry = geometryAttributes;
        Size = sizeAttributes;
    }

    public DotFontAttributes Font { get; }
    public DotNodeStyleAttributeOptions Style { get; }
    public DotNodeSizeAttributes Size { get; }
    public DotNodeGeometryAttributes Geometry { get; }
    public DotNodeImageAttributes Image { get; }

    [DotAttributeKey(DotStyleAttributeOptions.StyleKey)]
    DotStyles? IDotNodeAttributes.Style
    {
        get => _attributes.GetValueAs(DotStyleAttributeOptions.StyleKey, out DotStyles? result) ? result : null;
        set => _attributes.SetOrRemove(DotStyleAttributeOptions.StyleKey, value);
    }

    [DotAttributeKey(DotAttributeKeys.Comment)]
    public virtual partial string? Comment { get; set; }

    [DotAttributeKey(DotAttributeKeys.XLabel)]
    public virtual partial DotLabel? ExternalLabel { get; set; }

    [DotAttributeKey(DotAttributeKeys.LabelLoc)]
    public virtual partial DotVerticalAlignment? LabelAlignment { get; set; }

    [DotAttributeKey(DotAttributeKeys.Ordering)]
    public virtual partial DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

    [DotAttributeKey(DotAttributeKeys.Shape)]
    public virtual partial DotNodeShape? Shape { get; set; }

    [DotAttributeKey(DotAttributeKeys.Group)]
    public virtual partial string? GroupName { get; set; }

    [DotAttributeKey(DotAttributeKeys.Root)]
    public virtual partial bool? IsRoot { get; set; }
}