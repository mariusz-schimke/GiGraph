using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public partial class DotEdgeStyleAttributes : DotEntityStyleAttributesWithMetadata<IDotEdgeStyleAttributes, DotEdgeStyleAttributes>, IDotEdgeStyleAttributes, IDotHasLineStyleAttributes
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
    ///     Sets the arrowhead style.
    /// </summary>
    /// <param name="scale">
    ///     The multiplicative scale factor (default: 1.0, minimum: 0.0).
    /// </param>
    /// <param name="fillColor">
    ///     The color to use to fill the arrowhead, assuming it has a filled style. If null is specified, <see cref="LineColor"/> will be
    ///     used.
    /// </param>
    public virtual DotEdgeStyleAttributes SetArrowheadStyle(double? scale, DotColorDefinition? fillColor)
    {
        ArrowheadFillColor = fillColor;
        ArrowheadScale = scale;
        return this;
    }
}