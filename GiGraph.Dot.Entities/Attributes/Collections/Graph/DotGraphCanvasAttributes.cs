using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Scaling;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public class DotGraphCanvasAttributes : DotEntityAttributes<IDotGraphCanvasAttributes>, IDotGraphCanvasAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphCanvasAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphCanvasAttributes, IDotGraphCanvasAttributes>().Build();

        protected DotGraphCanvasAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotGraphCanvasAttributes(DotAttributeCollection attributes)
            : base(attributes, GraphCanvasAttributesKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.BackgroundColor" />
        [DotAttributeKey(DotAttributeKeys.BgColor)]
        public virtual DotColorDefinition BackgroundColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.GradientFillAngle" />
        [DotAttributeKey(DotAttributeKeys.GradientAngle)]
        public virtual int? GradientFillAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.CenterDrawing" />
        [DotAttributeKey(DotAttributeKeys.Center)]
        public virtual bool? CenterDrawing
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Orientation" />
        [DotAttributeKey(DotAttributeKeys.Orientation)]
        public virtual DotOrientation? Orientation
        {
            get => GetValueAs<DotOrientation>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotOrientation?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotOrientationAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.OrientationAngle" />
        [DotAttributeKey(DotAttributeKeys.Rotate)]
        public virtual int? OrientationAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Landscape" />
        [DotAttributeKey(DotAttributeKeys.Landscape)]
        public virtual bool? Landscape
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Dpi" />
        [DotAttributeKey(DotAttributeKeys.Dpi)]
        public virtual double? Dpi
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Dpi), v.Value, "DPI must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Resolution" />
        [DotAttributeKey(DotAttributeKeys.Resolution)]
        public virtual double? Resolution
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Resolution), v.Value, "Resolution must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Size" />
        [DotAttributeKey(DotAttributeKeys.Size)]
        public virtual DotPoint Size
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Scaling" />
        [DotAttributeKey(DotAttributeKeys.Ratio)]
        public virtual DotGraphScalingDefinition Scaling
        {
            get
            {
                return GetValueAs<DotGraphScalingDefinition>
                (
                    MethodBase.GetCurrentMethod(),
                    out var value,
                    v => v is int i ? (true, new DotGraphScalingAspectRatio(i)) : (false, default),
                    v => v is double d ? (true, new DotGraphScalingAspectRatio(d)) : (false, default),
                    v => v is DotGraphScaling s ? (true, new DotGraphScalingOption(s)) : (false, default)
                )
                    ? value
                    : null;
            }
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotGraphScalingDefinitionAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Margin" />
        [DotAttributeKey(DotAttributeKeys.Margin)]
        public virtual DotPoint Margin
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Padding" />
        [DotAttributeKey(DotAttributeKeys.Pad)]
        public virtual DotPoint Padding
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }

        /// <summary>
        ///     Copies canvas properties from the specified instance.
        /// </summary>
        /// <param name="source">
        ///     The instance to copy the properties from.
        /// </param>
        public virtual void CopyFrom(IDotGraphCanvasAttributes source)
        {
            BackgroundColor = source.BackgroundColor;
            CenterDrawing = source.CenterDrawing;
            Dpi = source.Dpi;
            GradientFillAngle = source.GradientFillAngle;
            Landscape = source.Landscape;
            Margin = source.Margin;
            Orientation = source.Orientation;
            OrientationAngle = source.OrientationAngle;
            Padding = source.Padding;
            Resolution = source.Resolution;
            Scaling = source.Scaling;
            Size = source.Size;
        }
    }
}