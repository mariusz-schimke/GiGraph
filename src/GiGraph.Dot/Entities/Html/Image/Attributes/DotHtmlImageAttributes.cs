using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Images;

namespace GiGraph.Dot.Entities.Html.Image.Attributes;

public class DotHtmlImageAttributes : DotHtmlElementAttributes<IDotHtmlImageAttributes, DotHtmlImageAttributes>, IDotHtmlImageAttributes
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

    [DotAttributeKey("src")]
    public virtual string? Source
    {
        get => GetValueAsString(MethodBase.GetCurrentMethod()!);
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value);
    }

    [DotAttributeKey("scale")]
    public virtual DotImageScaling? Scaling
    {
        get => GetValueAs<DotImageScaling>(MethodBase.GetCurrentMethod()!, out var result) ? result : null;
        set => SetOrRemove(MethodBase.GetCurrentMethod()!, value.HasValue, () => value!.Value);
    }
}