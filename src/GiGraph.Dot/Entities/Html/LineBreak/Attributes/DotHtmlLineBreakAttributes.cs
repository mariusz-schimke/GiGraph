using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.LineBreak.Attributes;

public partial class DotHtmlLineBreakAttributes : DotHtmlElementAttributes<IDotHtmlLineBreakAttributes, DotHtmlLineBreakAttributes>, IDotHtmlLineBreakAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlLineBreakAttributes, IDotHtmlLineBreakAttributes>().BuildLazy();

    public DotHtmlLineBreakAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlLineBreakAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHtmlLineBreakAttributes.LineAlignment"/>
    [DotAttributeKey("align")]
    public virtual partial DotHorizontalAlignment? LineAlignment { get; set; }
}