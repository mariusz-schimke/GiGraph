using System;

namespace GiGraph.Dot.Entities.Types.Styles
{
    public abstract class DotClusterNodeCommonStyleOptions<TFillStyle>
        where TFillStyle : Enum
    {
        /// <summary>
        ///     Gets or sets a fill style for the element.
        /// </summary>
        public virtual TFillStyle FillStyle { get; set; }

        /// <summary>
        ///     Gets or sets a border style for the element.
        /// </summary>
        public virtual DotBorderStyle BorderStyle { get; set; }

        /// <summary>
        ///     Gets or sets a border weight for the element.
        /// </summary>
        public virtual DotBorderWeight BorderWeight { get; set; }

        /// <summary>
        ///     Gets or sets a corner style for the element.
        /// </summary>
        public virtual DotCornerStyle CornerStyle { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the element is invisible.
        /// </summary>
        public virtual bool Invisible { get; set; }
    }
}