using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Html.Font.Attributes;

public partial class DotHtmlFontAttributes : DotHtmlElementAttributes<IDotHtmlFontAttributes, DotHtmlFontAttributes>, IDotHtmlFontAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlFontAttributes, IDotHtmlFontAttributes>().BuildLazy();

    public DotHtmlFontAttributes(DotHtmlAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlFontAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHtmlFontAttributes.Name"/>
    [DotAttributeKey("face")]
    public virtual partial string? Name { get; set; }

    /// <inheritdoc cref="IDotHtmlFontAttributes.Size"/>
    [DotAttributeKey("point-size")]
    public virtual partial double? Size { get; set; }

    /// <inheritdoc cref="IDotHtmlFontAttributes.Color"/>
    [DotAttributeKey("color")]
    public virtual partial DotColor? Color { get; set; }
}