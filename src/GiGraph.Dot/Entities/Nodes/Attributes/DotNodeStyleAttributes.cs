using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Nodes.Style;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public partial class DotNodeStyleAttributes : DotEntityStyleAttributesWithMetadata<IDotNodeStyleAttributes, DotNodeStyleAttributes>, IDotNodeStyleAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeStyleAttributes, IDotNodeStyleAttributes>().BuildLazy();

    public DotNodeStyleAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotNodeStyleAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <summary>
    ///     Gets or sets a fill style.
    /// </summary>
    public virtual DotNodeFillStyle? FillStyle
    {
        get => GetPartialStyleOption<DotNodeFillStyle>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a border style.
    /// </summary>
    public virtual DotBorderStyle? BorderStyle
    {
        get => GetPartialStyleOption<DotBorderStyle>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a border weight.
    /// </summary>
    public virtual DotBorderWeight? BorderWeight
    {
        get => GetPartialStyleOption<DotBorderWeight>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a corner style.
    /// </summary>
    public virtual DotCornerStyle? CornerStyle
    {
        get => GetPartialStyleOption<DotCornerStyle>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     When set, causes small chords to be drawn near the vertices of the node’s polygon or, in case of circles and ellipses, two
    ///     chords near the top and the bottom of the shape.
    /// </summary>
    public virtual bool? Diagonals
    {
        get => HasStyleOption(DotStyles.Diagonals);
        set => SetStyleOption(DotStyles.Diagonals, value);
    }

    /// <summary>
    ///     When set, makes the element invisible.
    /// </summary>
    public virtual bool? Invisible
    {
        get => HasStyleOption(DotStyles.Invisible);
        set => SetStyleOption(DotStyles.Invisible, value);
    }

    /// <inheritdoc cref="IDotNodeStyleAttributes.Color"/>
    [DotAttributeKey(DotAttributeKeys.Color)]
    public virtual partial DotColorDefinition? Color { get; set; }

    /// <inheritdoc cref="IDotNodeStyleAttributes.ColorScheme"/>
    [DotAttributeKey(DotAttributeKeys.ColorScheme)]
    public virtual partial string? ColorScheme { get; set; }

    /// <inheritdoc cref="IDotNodeStyleAttributes.FillColor"/>
    [DotAttributeKey(DotAttributeKeys.FillColor)]
    public virtual partial DotColorDefinition? FillColor { get; set; }

    /// <inheritdoc cref="IDotNodeStyleAttributes.GradientFillAngle"/>
    [DotAttributeKey(DotAttributeKeys.GradientAngle)]
    public virtual partial int? GradientFillAngle { get; set; }

    /// <inheritdoc cref="IDotNodeStyleAttributes.BorderWidth"/>
    [DotAttributeKey(DotAttributeKeys.PenWidth)]
    public virtual partial double? BorderWidth { get; set; }

    /// <inheritdoc cref="IDotNodeStyleAttributes.Peripheries"/>
    [DotAttributeKey(DotAttributeKeys.Peripheries)]
    public virtual partial int? Peripheries { get; set; }

    /// <summary>
    ///     Applies the specified style options.
    /// </summary>
    /// <param name="options">
    ///     The options to apply.
    /// </param>
    public virtual void SetStyleOptions(DotNodeStyleOptions options)
    {
        SetStyleOptions(options.FillStyle, options.BorderStyle, options.BorderWeight, options.CornerStyle, options.Diagonals, options.Invisible);
    }

    /// <summary>
    ///     Applies the specified style options.
    /// </summary>
    /// <param name="fillStyle">
    ///     The fill style to set.
    /// </param>
    /// <param name="borderStyle">
    ///     The border style to set.
    /// </param>
    /// <param name="borderWeight">
    ///     The border weight to set.
    /// </param>
    /// <param name="cornerStyle">
    ///     The corner style to set.
    /// </param>
    /// <param name="diagonals">
    ///     Causes small chords to be drawn near the vertices of the node’s polygon or, in case of circles and ellipses, two chords near
    ///     the top and the bottom of the shape.
    /// </param>
    /// <param name="invisible">
    ///     Determines whether the node should be invisible.
    /// </param>
    public virtual void SetStyleOptions(
        DotNodeFillStyle? fillStyle = null,
        DotBorderStyle? borderStyle = null,
        DotBorderWeight? borderWeight = null,
        DotCornerStyle? cornerStyle = null,
        bool? diagonals = null,
        bool? invisible = null
    )
    {
        FillStyle = fillStyle;
        BorderStyle = borderStyle;
        BorderWeight = borderWeight;
        CornerStyle = cornerStyle;
        Diagonals = diagonals;
        Invisible = invisible;
    }
}