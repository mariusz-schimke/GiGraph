using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Graphs.Canvas;
using GiGraph.Dot.Types.Graphs.Canvas.Scaling;
using GiGraph.Dot.Types.Graphs.Canvas.Viewport;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphCanvasAttributes : DotEntityAttributesWithMetadata<IDotGraphCanvasAttributes, DotGraphCanvasAttributes>, IDotGraphCanvasAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphCanvasAttributes, IDotGraphCanvasAttributes>().BuildLazy();

    public DotGraphCanvasAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotGraphCanvasAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.CenterDrawing"/>
    [DotAttributeKey(DotAttributeKeys.Center)]
    public virtual partial bool? CenterDrawing { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Orientation"/>
    [DotAttributeKey(DotAttributeKeys.Orientation)]
    public virtual partial DotOrientation? Orientation { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.OrientationAngle"/>
    [DotAttributeKey(DotAttributeKeys.Rotate)]
    public virtual partial int? OrientationAngle { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.LandscapeOrientation"/>
    [DotAttributeKey(DotAttributeKeys.Landscape)]
    public virtual partial bool? LandscapeOrientation { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Dpi"/>
    [DotAttributeKey(DotAttributeKeys.Dpi)]
    public virtual partial double? Dpi { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Resolution"/>
    [DotAttributeKey(DotAttributeKeys.Resolution)]
    public virtual partial double? Resolution { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Size"/>
    [DotAttributeKey(DotAttributeKeys.Size)]
    public virtual partial DotPoint? Size { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Viewport"/>
    [DotAttributeKey(DotAttributeKeys.Viewport)]
    public virtual partial DotViewport? Viewport { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Scaling"/>
    [DotAttributeKey(DotAttributeKeys.Ratio)]
    public virtual partial DotGraphScalingDefinition? Scaling { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Margin"/>
    [DotAttributeKey(DotAttributeKeys.Margin)]
    public virtual partial DotPoint? Margin { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Padding"/>
    [DotAttributeKey(DotAttributeKeys.Pad)]
    public virtual partial DotPoint? Padding { get; set; }
}