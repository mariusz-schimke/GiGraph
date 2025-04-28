using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters.Style;
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
    public virtual DotClusterFillStyle? FillStyle
    {
        get => GetPartialStyleOption<DotClusterFillStyle>();
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
    ///     When set, makes the element invisible.
    /// </summary>
    public virtual bool? Invisible
    {
        get => HasStyleOption(DotStyles.Invisible);
        set => SetStyleOption(DotStyles.Invisible, value);
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
    ///     Applies the specified style options.
    /// </summary>
    /// <param name="options">
    ///     The options to apply.
    /// </param>
    public virtual void SetStyleOptions(DotClusterStyleOptions options)
    {
        SetStyleOptions(options.FillStyle, options.BorderStyle, options.BorderWeight, options.CornerStyle, options.Invisible);
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
    /// <param name="invisible">
    ///     Determines whether the node should be invisible.
    /// </param>
    public virtual void SetStyleOptions(
        DotClusterFillStyle? fillStyle = null,
        DotBorderStyle? borderStyle = null,
        DotBorderWeight? borderWeight = null,
        DotCornerStyle? cornerStyle = null,
        bool? invisible = null
    )
    {
        FillStyle = fillStyle;
        BorderStyle = borderStyle;
        BorderWeight = borderWeight;
        CornerStyle = cornerStyle;
        Invisible = invisible;
    }
}