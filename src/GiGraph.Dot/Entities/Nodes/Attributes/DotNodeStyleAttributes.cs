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
    public virtual DotNodeFillStyle FillStyle
    {
        get => this.GetPartialStyleOption<DotNodeFillStyle, DotStyles>();
        set => this.SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a border style.
    /// </summary>
    public virtual DotBorderStyle BorderStyle
    {
        get => this.GetPartialStyleOption<DotBorderStyle, DotStyles>();
        set => this.SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a border weight.
    /// </summary>
    public virtual DotBorderWeight BorderWeight
    {
        get => this.GetPartialStyleOption<DotBorderWeight, DotStyles>();
        set => this.SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a corner style.
    /// </summary>
    public virtual DotCornerStyle CornerStyle
    {
        get => this.GetPartialStyleOption<DotCornerStyle, DotStyles>();
        set => this.SetPartialStyleOption(value);
    }

    /// <summary>
    ///     When set, causes small chords to be drawn near the vertices of the node’s polygon or, in case of circles and ellipses, two
    ///     chords near the top and the bottom of the shape.
    /// </summary>
    public virtual bool Diagonals
    {
        get => this.HasStyleOption(DotStyles.Diagonals);
        set => this.SetStyleOption(DotStyles.Diagonals, value);
    }

    /// <summary>
    ///     When set, makes the element invisible.
    /// </summary>
    public virtual bool Invisible
    {
        get => this.HasStyleOption(DotStyles.Invisible);
        set => this.SetStyleOption(DotStyles.Invisible, value);
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
        FillStyle = options.FillStyle;
        BorderStyle = options.BorderStyle;
        BorderWeight = options.BorderWeight;
        CornerStyle = options.CornerStyle;
        Diagonals = options.Diagonals;
        Invisible = options.Invisible;
    }

    /// <summary>
    ///     Applies the specified border style.
    /// </summary>
    /// <param name="style">
    ///     The border style to set.
    /// </param>
    /// <param name="weight">
    ///     The border weight to set.
    /// </param>
    /// <param name="width">
    ///     Specifies the width of the border in points (default: 1.0, minimum: 0.0).
    /// </param>
    /// <param name="color">
    ///     The color to set for the border. If the node has a <see cref="DotNodeFillStyle.Regular"/> fill style but no
    ///     <see cref="FillColor"/> is specified, then this border color will also be used to fill the node.
    /// </param>
    /// <param name="peripheries">
    ///     Sets the number of peripheries used in polygonal node shapes (<see cref="IDotNodeAttributes.Shape"/>). The default value is
    ///     shape dependent, the minimum value is 0.
    /// </param>
    public virtual void SetBorder(DotBorderStyle style = default, DotBorderWeight weight = default, double? width = null, DotColor? color = null, int? peripheries = null)
    {
        BorderStyle = style;
        BorderWeight = weight;
        BorderWidth = width;
        Color = color;
        Peripheries = peripheries;
    }

    /// <summary>
    ///     Applies the specified border style.
    /// </summary>
    /// <param name="style">
    ///     The border style to set.
    /// </param>
    /// <param name="weight">
    ///     The border weight to set.
    /// </param>
    /// <param name="width">
    ///     Specifies the width of the border in points (default: 1.0, minimum: 0.0).
    /// </param>
    public virtual void SetBorderStyle(DotBorderStyle style = default, DotBorderWeight weight = default, double? width = null)
    {
        BorderStyle = style;
        BorderWeight = weight;
        BorderWidth = width;
    }
}