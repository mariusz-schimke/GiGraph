using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters.Style;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;

public abstract partial class DotGraphClusterCommonStyleAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>(
    DotAttributeCollection attributes,
    Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup
)
    : DotEntityStyleAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>(attributes, attributeKeyLookup),
        IDotGraphClusterCommonStyleAttributes, IDotHasBorderStyleAttributes
    where TEntityAttributeProperties : DotGraphClusterCommonStyleAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
{
    /// <summary>
    ///     Gets or sets a fill style.
    /// </summary>
    public virtual DotClusterFillStyle FillStyle
    {
        get => this.GetPartialStyleOption<DotClusterFillStyle, DotStyles>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a border style.
    /// </summary>
    public virtual DotBorderStyle BorderStyle
    {
        get => this.GetPartialStyleOption<DotBorderStyle, DotStyles>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a border weight.
    /// </summary>
    public virtual DotBorderWeight BorderWeight
    {
        get => this.GetPartialStyleOption<DotBorderWeight, DotStyles>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     Gets or sets a corner style.
    /// </summary>
    public virtual DotCornerStyle CornerStyle
    {
        get => this.GetPartialStyleOption<DotCornerStyle, DotStyles>();
        set => SetPartialStyleOption(value);
    }

    /// <summary>
    ///     When set, makes the element invisible.
    /// </summary>
    public virtual bool Invisible
    {
        get => this.HasStyleOption(DotStyles.Invisible);
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
}