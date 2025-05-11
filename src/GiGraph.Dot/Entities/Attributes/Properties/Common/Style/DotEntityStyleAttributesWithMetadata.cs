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
    protected DotStyles? Style
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
    ///     Determines if the default style is assigned to the element, that is, if the Graphviz 'style' attribute is set and has the
    ///     value of <see cref="DotStyles.Default"/>. Use the <see cref="SetDefaultStyleOptions"/> method to set the default style on the
    ///     element.
    /// </summary>
    [Pure]
    public virtual bool HasDefaultStyleOptions() => Style == DotStyles.Default;

    /// <summary>
    ///     Assigns the default style option flags to the element. Useful when the style of elements of the current type is set globally
    ///     and needs to be restored to the default value for the current element. To check if the default style is set for the current
    ///     element, use the <see cref="HasDefaultStyleOptions"/> method.
    /// </summary>
    public virtual void SetDefaultStyleOptions()
    {
        Style = DotStyles.Default;
    }
}