using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public class DotGraphRootAttributes : DotEntityRootCommonAttributes<IDotGraphAttributes, DotGraphRootAttributes>, IDotGraphRootAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphRootAttributes, IDotGraphAttributes>().BuildLazy();

    public DotGraphRootAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new(attributes), new(attributes), new(attributes), new(attributes),
            new(attributes), new(attributes), new(attributes), new(attributes)
        )
    {
    }

    protected DotGraphRootAttributes(
        DotAttributeCollection attributes,
        Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotGraphClustersAttributes clusterAttributes,
        DotHyperlinkAttributes hyperlinkAttributes,
        DotGraphFontAttributes fontAttributes,
        DotGraphStyleAttributeOptions styleAttributeOptions,
        DotGraphSvgStyleSheetAttributes svgStyleSheetAttributes,
        DotGraphLayoutAttributes layoutAttributes,
        DotGraphCanvasAttributes canvasAttributes,
        DotLabelAlignmentAttributes labelAlignmentAttributes
    )
        : base(attributes, attributeKeyLookup, hyperlinkAttributes)
    {
        Clusters = clusterAttributes;
        Font = fontAttributes;
        Style = styleAttributeOptions;
        SvgStyleSheet = svgStyleSheetAttributes;
        Layout = layoutAttributes;
        Canvas = canvasAttributes;
        LabelAlignment = labelAlignmentAttributes;
    }

    public DotGraphStyleAttributeOptions Style { get; }

    public DotGraphClustersAttributes Clusters { get; }
    public DotGraphFontAttributes Font { get; }
    public DotGraphSvgStyleSheetAttributes SvgStyleSheet { get; }
    public DotGraphLayoutAttributes Layout { get; }
    public DotGraphCanvasAttributes Canvas { get; }
    public DotLabelAlignmentAttributes LabelAlignment { get; }

    [DotAttributeKey(DotStyleAttributeOptions.StyleKey)]
    DotStyles? IDotGraphAttributes.Style
    {
        get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    [DotAttributeKey(DotAttributeKeys.Splines)]
    public virtual DotEdgeShape? EdgeShape
    {
        get => GetValueAs<DotEdgeShape>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }

    [DotAttributeKey(DotAttributeKeys.Comment)]
    public virtual string? Comment
    {
        get => GetValueAsString(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.Charset)]
    public virtual string? Charset
    {
        get => GetValueAsString(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.ImagePath)]
    public virtual string? ImageDirectories
    {
        get => GetValueAsString(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey(DotAttributeKeys.Root)]
    public virtual DotId? RootNodeId
    {
        get => GetValueAsId(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }
}