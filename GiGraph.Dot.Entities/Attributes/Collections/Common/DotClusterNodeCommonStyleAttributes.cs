using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public abstract class DotClusterNodeCommonStyleAttributes<TFillStyle, TFillStyleOptions> : DotStyleAttributes
        where TFillStyle : Enum
        where TFillStyleOptions : DotClusterNodeCommonStyleOptions<TFillStyle>
    {
        protected DotClusterNodeCommonStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Gets or sets a fill style for the node.
        /// </summary>
        public virtual TFillStyle FillStyle
        {
            get => GetPart<TFillStyle>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Gets or sets a border style for the node.
        /// </summary>
        public virtual DotBorderStyle BorderStyle
        {
            get => GetPart<DotBorderStyle>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Gets or sets a border weight for the node.
        /// </summary>
        public virtual DotBorderWeight BorderWeight
        {
            get => GetPart<DotBorderWeight>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Gets or sets a corner style for the node.
        /// </summary>
        public virtual DotCornerStyle CornerStyle
        {
            get => GetPart<DotCornerStyle>();
            set => SetPart(value);
        }

        /// <summary>
        ///     Gets or sets a value indicating if the element is invisible.
        /// </summary>
        public virtual bool Invisible
        {
            get => HasOptions(DotStyles.Invisible);
            set => ApplyOption(DotStyles.Invisible, value);
        }

        /// <summary>
        ///     Applies the specified style options to the node.
        /// </summary>
        /// <param name="options">
        ///     The options to apply.
        /// </param>
        public virtual void Set(TFillStyleOptions options)
        {
            Set(options.FillStyle, options.BorderStyle, options.BorderWeight, options.CornerStyle, options.Invisible);
        }

        /// <summary>
        ///     Applies the specified style options to the node.
        /// </summary>
        /// <param name="fillStyle">
        ///     The fill style to set.
        /// </param>
        /// <param name="borderStyle">
        ///     The border style to set.
        /// </param>
        /// <param name="borderWeight">
        ///     The border weight to set.
        /// </param>
        /// <param name="cornerStyle">
        ///     The corner style to set.
        /// </param>
        /// <param name="invisible">
        ///     Determines whether the node should be invisible.
        /// </param>
        public virtual void Set(TFillStyle fillStyle = default, DotBorderStyle borderStyle = default, DotBorderWeight borderWeight = default, DotCornerStyle cornerStyle = default, bool invisible = false)
        {
            FillStyle = fillStyle;
            BorderStyle = borderStyle;
            BorderWeight = borderWeight;
            CornerStyle = cornerStyle;
            Invisible = invisible;
        }

        /// <summary>
        ///     Copies style properties from the specified instance.
        /// </summary>
        /// <param name="source">
        ///     The instance to copy the properties from.
        /// </param>
        protected virtual void CopyFrom(DotClusterNodeCommonStyleAttributes<TFillStyle, TFillStyleOptions> source)
        {
            Set(source.FillStyle, source.BorderStyle, source.BorderWeight, source.CornerStyle, source.Invisible);
        }
    }
}