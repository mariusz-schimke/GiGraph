using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Orientation;
using GiGraph.Dot.Types.Viewport;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphCanvasAttributes : DotEntityAttributesWithMetadata<IDotGraphCanvasAttributes, DotGraphCanvasAttributes>, IDotGraphCanvasAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphCanvasAttributes, IDotGraphCanvasAttributes>().BuildLazy();
    private readonly DotStyleAttributeOptions _styleAttributeOptions;

    public DotGraphCanvasAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new DotStyleAttributeOptions(attributes))
    {
    }

    protected DotGraphCanvasAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotStyleAttributeOptions styleAttributeOptions)
        : base(attributes, attributeKeyLookup)
    {
        _styleAttributeOptions = styleAttributeOptions;
    }
    
    /// <summary>
    ///     Gets or sets a fill style of the graph. Note that the style is shared with clusters, and that the only option applicable to
    ///     the root graph is <see cref="DotClusterFillStyle.Radial" />.
    /// </summary>
    public virtual DotClusterFillStyle FillStyle
    {
        get => _styleAttributeOptions.GetPart<DotClusterFillStyle>();
        set => _styleAttributeOptions.SetPart(value);
    }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.BackgroundColor" />
    [DotAttributeKey(DotAttributeKeys.BgColor)]
    public virtual partial DotColorDefinition? BackgroundColor { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.GradientFillAngle" />
    [DotAttributeKey(DotAttributeKeys.GradientAngle)]
    public virtual partial int? GradientFillAngle { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.CenterDrawing" />
    [DotAttributeKey(DotAttributeKeys.Center)]
    public virtual partial bool? CenterDrawing { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Orientation" />
    [DotAttributeKey(DotAttributeKeys.Orientation)]
    public virtual partial DotOrientation? Orientation { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.OrientationAngle" />
    [DotAttributeKey(DotAttributeKeys.Rotate)]
    public virtual partial int? OrientationAngle { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.LandscapeOrientation" />
    [DotAttributeKey(DotAttributeKeys.Landscape)]
    public virtual partial bool? LandscapeOrientation { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Dpi" />
    [DotAttributeKey(DotAttributeKeys.Dpi)]
    public virtual partial double? Dpi { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Resolution" />
    [DotAttributeKey(DotAttributeKeys.Resolution)]
    public virtual partial double? Resolution { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Size" />
    [DotAttributeKey(DotAttributeKeys.Size)]
    public virtual partial DotPoint? Size { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Viewport" />
    [DotAttributeKey(DotAttributeKeys.Viewport)]
    public virtual partial DotViewport? Viewport { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Scaling" />
    [DotAttributeKey(DotAttributeKeys.Ratio)]
    public virtual partial DotGraphScalingDefinition? Scaling { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Margin" />
    [DotAttributeKey(DotAttributeKeys.Margin)]
    public virtual partial DotPoint? Margin { get; set; }

    /// <inheritdoc cref="IDotGraphCanvasAttributes.Padding" />
    [DotAttributeKey(DotAttributeKeys.Pad)]
    public virtual partial DotPoint? Padding { get; set; }

    /// <summary>
    ///     Copies canvas attributes from the specified instance.
    /// </summary>
    /// <param name="attributes">
    ///     The instance to copy the attributes from.
    /// </param>
    public virtual void Set(IDotGraphCanvasAttributes attributes)
    {
        BackgroundColor = attributes.BackgroundColor;
        CenterDrawing = attributes.CenterDrawing;
        Dpi = attributes.Dpi;
        GradientFillAngle = attributes.GradientFillAngle;
        LandscapeOrientation = attributes.LandscapeOrientation;
        Margin = attributes.Margin;
        Orientation = attributes.Orientation;
        OrientationAngle = attributes.OrientationAngle;
        Padding = attributes.Padding;
        Resolution = attributes.Resolution;
        Scaling = attributes.Scaling;
        Size = attributes.Size;
        Viewport = attributes.Viewport;
    }
}