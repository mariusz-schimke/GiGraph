using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.ClusterNode;

public abstract class DotClusterNodeRootCommonAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>
    : DotEntityRootCommonAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>
    where TEntityAttributeProperties : DotEntityAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
{
    protected DotClusterNodeRootCommonAttributes(
        DotAttributeCollection attributes,
        Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotHyperlinkAttributes hyperlinkAttributes,
        DotSvgStyleSheetAttributes svgStyleSheetAttributes
    )
        : base(attributes, attributeKeyLookup, hyperlinkAttributes)
    {
        SvgStyleSheet = svgStyleSheetAttributes;
    }

    public DotSvgStyleSheetAttributes SvgStyleSheet { get; }

    [DotAttributeKey(DotAttributeKeys.Color)]
    public virtual DotColorDefinition? Color
    {
        get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.FillColor)]
    public virtual DotColorDefinition? FillColor
    {
        get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.GradientAngle)]
    public virtual int? GradientFillAngle
    {
        get => GetValueAsInt(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.PenWidth)]
    public virtual double? BorderWidth
    {
        get => GetValueAsDouble(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.Tooltip)]
    public virtual DotEscapeString? Tooltip
    {
        get => GetValueAsEscapeString(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.Margin)]
    public virtual DotPoint? Padding
    {
        get => GetValueAsPoint(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.SortV)]
    public virtual int? SortIndex
    {
        get => GetValueAsInt(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }
}