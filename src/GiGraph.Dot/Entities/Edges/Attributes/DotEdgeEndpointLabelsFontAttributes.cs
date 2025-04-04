﻿using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public partial class DotEdgeEndpointLabelsFontAttributes : DotFontAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeEndpointLabelsFontAttributes, IDotFontAttributes>().BuildLazy();

    public DotEdgeEndpointLabelsFontAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotEdgeEndpointLabelsFontAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <summary>
    ///     Font used for labels specified for the head and the tail of the edge (default: "Times-Roman"). If not set, defaults to font
    ///     name specified for the edge.
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.LabelFontName)]
    public override partial string? Name { get; set; }

    /// <summary>
    ///     Color used for labels specified for the head and the tail of the edge (default: <see cref="System.Drawing.Color.Black" />).
    ///     If not set, defaults to font color specified for the edge.
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.LabelFontColor)]
    public override partial DotColor? Color { get; set; }

    /// <summary>
    ///     Font size, in points, used for labels specified for the head and the tail of the edge (default: 14.0). If not set, defaults
    ///     to font size specified for the edge.
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.LabelFontSize)]
    public override partial double? Size { get; set; }
}