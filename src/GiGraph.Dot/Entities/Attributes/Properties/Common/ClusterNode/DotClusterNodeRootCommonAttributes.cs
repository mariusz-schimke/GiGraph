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

public abstract partial class DotClusterNodeRootCommonAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>
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
    public virtual partial DotColorDefinition? Color { get; set; }

    [DotAttributeKey(DotAttributeKeys.FillColor)]
    public virtual partial DotColorDefinition? FillColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.GradientAngle)]
    public virtual partial int? GradientFillAngle { get; set; }

    [DotAttributeKey(DotAttributeKeys.PenWidth)]
    public virtual partial double? BorderWidth { get; set; }

    [DotAttributeKey(DotAttributeKeys.Tooltip)]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    [DotAttributeKey(DotAttributeKeys.Margin)]
    public virtual partial DotPoint? Padding { get; set; }

    [DotAttributeKey(DotAttributeKeys.SortV)]
    public virtual partial int? SortIndex { get; set; }
}