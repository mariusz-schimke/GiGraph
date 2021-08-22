using System;

namespace GiGraph.Dot.Types.Styling
{
    public abstract record DotClusterNodeCommonStyleProperties<TFillStyle>(TFillStyle FillStyle, DotBorderStyle BorderStyle, DotBorderWeight BorderWeight, DotCornerStyle CornerStyle, bool Invisible)
        where TFillStyle : Enum
    {
        /// <summary>
        ///     Gets or sets a fill style for the element.
        /// </summary>
        public virtual TFillStyle FillStyle { get; init; } = FillStyle;

        /// <summary>
        ///     Gets or sets a border style for the element.
        /// </summary>
        public virtual DotBorderStyle BorderStyle { get; init; } = BorderStyle;

        /// <summary>
        ///     Gets or sets a border weight for the element.
        /// </summary>
        public virtual DotBorderWeight BorderWeight { get; init; } = BorderWeight;

        /// <summary>
        ///     Gets or sets a corner style for the element.
        /// </summary>
        public virtual DotCornerStyle CornerStyle { get; init; } = CornerStyle;

        /// <summary>
        ///     Gets or sets a value indicating whether the element is invisible.
        /// </summary>
        public virtual bool Invisible { get; init; } = Invisible;
    }
}