using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges.Style;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public partial class DotEdgeStyleAttributes : DotEntityStyleAttributesWithMetadata<IDotEdgeStyleAttributes, DotEdgeStyleAttributes>, IDotEdgeStyleAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeStyleAttributes, IDotEdgeStyleAttributes>().BuildLazy();

    public DotEdgeStyleAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotEdgeStyleAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <summary>
    ///     Gets or sets a line style for the edge.
    /// </summary>
    public virtual DotLineStyle LineStyle
    {
        get => this.GetPartialStyleOption<DotLineStyle, DotStyles>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a line weight for the edge.
    /// </summary>
    public virtual DotLineWeight LineWeight
    {
        get => this.GetPartialStyleOption<DotLineWeight, DotStyles>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a value indicating if the edge is invisible.
    /// </summary>
    public virtual bool Invisible
    {
        get => this.HasStyleOption(DotStyles.Invisible);
        set => SetStyleOption(DotStyles.Invisible, value);
    }

    /// <inheritdoc cref="IDotEdgeStyleAttributes.LineColor"/>
    [DotAttributeKey(DotAttributeKeys.Color)]
    public virtual partial DotColorDefinition? LineColor { get; set; }

    /// <inheritdoc cref="IDotEdgeStyleAttributes.ColorScheme"/>
    [DotAttributeKey(DotAttributeKeys.ColorScheme)]
    public virtual partial string? ColorScheme { get; set; }

    /// <inheritdoc cref="IDotEdgeStyleAttributes.ArrowheadFillColor"/>
    [DotAttributeKey(DotAttributeKeys.FillColor)]
    public virtual partial DotColorDefinition? ArrowheadFillColor { get; set; }

    /// <inheritdoc cref="IDotEdgeStyleAttributes.LineWidth"/>
    [DotAttributeKey(DotAttributeKeys.PenWidth)]
    public virtual partial double? LineWidth { get; set; }

    /// <inheritdoc cref="IDotEdgeStyleAttributes.ArrowheadScale"/>
    [DotAttributeKey(DotAttributeKeys.ArrowSize)]
    public virtual partial double? ArrowheadScale { get; set; }

    /// <summary>
    ///     Applies the specified style options to the edge.
    /// </summary>
    /// <param name="options">
    ///     The options to apply.
    /// </param>
    public virtual void SetStyleOptions(DotEdgeStyleOptions options)
    {
        SetStyleOptions(options.LineStyle, options.LineWeight, options.Invisible);
    }

    /// <summary>
    ///     Applies the specified style options to the edge.
    /// </summary>
    /// <param name="lineStyle">
    ///     The line style to set.
    /// </param>
    /// <param name="lineWeight">
    ///     The line weight to set.
    /// </param>
    /// <param name="invisible">
    ///     Determines whether the edge should be invisible.
    /// </param>
    public virtual void SetStyleOptions(DotLineStyle lineStyle = default, DotLineWeight lineWeight = default, bool invisible = false)
    {
        LineStyle = lineStyle;
        LineWeight = lineWeight;
        Invisible = invisible;
    }

    /// <summary>
    ///     Sets the arrowhead style.
    /// </summary>
    /// <param name="fillColor">
    ///     The color to use to fill the arrowhead, assuming it has a filled style. If null is specified, <see cref="LineColor"/> will be
    ///     used.
    /// </param>
    /// <param name="scale">
    ///     The multiplicative scale factor (default: 1.0, minimum: 0.0).
    /// </param>
    public virtual void SetArrowheadStyle(DotColorDefinition? fillColor = null, double? scale = null)
    {
        ArrowheadFillColor = fillColor;
        ArrowheadScale = scale;
    }
}