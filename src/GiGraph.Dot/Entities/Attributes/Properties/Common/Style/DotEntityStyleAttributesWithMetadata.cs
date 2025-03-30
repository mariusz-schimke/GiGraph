using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EnumHelpers;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

public abstract partial class DotEntityStyleAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>(
    DotAttributeCollection attributes,
    Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup
)
    : DotEntityAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>(attributes, attributeKeyLookup)
    where TEntityAttributeProperties : DotEntityStyleAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
{
    [DotAttributeKey(DotAttributeKeys.Style)]
    protected virtual partial DotStyles? Style { get; set; }

    /// <summary>
    ///     Determines if any style is assigned to the element, that is, if the Graphviz 'style' attribute is set.
    /// </summary>
    [Pure]
    public virtual bool HasStyleModifiers() => Style.HasValue;

    /// <summary>
    ///     Determines if the default style is assigned to the element, that is, if the Graphviz 'style' attribute is set and has the
    ///     value of <see cref="DotStyles.Default"/>. Use the <see cref="RestoreDefaultStyleModifiers"/> method to set the default style on
    ///     the element.
    /// </summary>
    [Pure]
    public virtual bool HasDefaultStyleModifiers() => Style == DotStyles.Default;

    /// <summary>
    ///     Clears the style flags of the element so that no style is set. This implies that the Graphviz 'style' attribute won't be
    ///     rendered for the current element.
    /// </summary>
    public virtual void RemoveStyleModifiers()
    {
        Style = null;
    }

    /// <summary>
    ///     Assigns the default style to the element. Useful when the style of elements of the current type is set globally, and needs to
    ///     be restored to the default value for the current element. To check if the default style is set for the current element, use
    ///     the <see cref="HasDefaultStyleModifiers"/> method.
    /// </summary>
    public virtual void RestoreDefaultStyleModifiers()
    {
        Style = DotStyles.Default;
    }

    protected virtual void SetStyleModifier(DotStyles flag)
    {
        Style = Style.GetValueOrDefault(flag) | flag;
    }

    protected virtual void ResetStyleModifier(DotStyles flag)
    {
        Style &= ~flag;
    }

    [Pure]
    protected virtual bool HasStyleModifier(DotStyles flag) => Style.GetValueOrDefault(DotStyles.Default).HasFlag(flag);

    protected virtual void SetStyleModifier(DotStyles flag, bool value)
    {
        if (value)
        {
            SetStyleModifier(flag);
        }
        else
        {
            ResetStyleModifier(flag);
        }
    }

    protected virtual void SetPartialStyleModifier<TPart>(TPart style)
        where TPart : struct, Enum
    {
        Style = DotPartialEnumMapper.ToComplete(style, Style.GetValueOrDefault(DotStyles.Default));
    }

    [Pure]
    protected virtual TPart GetPartialStyleModifier<TPart>()
        where TPart : struct, Enum =>
        DotPartialEnumMapper.ToPartial<DotStyles, TPart>(Style.GetValueOrDefault(DotStyles.Default));
}