using System;

namespace GiGraph.Dot.Entities.Types.Styles
{
    public abstract class DotFillableEntityStyleOptions<TFillStyle> : DotCommonStyleOptions
        where TFillStyle : Enum
    {
        /// <summary>
        ///     Gets or sets a border style for the element.
        /// </summary>
        public virtual DotBorderStyle Border { get; set; }

        /// <summary>
        ///     Gets or sets a border weight for the element.
        /// </summary>
        public virtual DotBorderWeight Weight { get; set; }

        /// <summary>
        ///     Gets or sets a corner style for the element.
        /// </summary>
        public virtual DotCornerStyle Corners { get; set; }

        /// <summary>
        ///     Gets or sets a fill style for the element.
        /// </summary>
        public virtual TFillStyle Fill { get; set; }
    }
}