using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Nodes;
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
        get => GetPartialStyleFlags<DotNodeFillStyle>();
        set => SetPartialStyleFlags(value);
    }

    /// <summary>
    ///     Gets or sets a border style.
    /// </summary>
    public virtual DotBorderStyle BorderStyle
    {
        get => GetPartialStyleFlags<DotBorderStyle>();
        set => SetPartialStyleFlags(value);
    }

    /// <summary>
    ///     Gets or sets a border weight.
    /// </summary>
    public virtual DotBorderWeight BorderWeight
    {
        get => GetPartialStyleFlags<DotBorderWeight>();
        set => SetPartialStyleFlags(value);
    }

    /// <summary>
    ///     Gets or sets a corner style.
    /// </summary>
    public virtual DotCornerStyle CornerStyle
    {
        get => GetPartialStyleFlags<DotCornerStyle>();
        set => SetPartialStyleFlags(value);
    }

    /// <summary>
    ///     When set, causes small chords to be drawn near the vertices of the node’s polygon or, in case of circles and ellipses, two
    ///     chords near the top and the bottom of the shape.
    /// </summary>
    public virtual bool Diagonals
    {
        get => HasStyleFlag(DotStyles.Diagonals);
        set => ModifyStyleFlag(DotStyles.Diagonals, value);
    }

    /// <summary>
    ///     When set, makes the element invisible.
    /// </summary>
    public virtual bool Invisible
    {
        get => HasStyleFlag(DotStyles.Invisible);
        set => ModifyStyleFlag(DotStyles.Invisible, value);
    }

    [DotAttributeKey(DotAttributeKeys.Color)]
    public virtual partial DotColorDefinition? Color { get; set; }

    [DotAttributeKey(DotAttributeKeys.ColorScheme)]
    public virtual partial string? ColorScheme { get; set; }

    [DotAttributeKey(DotAttributeKeys.FillColor)]
    public virtual partial DotColorDefinition? FillColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.GradientAngle)]
    public virtual partial int? GradientFillAngle { get; set; }

    [DotAttributeKey(DotAttributeKeys.PenWidth)]
    public virtual partial double? BorderWidth { get; set; }

    /// <summary>
    ///     Applies the specified style options.
    /// </summary>
    /// <param name="options">
    ///     The options to apply.
    /// </param>
    public virtual void SetOptions(DotNodeStyleOptions options)
    {
        SetOptions(options.FillStyle, options.BorderStyle, options.BorderWeight, options.CornerStyle, options.Diagonals, options.Invisible);
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
    public virtual void SetOptions(DotNodeFillStyle fillStyle = default, DotBorderStyle borderStyle = default, DotBorderWeight borderWeight = default,
        DotCornerStyle cornerStyle = default, bool diagonals = false, bool invisible = false)
    {
        FillStyle = fillStyle;
        BorderStyle = borderStyle;
        BorderWeight = borderWeight;
        CornerStyle = cornerStyle;
        Diagonals = diagonals;
        Invisible = invisible;
    }
}