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
    ///     Determines if any style options are assigned to the element.
    /// </summary>
    [Pure]
    public virtual bool AreStyleOptionsSet() => Style.HasValue;

    /// <summary>
    ///     Determines if the default style is assigned to the element.
    /// </summary>
    [Pure]
    public virtual bool AreDefaultStyleOptionsSet() => Style == DotStyles.Default;

    /// <summary>
    ///     Clears the style options of the element so that no style is set.
    /// </summary>
    public virtual void ClearStyleOptions()
    {
        Style = null;
    }

    /// <summary>
    ///     Assigns the default style to the element. Useful when the style of elements of the current type is set globally, and needs to
    ///     be restored to the default value for the current element.
    /// </summary>
    public virtual void SetDefaultStyleOptions()
    {
        Style = DotStyles.Default;
    }

    protected virtual void SetStyleOption(DotStyles options)
    {
        Style = Style.GetValueOrDefault(options) | options;
    }

    protected virtual void ResetStyleOption(DotStyles options)
    {
        Style &= ~options;
    }

    [Pure]
    protected virtual bool HasStyleOption(DotStyles option) => Style.GetValueOrDefault(DotStyles.Default).HasFlag(option);

    protected virtual void ModifyStyleOption(DotStyles option, bool set)
    {
        if (set)
        {
            SetStyleOption(option);
        }
        else
        {
            ResetStyleOption(option);
        }
    }

    protected virtual void SetPartialStyle<TPart>(TPart style)
        where TPart : struct, Enum
    {
        Style = DotPartialEnumMapper.ToComplete(style, Style.GetValueOrDefault(DotStyles.Default));
    }

    [Pure]
    protected virtual TPart GetPartialStyle<TPart>()
        where TPart : struct, Enum =>
        DotPartialEnumMapper.ToPartial<DotStyles, TPart>(Style.GetValueOrDefault(DotStyles.Default));
}