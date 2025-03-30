using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.ClusterNode;

// todo: usunąć
public abstract class DotClusterNodeCommonStyleAttributeOptions<TFillStyle, TStyleProperties> : DotStyleAttributeOptions
    where TFillStyle : struct, Enum
    where TStyleProperties : DotClusterNodeCommonStyleProperties<TFillStyle>
{
    protected DotClusterNodeCommonStyleAttributeOptions(DotAttributeCollection attributes)
        : base(attributes)
    {
    }

    /// <summary>
    ///     Gets or sets a fill style.
    /// </summary>
    public virtual TFillStyle FillStyle
    {
        get => GetPart<TFillStyle>();
        set => SetPart(value);
    }

    /// <summary>
    ///     Gets or sets a border style.
    /// </summary>
    public virtual DotBorderStyle BorderStyle
    {
        get => GetPart<DotBorderStyle>();
        set => SetPart(value);
    }

    /// <summary>
    ///     Gets or sets a border weight.
    /// </summary>
    public virtual DotBorderWeight BorderWeight
    {
        get => GetPart<DotBorderWeight>();
        set => SetPart(value);
    }

    /// <summary>
    ///     Gets or sets a corner style.
    /// </summary>
    public virtual DotCornerStyle CornerStyle
    {
        get => GetPart<DotCornerStyle>();
        set => SetPart(value);
    }

    /// <summary>
    ///     When set, makes the element invisible.
    /// </summary>
    public virtual bool Invisible
    {
        get => HasOption(DotStyles.Invisible);
        set => ModifyOption(DotStyles.Invisible, value);
    }

    /// <summary>
    ///     Applies the specified style options.
    /// </summary>
    /// <param name="options">
    ///     The options to apply.
    /// </param>
    public virtual void Set(TStyleProperties options)
    {
        SetProperties(options.FillStyle, options.BorderStyle, options.BorderWeight, options.CornerStyle, options.Invisible);
    }

    /// <summary>
    ///     Copies style options from the specified instance.
    /// </summary>
    /// <param name="source">
    ///     The instance to copy the options from.
    /// </param>
    protected virtual void CopyFrom(DotClusterNodeCommonStyleAttributeOptions<TFillStyle, TStyleProperties> source)
    {
        SetProperties(source.FillStyle, source.BorderStyle, source.BorderWeight, source.CornerStyle, source.Invisible);
    }

    protected virtual void SetProperties(TFillStyle fillStyle, DotBorderStyle borderStyle, DotBorderWeight borderWeight, DotCornerStyle cornerStyle, bool invisible)
    {
        FillStyle = fillStyle;
        BorderStyle = borderStyle;
        BorderWeight = borderWeight;
        CornerStyle = cornerStyle;
        Invisible = invisible;
    }
}