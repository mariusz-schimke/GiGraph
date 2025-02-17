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

public class DotNodeRootAttributes : DotClusterNodeRootCommonAttributes<IDotNodeAttributes, DotNodeRootAttributes>, IDotNodeRootAttributes
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
        get => _attributes.GetValue(DotStyleAttributeOptions.StyleKey, out DotStyles? result) ? result : null;
        set => _attributes.SetOrRemove(DotStyleAttributeOptions.StyleKey, value);
    }

    [DotAttributeKey(DotAttributeKeys.Comment)]
    public virtual string? Comment
    {
        get => GetValueAsString(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.XLabel)]
    public virtual DotLabel? ExternalLabel
    {
        get => GetValueAsLabel(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.LabelLoc)]
    public virtual DotVerticalAlignment? LabelAlignment
    {
        get => GetValueAs<DotVerticalAlignment>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    [DotAttributeKey(DotAttributeKeys.Ordering)]
    public virtual DotEdgeOrderingMode? EdgeOrderingMode
    {
        get => GetValueAs<DotEdgeOrderingMode>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    [DotAttributeKey(DotAttributeKeys.Shape)]
    public virtual DotNodeShape? Shape
    {
        get => GetValueAs<DotNodeShape>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    [DotAttributeKey(DotAttributeKeys.Group)]
    public virtual string? GroupName
    {
        get => GetValueAsString(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.Root)]
    public virtual bool? IsRoot
    {
        get => GetValueAsBool(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }
}