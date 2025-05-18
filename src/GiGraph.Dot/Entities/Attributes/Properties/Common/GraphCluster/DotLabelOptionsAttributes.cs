using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;

public partial class DotLabelOptionsAttributes : DotEntityAttributesWithMetadata<IDotLabelOptionsAttributes, DotLabelOptionsAttributes>, IDotLabelOptionsAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotLabelOptionsAttributes, IDotLabelOptionsAttributes>().BuildLazy();

    public DotLabelOptionsAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotLabelOptionsAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotLabelOptionsAttributes.HorizontalAlignment"/>
    [DotAttributeKey(DotAttributeKeys.LabelJust)]
    public virtual partial DotHorizontalAlignment? HorizontalAlignment { get; set; }

    /// <inheritdoc cref="IDotLabelOptionsAttributes.VerticalAlignment"/>
    [DotAttributeKey(DotAttributeKeys.LabelLoc)]
    public virtual partial DotVerticalAlignment? VerticalAlignment { get; set; }

    /// <inheritdoc cref="IDotLabelOptionsAttributes.DisableJustification"/>
    [DotAttributeKey(DotAttributeKeys.NoJustify)]
    public virtual partial bool? DisableJustification { get; set; }

    /// <summary>
    ///     Sets label alignment.
    /// </summary>
    /// <param name="horizontal">
    ///     The horizontal label alignment to set.
    /// </param>
    /// <param name="vertical">
    ///     The vertical label alignment to set.
    /// </param>
    public virtual DotLabelOptionsAttributes SetAlignment(DotHorizontalAlignment? horizontal, DotVerticalAlignment? vertical)
    {
        HorizontalAlignment = horizontal;
        VerticalAlignment = vertical;
        return this;
    }

    /// <summary>
    ///     Sets label alignment.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public virtual DotLabelOptionsAttributes SetAlignment(DotAlignment alignment) => SetAlignment(new DotAlignmentOptions(alignment));

    /// <summary>
    ///     Sets label alignment.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public virtual DotLabelOptionsAttributes SetAlignment(DotAlignmentOptions alignment) => SetAlignment(alignment.Horizontal, alignment.Vertical);
}