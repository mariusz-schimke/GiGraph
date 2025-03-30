using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;

public abstract partial class DotGraphClusterCommonStyleAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>(
    DotAttributeCollection attributes,
    Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup
)
    : DotEntityStyleAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>(attributes, attributeKeyLookup), IDotGraphClusterCommonStyleAttributes
    where TEntityAttributeProperties : DotGraphClusterCommonStyleAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
{
    /// <summary>
    ///     Gets or sets a fill style.
    /// </summary>
    public virtual DotClusterFillStyle FillStyle
    {
        get => GetPartialStyleModifier<DotClusterFillStyle>();
        set => SetPartialStyleModifier(value);
    }

    /// <summary>
    ///     Gets or sets a border style.
    /// </summary>
    public virtual DotBorderStyle BorderStyle
    {
        get => GetPartialStyleModifier<DotBorderStyle>();
        set => SetPartialStyleModifier(value);
    }

    /// <summary>
    ///     Gets or sets a border weight.
    /// </summary>
    public virtual DotBorderWeight BorderWeight
    {
        get => GetPartialStyleModifier<DotBorderWeight>();
        set => SetPartialStyleModifier(value);
    }

    /// <summary>
    ///     Gets or sets a corner style.
    /// </summary>
    public virtual DotCornerStyle CornerStyle
    {
        get => GetPartialStyleModifier<DotCornerStyle>();
        set => SetPartialStyleModifier(value);
    }

    /// <summary>
    ///     When set, makes the element invisible.
    /// </summary>
    public virtual bool Invisible
    {
        get => HasStyleModifier(DotStyles.Invisible);
        set => SetStyleModifier(DotStyles.Invisible, value);
    }

    [DotAttributeKey(DotAttributeKeys.Color)]
    public virtual partial DotColorDefinition? Color { get; set; }

    [DotAttributeKey(DotAttributeKeys.FillColor)]
    public virtual partial DotColorDefinition? FillColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.PenColor)]
    public virtual partial DotColor? BorderColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.PenWidth)]
    public virtual partial double? BorderWidth { get; set; }

    /// <summary>
    ///     Applies the specified style modifiers.
    /// </summary>
    /// <param name="modifiers">
    ///     The options to apply.
    /// </param>
    public virtual void SetStyleModifiers(DotClusterStyleModifiers modifiers)
    {
        SetStyleModifiers(modifiers.FillStyle, modifiers.BorderStyle, modifiers.BorderWeight, modifiers.CornerStyle, modifiers.Invisible);
    }

    /// <summary>
    ///     Applies the specified style modifiers.
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
    /// <param name="invisible">
    ///     Determines whether the node should be invisible.
    /// </param>
    public virtual void SetStyleModifiers(DotClusterFillStyle fillStyle = default, DotBorderStyle borderStyle = default,
        DotBorderWeight borderWeight = default, DotCornerStyle cornerStyle = default, bool invisible = false)
    {
        FillStyle = fillStyle;
        BorderStyle = borderStyle;
        BorderWeight = borderWeight;
        CornerStyle = cornerStyle;
        Invisible = invisible;
    }
}