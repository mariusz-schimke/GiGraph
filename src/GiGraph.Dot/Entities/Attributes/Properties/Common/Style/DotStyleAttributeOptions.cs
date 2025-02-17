using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EnumHelpers;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

public abstract class DotStyleAttributeOptions
{
    public const string StyleKey = DotAttributeKeys.Style;
    protected readonly DotAttributeCollection _attributes;

    protected DotStyleAttributeOptions(DotAttributeCollection attributes)
    {
        _attributes = attributes;
    }

    protected virtual DotStyles? Style
    {
        get => _attributes.GetValue(StyleKey, out DotStyles? result) ? result : null;
        set => _attributes.SetOrRemove(StyleKey, value);
    }

    /// <summary>
    ///     Determines if any style is assigned to the element.
    /// </summary>
    public virtual bool IsSet() => Style.HasValue;

    /// <summary>
    ///     Determines if the default style is assigned to the element.
    /// </summary>
    public virtual bool IsDefault() => Style == DotStyles.Default;

    /// <summary>
    ///     Removes style from the element.
    /// </summary>
    public virtual void Clear()
    {
        Style = null;
    }

    /// <summary>
    ///     Assigns the default style to the element. Useful when the style of elements of the current type is set globally, and needs to
    ///     be restored to the default value for the current element.
    /// </summary>
    public virtual void SetDefault()
    {
        Style = DotStyles.Default;
    }

    protected virtual void Apply(DotStyles options)
    {
        Style = Style.GetValueOrDefault(options) | options;
    }

    protected virtual void Remove(DotStyles options)
    {
        Style &= ~options;
    }

    protected virtual bool HasOptions(DotStyles options) => Style.GetValueOrDefault(DotStyles.Default).HasFlag(options);

    protected virtual void ApplyOption(DotStyles option, bool set)
    {
        if (set)
        {
            Apply(option);
        }
        else
        {
            Remove(option);
        }
    }

    protected virtual void SetPart<TPart>(TPart style)
        where TPart : struct, Enum
    {
        Style = DotPartialEnumMapper.ToComplete(style, Style.GetValueOrDefault(DotStyles.Default));
    }

    protected virtual TPart GetPart<TPart>()
        where TPart : struct, Enum =>
        DotPartialEnumMapper.ToPartial<DotStyles, TPart>(Style.GetValueOrDefault(DotStyles.Default));
}