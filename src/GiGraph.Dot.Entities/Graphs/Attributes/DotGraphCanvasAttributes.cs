using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Orientation;
using GiGraph.Dot.Types.Viewport;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public class DotGraphCanvasAttributes : DotEntityAttributesWithMetadata<IDotGraphCanvasAttributes, DotGraphCanvasAttributes>, IDotGraphCanvasAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> GraphCanvasAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphCanvasAttributes, IDotGraphCanvasAttributes>().BuildLazy();

        public DotGraphCanvasAttributes(DotAttributeCollection attributes)
            : base(attributes, GraphCanvasAttributesKeyLookup)
        {
        }

        protected DotGraphCanvasAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.BackgroundColor" />
        [DotAttributeKey(DotAttributeKeys.BgColor)]
        public virtual DotColorDefinition BackgroundColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.GradientFillAngle" />
        [DotAttributeKey(DotAttributeKeys.GradientAngle)]
        public virtual int? GradientFillAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.CenterDrawing" />
        [DotAttributeKey(DotAttributeKeys.Center)]
        public virtual bool? CenterDrawing
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Orientation" />
        [DotAttributeKey(DotAttributeKeys.Orientation)]
        public virtual DotOrientation? Orientation
        {
            get => GetValueAs<DotOrientation>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.OrientationAngle" />
        [DotAttributeKey(DotAttributeKeys.Rotate)]
        public virtual int? OrientationAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.LandscapeOrientation" />
        [DotAttributeKey(DotAttributeKeys.Landscape)]
        public virtual bool? LandscapeOrientation
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Dpi" />
        [DotAttributeKey(DotAttributeKeys.Dpi)]
        public virtual double? Dpi
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Resolution" />
        [DotAttributeKey(DotAttributeKeys.Resolution)]
        public virtual double? Resolution
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Size" />
        [DotAttributeKey(DotAttributeKeys.Size)]
        public virtual DotPoint Size
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Viewport" />
        [DotAttributeKey(DotAttributeKeys.Viewport)]
        public virtual DotViewport Viewport
        {
            get => GetValueAs<DotViewport>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Scaling" />
        [DotAttributeKey(DotAttributeKeys.Ratio)]
        public virtual DotGraphScalingDefinition Scaling
        {
            get => GetValueAsGraphScalingDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Margin" />
        [DotAttributeKey(DotAttributeKeys.Margin)]
        public virtual DotPoint Margin
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotGraphCanvasAttributes.Padding" />
        [DotAttributeKey(DotAttributeKeys.Pad)]
        public virtual DotPoint Padding
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        /// <summary>
        ///     Copies canvas attributes from the specified instance.
        /// </summary>
        /// <param name="attributes">
        ///     The instance to copy the attributes from.
        /// </param>
        public virtual void Set(IDotGraphCanvasAttributes attributes)
        {
            BackgroundColor = attributes.BackgroundColor;
            CenterDrawing = attributes.CenterDrawing;
            Dpi = attributes.Dpi;
            GradientFillAngle = attributes.GradientFillAngle;
            LandscapeOrientation = attributes.LandscapeOrientation;
            Margin = attributes.Margin;
            Orientation = attributes.Orientation;
            OrientationAngle = attributes.OrientationAngle;
            Padding = attributes.Padding;
            Resolution = attributes.Resolution;
            Scaling = attributes.Scaling;
            Size = attributes.Size;
            Viewport = attributes.Viewport;
        }
    }
}