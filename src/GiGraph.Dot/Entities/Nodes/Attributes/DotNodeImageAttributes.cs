using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public partial class DotNodeImageAttributes : DotEntityAttributesWithMetadata<IDotNodeImageAttributes, DotNodeImageAttributes>, IDotNodeImageAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeImageAttributes, IDotNodeImageAttributes>().BuildLazy();

    public DotNodeImageAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotNodeImageAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotNodeImageAttributes.Path"/>
    [DotAttributeKey(DotAttributeKeys.Image)]
    public virtual partial string? Path { get; set; }

    /// <inheritdoc cref="IDotNodeImageAttributes.Alignment"/>
    [DotAttributeKey(DotAttributeKeys.ImagePos)]
    public virtual partial DotAlignment? Alignment { get; set; }

    /// <inheritdoc cref="IDotNodeImageAttributes.Scaling"/>
    [DotAttributeKey(DotAttributeKeys.ImageScale)]
    public virtual partial DotImageScaling? Scaling { get; set; }

    /// <summary>
    ///     Specifies image attributes.
    /// </summary>
    /// <param name="path">
    ///     The path to an image.
    /// </param>
    /// <param name="alignment">
    ///     The alignment of the image.
    /// </param>
    /// <param name="scaling">
    ///     The scaling option to apply to the image.
    /// </param>
    public virtual void Set(string? path, DotAlignment? alignment = null, DotImageScaling? scaling = null)
    {
        Path = path;
        Alignment = alignment;
        Scaling = scaling;
    }

    /// <summary>
    ///     Specifies image attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The image attributes to set.
    /// </param>
    public virtual void Set(DotImage attributes)
    {
        Set(attributes.Path, attributes.Alignment, attributes.Scaling);
    }
}