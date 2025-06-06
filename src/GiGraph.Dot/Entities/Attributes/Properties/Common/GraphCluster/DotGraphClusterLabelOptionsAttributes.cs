using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;

public partial class DotGraphClusterLabelOptionsAttributes : DotEntityAttributesWithMetadata<IDotGraphClusterLabelOptionsAttributes, DotGraphClusterLabelOptionsAttributes>, IDotGraphClusterLabelOptionsAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphClusterLabelOptionsAttributes, IDotGraphClusterLabelOptionsAttributes>().BuildLazy();

    public DotGraphClusterLabelOptionsAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotGraphClusterLabelOptionsAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotGraphClusterLabelOptionsAttributes.HorizontalAlignment"/>
    [DotAttributeKey(DotAttributeKeys.LabelJust)]
    public virtual partial DotHorizontalAlignment? HorizontalAlignment { get; set; }

    /// <inheritdoc cref="IDotGraphClusterLabelOptionsAttributes.VerticalAlignment"/>
    [DotAttributeKey(DotAttributeKeys.LabelLoc)]
    public virtual partial DotVerticalAlignment? VerticalAlignment { get; set; }

    /// <inheritdoc cref="IDotGraphClusterLabelOptionsAttributes.DisableJustification"/>
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
    public virtual DotGraphClusterLabelOptionsAttributes SetAlignment(DotHorizontalAlignment? horizontal, DotVerticalAlignment? vertical)
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
    public virtual DotGraphClusterLabelOptionsAttributes SetAlignment(DotAlignment alignment) => SetAlignment(new DotAlignmentOptions(alignment));

    /// <summary>
    ///     Sets label alignment.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public virtual DotGraphClusterLabelOptionsAttributes SetAlignment(DotAlignmentOptions alignment) => SetAlignment(alignment.Horizontal, alignment.Vertical);
}