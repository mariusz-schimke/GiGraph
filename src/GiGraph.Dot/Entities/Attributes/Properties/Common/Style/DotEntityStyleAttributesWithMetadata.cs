using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

public abstract class DotEntityStyleAttributesWithMetadata<TIEntityStyleAttributeProperties, TEntityStyleAttributeProperties>(
    DotAttributeCollection attributes,
    Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup
)
    : DotEntityAttributesWithMetadata<TIEntityStyleAttributeProperties, TEntityStyleAttributeProperties>(attributes, attributeKeyLookup), IDotEntityStyleAttributes, IDotHasStyleOptions<DotStyles>
    where TEntityStyleAttributeProperties : DotEntityStyleAttributesWithMetadata<TIEntityStyleAttributeProperties, TEntityStyleAttributeProperties>, TIEntityStyleAttributeProperties
{
    protected virtual DotStyles? Style
    {
        get => ((IDotEntityStyleAttributes) this).Style;
        set => ((IDotEntityStyleAttributes) this).Style = value;
    }

    [DotAttributeKey(DotAttributeKeys.Style)]
    DotStyles? IDotEntityStyleAttributes.Style
    {
        [DotAttributeKey(DotAttributeKeys.Style)]
        get => _attributes.GetValueAs(DotAttributeKeys.Style, out DotStyles? result) ? result : null;
        [DotAttributeKey(DotAttributeKeys.Style)]
        set => _attributes.SetValueOrRemove(DotAttributeKeys.Style, value);
    }

    DotStyles? IDotHasStyleOptions<DotStyles>.Style
    {
        get => Style;
        set => Style = value;
    }

    /// <summary>
    ///     Determines if the default style is assigned to the element, that is, if the Graphviz 'style' attribute has an empty value.
    ///     Use the <see cref="SetDefaultStyleOptions"/> method to set the default style on the element.
    /// </summary>
    [Pure]
    public virtual bool HasDefaultStyleOptions() => Style == DotStyles.Default;

    /// <summary>
    ///     Assigns an empty 'style' attribute to the element. Useful when the style for the current element type is set globally and
    ///     needs to be restored to the default value for the current element only.
    /// </summary>
    public virtual TEntityStyleAttributeProperties SetDefaultStyleOptions()
    {
        Style = DotStyles.Default;
        return (TEntityStyleAttributeProperties) this;
    }

    /// <summary>
    ///     Indicates whether the element has a 'style' attribute assigned. Returns true if the 'style' attribute has any value,
    ///     including its default value that renders an empty 'style' attribute. The 'style' attribute is a composite of multiple
    ///     options, each of which is exposed and configurable via a dedicated property.
    /// </summary>
    [Pure]
    public bool HasStyleOptions() => Style.HasValue;

    /// <summary>
    ///     Removes the style options of the element if set. The 'style' attribute will not be rendered.
    /// </summary>
    [Pure]
    public TEntityStyleAttributeProperties RemoveStyleOptions()
    {
        Style = null;
        return (TEntityStyleAttributeProperties) this;
    }
}