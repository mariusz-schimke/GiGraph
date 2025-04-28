using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EnumHelpers;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

public abstract class DotEntityStyleAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>(
    DotAttributeCollection attributes,
    Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup
)
    : DotEntityAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>(attributes, attributeKeyLookup), IDotEntityStyleAttributes
    where TEntityAttributeProperties : DotEntityStyleAttributesWithMetadata<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
{
    private DotStyles? Style
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

    /// <summary>
    ///     Determines if any style is assigned to the element, that is, if the Graphviz 'style' attribute has any value specified (is
    ///     not null).
    /// </summary>
    [Pure]
    public virtual bool HasStyleOptions() => Style.HasValue;

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

    /// <summary>
    ///     Clears the style option flags of the element so that no style is set. This implies that the Graphviz 'style' attribute won't
    ///     be rendered for the current element at all.
    /// </summary>
    public virtual void ClearStyleOptions()
    {
        Style = null;
    }

    /// <summary>
    ///     Includes the specified option in the style.
    /// </summary>
    protected virtual void SetStyleOption(DotStyles option)
    {
        Style = Style.GetValueOrDefault(option) | option;
    }

    /// <summary>
    ///     Resets the specified style option in the style. If the style isn't set yet (is null), it will be set to the default value.
    /// </summary>
    protected virtual void ResetStyleOption(DotStyles option)
    {
        Style = ResetStyleOption(Style, option);
    }

    /// <summary>
    ///     Removes the specified style option from the style. If the style isn't set yet, it will remain unset (null). If the result of
    ///     the removal is the default style, the style will be nullified.
    /// </summary>
    protected virtual void RemoveStyleOption(DotStyles option)
    {
        var result = ResetStyleOption(Style, option);
        SetStyleOrNullIfDefault(result);
    }

    [Pure]
    protected virtual bool? HasStyleOption(DotStyles option) => Style?.HasFlag(option);

    protected virtual void SetStyleOption(DotStyles option, bool? value)
    {
        switch (value)
        {
            case true:
                SetStyleOption(option);
                break;
            case false:
                ResetStyleOption(option);
                break;
            default:
                RemoveStyleOption(option);
                break;
        }
    }

    protected virtual void SetPartialStyleOption<TPartialStyle>(TPartialStyle? option)
        where TPartialStyle : struct, Enum
    {
        var currentStyle = Style.GetValueOrDefault(DotStyles.Default);

        if (option.HasValue)
        {
            Style = DotPartialEnumMapper.ReplacePartialFlags(option.Value, currentStyle);
        }
        else
        {
            var result = DotPartialEnumMapper.ClearPartialFlags<TPartialStyle, DotStyles>(currentStyle);
            SetStyleOrNullIfDefault(result);
        }
    }

    [Pure]
    protected virtual TPartialStyle? GetPartialStyleOption<TPartialStyle>()
        where TPartialStyle : struct, Enum =>
        Style.HasValue
            ? DotPartialEnumMapper.ExtractPartialFlags<TPartialStyle, DotStyles>(Style.Value)
            : null;

    private void SetStyleOrNullIfDefault(DotStyles result)
    {
        Style = result == DotStyles.Default ? null : result;
    }

    protected static DotStyles ResetStyleOption(DotStyles? style, DotStyles option) => style.GetValueOrDefault(option) & ~option;
}