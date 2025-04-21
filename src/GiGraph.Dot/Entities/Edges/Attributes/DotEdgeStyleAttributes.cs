using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
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
    public virtual DotLineStyle LineStyle
    {
        get => GetPartialStyleModifier<DotLineStyle>();
        set => SetPartialStyleModifier(value);
    }

    /// <summary>
    ///     Gets or sets a line weight for the edge (default: <see cref="DotLineWeight.Normal"/>).
    /// </summary>
    public virtual DotLineWeight LineWeight
    {
        get => GetPartialStyleModifier<DotLineWeight>();
        set => SetPartialStyleModifier(value);
    }

    /// <summary>
    ///     Gets or sets a value indicating if the edge is invisible.
    /// </summary>
    public virtual bool Invisible
    {
        get => HasStyleModifier(DotStyles.Invisible);
        set => SetStyleModifier(DotStyles.Invisible, value);
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

    /// <inheritdoc cref="IDotEdgeStyleAttributes.ArrowheadSizeFactor"/>
    [DotAttributeKey(DotAttributeKeys.ArrowSize)]
    public virtual partial double? ArrowheadSizeFactor { get; set; }

    /// <inheritdoc cref="IDotEdgeStyleAttributes.DrawLabelConnector"/>
    [DotAttributeKey(DotAttributeKeys.Decorate)]
    public virtual partial bool? DrawLabelConnector { get; set; }

    /// <summary>
    ///     Applies the specified style modifiers to the edge.
    /// </summary>
    /// <param name="modifiers">
    ///     The options to apply.
    /// </param>
    public virtual void SetStyleModifiers(DotEdgeStyleModifiers modifiers)
    {
        SetStyleModifiers(modifiers.LineStyle, modifiers.LineWeight, modifiers.Invisible);
    }

    /// <summary>
    ///     Applies the specified style modifiers to the edge.
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
    public virtual void SetStyleModifiers(DotLineStyle lineStyle = default, DotLineWeight lineWeight = default, bool invisible = false)
    {
        LineStyle = lineStyle;
        LineWeight = lineWeight;
        Invisible = invisible;
    }
}