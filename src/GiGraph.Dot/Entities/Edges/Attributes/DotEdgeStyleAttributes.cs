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
    ///     Gets or sets a line style for the edge (default: <see cref="DotLineStyle.Normal"/>).
    /// </summary>
    public virtual DotLineStyle? LineStyle
    {
        get => GetPartialStyleOption<DotLineStyle>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a line weight for the edge (default: <see cref="DotLineWeight.Normal"/>).
    /// </summary>
    public virtual DotLineWeight? LineWeight
    {
        get => GetPartialStyleOption<DotLineWeight>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a value indicating if the edge is invisible.
    /// </summary>
    public virtual bool? Invisible
    {
        get => HasStyleOption(DotStyles.Invisible);
        set => SetStyleOption(DotStyles.Invisible, value);
    }

    /// <inheritdoc cref="IDotEdgeStyleAttributes.Color"/>
    [DotAttributeKey(DotAttributeKeys.Color)]
    public virtual partial DotColorDefinition? Color { get; set; }

    /// <inheritdoc cref="IDotEdgeStyleAttributes.ColorScheme"/>
    [DotAttributeKey(DotAttributeKeys.ColorScheme)]
    public virtual partial string? ColorScheme { get; set; }

    /// <inheritdoc cref="IDotEdgeStyleAttributes.FillColor"/>
    [DotAttributeKey(DotAttributeKeys.FillColor)]
    public virtual partial DotColorDefinition? FillColor { get; set; }

    /// <inheritdoc cref="IDotEdgeStyleAttributes.LineWidth"/>
    [DotAttributeKey(DotAttributeKeys.PenWidth)]
    public virtual partial double? LineWidth { get; set; }

    /// <inheritdoc cref="IDotEdgeStyleAttributes.ArrowheadScale"/>
    [DotAttributeKey(DotAttributeKeys.ArrowSize)]
    public virtual partial double? ArrowheadScale { get; set; }

    /// <inheritdoc cref="IDotEdgeStyleAttributes.DrawLabelConnector"/>
    [DotAttributeKey(DotAttributeKeys.Decorate)]
    public virtual partial bool? DrawLabelConnector { get; set; }

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
    public virtual void SetStyleOptions(DotLineStyle? lineStyle = null, DotLineWeight? lineWeight = null, bool? invisible = null)
    {
        LineStyle = lineStyle;
        LineWeight = lineWeight;
        Invisible = invisible;
    }
}