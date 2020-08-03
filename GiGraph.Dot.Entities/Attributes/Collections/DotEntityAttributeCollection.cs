using System;
using System.Drawing;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributeCollection<TExposedEntityAttributes> : DotAttributeCollection
    {
        [DotAttributeKey("color")]
        public virtual DotColorDefinition Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey("colorscheme")]
        public virtual string ColorScheme
        {
            get => GetValueAs<string>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("bgcolor")]
        public virtual DotColorDefinition BackgroundColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey("fillcolor")]
        public virtual DotColorDefinition FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey("gradientangle")]
        public virtual int? GradientAngle
        {
            get => GetValueAs<int>(MethodBase.GetCurrentMethod(), out var result) ? result : (int?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey("peripheries")]
        public virtual int? Peripheries
        {
            get => GetValueAs<int>(MethodBase.GetCurrentMethod(), out var result) ? result : (int?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Peripheries), v.Value, "The number of peripheries must be greater than or equal to 0.")
                : new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey("penwidth")]
        public virtual double? PenWidth
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(PenWidth), v.Value, "Pen width must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("pencolor")]
        public virtual Color? PenColor
        {
            get => GetValueAs<Color>(MethodBase.GetCurrentMethod(), out var result) ? result : (Color?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorAttribute(k, v.Value));
        }

        [DotAttributeKey("fontcolor")]
        public virtual Color? FontColor
        {
            get => GetValueAs<Color>(MethodBase.GetCurrentMethod(), out var result) ? result : (Color?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorAttribute(k, v.Value));
        }

        [DotAttributeKey("fontname")]
        public virtual string FontName
        {
            get => GetValueAs<string>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("fontsize")]
        public virtual double? FontSize
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(FontSize), v.Value, "Font size must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("label")]
        public virtual DotLabel Label
        {
            get => TryGetValueAsLabel(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLabelAttribute(k, v));
        }

        [DotAttributeKey("xlabel")]
        public virtual DotLabel ExternalLabel
        {
            get => TryGetValueAsLabel(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLabelAttribute(k, v));
        }

        [DotAttributeKey("labeljust")]
        public virtual DotHorizontalAlignment? HorizontalLabelAlignment
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotHorizontalAlignment?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotHorizontalAlignmentAttribute(k, v.Value));
        }

        [DotAttributeKey("labelloc")]
        public virtual DotVerticalAlignment? VerticalLabelAlignment
        {
            get => GetValueAs<DotVerticalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotVerticalAlignment?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotVerticalAlignmentAttribute(k, v.Value));
        }

        [DotAttributeKey("ordering")]
        public virtual DotEdgeOrderingMode? EdgeOrderingMode
        {
            get => GetValueAs<DotEdgeOrderingMode>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotEdgeOrderingMode?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeOrderingModeAttribute(k, v.Value));
        }

        [DotAttributeKey("tooltip")]
        public virtual DotEscapeString Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("style")]
        public virtual DotStyle? Style
        {
            get => GetValueAs<DotStyle>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotStyle?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStyleAttribute(k, v.Value));
        }

        [DotAttributeKey("comment")]
        public virtual string Comment
        {
            get => GetValueAs<string>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("URL")]
        public virtual DotEscapeString Url
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("href")]
        public virtual DotEscapeString Href
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("target")]
        public virtual DotEscapeString UrlTarget
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("margin")]
        public virtual DotPoint Margin
        {
            get => GetValueAs<DotPoint>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }
    }
}