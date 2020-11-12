using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Metadata;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public partial class DotNodeAttributes : DotClusterNodeCommonAttributes<IDotNodeAttributes>, IDotNodeAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup NodeAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeAttributes, IDotNodeAttributes>().Build();

        protected DotNodeAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEntityHyperlinkAttributes hyperlinkAttributes,
            DotEntityFontAttributes fontAttributes,
            DotNodeStyleAttributes styleAttributes,
            DotNodeImageAttributes imageAttributes,
            DotNodeGeometryAttributes geometryAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
            Font = fontAttributes;
            Style = styleAttributes;
            Image = imageAttributes;
            Geometry = geometryAttributes;
        }

        public DotNodeAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                NodeAttributesKeyLookup,
                new DotEntityHyperlinkAttributes(attributes),
                new DotEntityFontAttributes(attributes),
                new DotNodeStyleAttributes(attributes),
                new DotNodeImageAttributes(attributes),
                new DotNodeGeometryAttributes(attributes)
            )
        {
        }

        public DotNodeAttributes()
            : this(new DotAttributeCollection())
        {
        }

        /// <summary>
        ///     Font properties.
        /// </summary>
        public virtual DotEntityFontAttributes Font { get; }

        /// <summary>
        ///     Node image properties.
        /// </summary>
        public virtual DotNodeImageAttributes Image { get; }

        /// <summary>
        ///     Node geometry properties applicable if <see cref="Shape" /> is set to <see cref="DotNodeShape.Polygon" />.
        /// </summary>
        public virtual DotNodeGeometryAttributes Geometry { get; }

        /// <summary>
        ///     Style options.
        /// </summary>
        // the attribute key is added here redundantly so it appears in attribute key mapping
        [DotAttributeKey(DotEntityStyleAttributes.StyleKey)]
        public virtual DotNodeStyleAttributes Style { get; }

        // accessible only through the interface
        [DotAttributeKey(DotEntityStyleAttributes.StyleKey)]
        DotStyles? IDotNodeAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotStyles?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStyleAttribute(k, v.Value));
        }

        // overridden to inherit comment from interface
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        // overridden to inherit comment from interface
        public override string ColorScheme
        {
            get => base.ColorScheme;
            set => base.ColorScheme = value;
        }

        // overridden to inherit comment from interface
        public override DotColorDefinition Color
        {
            get => base.Color;
            set => base.Color = value;
        }

        // overridden to inherit comment from interface
        public override DotColorDefinition FillColor
        {
            get => base.FillColor;
            set => base.FillColor = value;
        }

        // overridden to inherit comment from interface
        public override int? GradientAngle
        {
            get => base.GradientAngle;
            set => base.GradientAngle = value;
        }

        // overridden to inherit comment from interface
        public override DotVerticalAlignment? VerticalLabelAlignment
        {
            get => base.VerticalLabelAlignment;
            set => base.VerticalLabelAlignment = value;
        }

        // overridden to inherit comment from interface
        public override DotEscapeString Tooltip
        {
            get => base.Tooltip;
            set => base.Tooltip = value;
        }

        // overridden to inherit comment from interface
        public override DotPoint Margin
        {
            get => base.Margin;
            set => base.Margin = value;
        }

        // overridden to inherit comment from interface
        public override double? BorderWidth
        {
            get => base.BorderWidth;
            set => base.BorderWidth = value;
        }

        // overridden to inherit comment from interface
        public override int? SortIndex
        {
            get => base.SortIndex;
            set => base.SortIndex = value;
        }

        [DotAttributeKey(DotAttributeKeys.Comment)]
        public virtual string Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.XLabel)]
        public virtual DotLabel ExternalLabel
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLabelAttribute(k, v));
        }


        [DotAttributeKey(DotAttributeKeys.Ordering)]
        public virtual DotEdgeOrderingMode? EdgeOrderingMode
        {
            get => GetValueAs<DotEdgeOrderingMode>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotEdgeOrderingMode?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeOrderingModeAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Shape)]
        public virtual DotNodeShape? Shape
        {
            get => GetValueAs<DotNodeShape>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotNodeShape?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotNodeShapeAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Width)]
        public virtual double? Width
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Width), v.Value, "The width must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Height)]
        public virtual double? Height
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Height), v.Value, "The height must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.FixedSize)]
        public virtual DotNodeSizing? Sizing
        {
            get => GetValueAs<DotNodeSizing>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotNodeSizing?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotNodeSizingAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Group)]
        public virtual string GroupName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        protected override void SetFillStyle(DotStyles fillStyle)
        {
            Style.FillStyle = (DotNodeFillStyle) fillStyle;
        }
    }
}