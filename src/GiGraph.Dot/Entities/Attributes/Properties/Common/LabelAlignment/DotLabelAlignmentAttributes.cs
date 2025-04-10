using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment;

public partial class DotLabelAlignmentAttributes : DotEntityAttributesWithMetadata<IDotLabelAlignmentAttributes, DotLabelAlignmentAttributes>, IDotLabelAlignmentAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotLabelAlignmentAttributes, IDotLabelAlignmentAttributes>().BuildLazy();

    public DotLabelAlignmentAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotLabelAlignmentAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotLabelAlignmentAttributes.Horizontal"/>
    [DotAttributeKey(DotAttributeKeys.LabelJust)]
    public virtual partial DotHorizontalAlignment? Horizontal { get; set; }

    /// <inheritdoc cref="IDotLabelAlignmentAttributes.Vertical"/>
    [DotAttributeKey(DotAttributeKeys.LabelLoc)]
    public virtual partial DotVerticalAlignment? Vertical { get; set; }

    /// <summary>
    ///     Sets label alignment options.
    /// </summary>
    /// <param name="horizontal">
    ///     The horizontal label alignment to set.
    /// </param>
    /// <param name="vertical">
    ///     The vertical label alignment to set.
    /// </param>
    public virtual void Set(DotHorizontalAlignment? horizontal, DotVerticalAlignment? vertical)
    {
        Horizontal = horizontal;
        Vertical = vertical;
    }

    /// <summary>
    ///     Sets label alignment.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public virtual void Set(DotAlignment alignment)
    {
        Set(new DotAlignmentProperties(alignment));
    }

    /// <summary>
    ///     Sets label alignment.
    /// </summary>
    /// <param name="alignment">
    ///     The alignment to set.
    /// </param>
    public virtual void Set(DotAlignmentProperties alignment)
    {
        Set(alignment.Horizontal, alignment.Vertical);
    }
}