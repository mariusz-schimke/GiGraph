using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Image.Attributes;

public partial class DotHtmlImageAttributes : DotHtmlElementAttributes<IDotHtmlImageAttributes, DotHtmlImageAttributes>, IDotHtmlImageAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlImageAttributes, IDotHtmlImageAttributes>().BuildLazy();

    public DotHtmlImageAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlImageAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHtmlImageAttributes.Source"/>
    [DotAttributeKey("src")]
    public virtual partial string? Source { get; set; }

    /// <inheritdoc cref="IDotHtmlImageAttributes.Scaling"/>
    [DotAttributeKey("scale")]
    public virtual partial DotImageScaling? Scaling { get; set; }
}