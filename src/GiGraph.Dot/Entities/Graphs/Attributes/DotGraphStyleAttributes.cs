using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Graphs;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphStyleAttributes : DotEntityStyleAttributesWithMetadata<IDotGraphStyleAttributes, DotGraphStyleAttributes>, IDotGraphStyleAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphStyleAttributes, IDotGraphStyleAttributes>().BuildLazy();

    public DotGraphStyleAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotGraphStyleAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <summary>
    ///     <para>
    ///         Gets or sets the fill style of the graph. The only option applicable is <see cref="DotClusterFillStyle.Radial"/>.
    ///     </para>
    ///     <para>
    ///         Note that this setting is shared with clusters and can't be applied independently.
    ///     </para>
    /// </summary>
    public virtual DotClusterFillStyle FillStyle
    {
        get => GetPartialStyleModifier<DotClusterFillStyle>();
        set => SetPartialStyleModifier(value);
    }

    /// <inheritdoc cref="IDotGraphStyleAttributes.BackgroundColor"/>
    [DotAttributeKey(DotAttributeKeys.BgColor)]
    public virtual partial DotColorDefinition? BackgroundColor { get; set; }

    /// <inheritdoc cref="IDotGraphStyleAttributes.ColorScheme"/>
    [DotAttributeKey(DotAttributeKeys.ColorScheme)]
    public virtual partial string? ColorScheme { get; set; }

    /// <inheritdoc cref="IDotGraphStyleAttributes.GradientFillAngle"/>
    [DotAttributeKey(DotAttributeKeys.GradientAngle)]
    public virtual partial int? GradientFillAngle { get; set; }

    /// <summary>
    ///     Applies the specified style modifiers to the graph.
    /// </summary>
    /// <param name="modifiers">
    ///     The options to apply.
    /// </param>
    public virtual void SetStyleModifiers(DotGraphStyleModifiers modifiers)
    {
        FillStyle = modifiers.FillStyle;
    }
}