using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EnumHelpers;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

// TODO: do posprzątania niepotrzebne metody
public partial class DotStyleAttributeOptions(DotAttributeCollection attributes)
{
    protected readonly DotAttributeCollection _attributes = attributes;

    // attribute used only for automatic code generation here
    [DotAttributeKey(DotAttributeKeys.Style)]
    protected virtual partial DotStyles? Style { get; set; }

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

    protected virtual void SetOption(DotStyles options)
    {
        Style = Style.GetValueOrDefault(options) | options;
    }

    protected virtual void ResetOption(DotStyles options)
    {
        Style &= ~options;
    }

    public virtual bool HasOption(DotStyles option) => Style.GetValueOrDefault(DotStyles.Default).HasFlag(option);

    public virtual void ModifyOption(DotStyles option, bool set)
    {
        if (set)
        {
            SetOption(option);
        }
        else
        {
            ResetOption(option);
        }
    }

    public virtual void SetPart<TPart>(TPart style)
        where TPart : struct, Enum
    {
        Style = DotPartialEnumMapper.ToComplete(style, Style.GetValueOrDefault(DotStyles.Default));
    }

    public virtual TPart GetPart<TPart>()
        where TPart : struct, Enum =>
        DotPartialEnumMapper.ToPartial<DotStyles, TPart>(Style.GetValueOrDefault(DotStyles.Default));
}