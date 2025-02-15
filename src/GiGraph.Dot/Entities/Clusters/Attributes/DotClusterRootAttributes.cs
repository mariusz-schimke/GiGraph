using System;
using System.Reflection;
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

public class DotClusterRootAttributes : DotClusterNodeRootCommonAttributes<IDotClusterAttributes, DotClusterRootAttributes>, IDotClusterRootAttributes
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
        get => GetValueAsBool(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    public DotFontAttributes Font { get; }
    public DotClusterStyleAttributeOptions Style { get; }
    public DotLabelAlignmentAttributes LabelAlignment { get; }

    [DotAttributeKey(DotStyleAttributeOptions.StyleKey)]
    DotStyles? IDotClusterAttributes.Style
    {
        get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    [DotAttributeKey(DotAttributeKeys.Rank)]
    public virtual DotRank? NodeRank
    {
        get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    [DotAttributeKey(DotAttributeKeys.PenColor)]
    public virtual DotColor BorderColor
    {
        get => GetValueAsColor(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.BgColor)]
    public virtual DotColorDefinition BackgroundColor
    {
        get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.Peripheries)]
    public virtual int? Peripheries
    {
        get => GetValueAsInt(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }
}