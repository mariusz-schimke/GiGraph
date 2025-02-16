using System;

namespace GiGraph.Dot.Types.Styling;

public abstract record DotClusterNodeCommonStyleProperties<TFillStyle>(TFillStyle FillStyle, DotBorderStyle BorderStyle, DotBorderWeight BorderWeight, DotCornerStyle CornerStyle, bool Invisible)
    where TFillStyle : struct, Enum
{
    /// <summary>
    ///     The fill style.
    /// </summary>
    public TFillStyle FillStyle { get; init; } = FillStyle;

    /// <summary>
    ///     The border style.
    /// </summary>
    public DotBorderStyle BorderStyle { get; init; } = BorderStyle;

    /// <summary>
    ///     The border weight.
    /// </summary>
    public DotBorderWeight BorderWeight { get; init; } = BorderWeight;

    /// <summary>
    ///     The corner style.
    /// </summary>
    public DotCornerStyle CornerStyle { get; init; } = CornerStyle;

    /// <summary>
    ///     Determines whether the element is invisible.
    /// </summary>
    public bool Invisible { get; init; } = Invisible;
}