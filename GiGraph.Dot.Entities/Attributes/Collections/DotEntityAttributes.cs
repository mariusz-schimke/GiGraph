using System;
using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes : DotAttributeCollection
    {
        public virtual DotColorDefinition Color
        {
            get => TryGetValueAsColorDefinition("color");
            set => AddOrRemove("color", value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        public virtual DotColorDefinition BackgroundColor
        {
            get => TryGetValueAsColorDefinition("bgcolor");
            set => AddOrRemove("bgcolor", value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        public virtual DotColorDefinition FillColor
        {
            get => TryGetValueAsColorDefinition("fillcolor");
            set => AddOrRemove("fillcolor", value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        public virtual int? GradientAngle
        {
            get => TryGetValueAs<int>("gradientangle", out var result) ? result : (int?) null;
            set => AddOrRemove("gradientangle", value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        public virtual int? Peripheries
        {
            get => TryGetValueAs<int>("peripheries", out var result) ? result : (int?) null;
            set => AddOrRemove("peripheries", value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Peripheries), v.Value, "The number of peripheries must be greater than or equal to 0.")
                : new DotIntAttribute(k, v.Value));
        }

        public virtual double? PenWidth
        {
            get => TryGetValueAs<double>("penwidth", out var result) ? result : (double?) null;
            set => AddOrRemove("penwidth", value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(PenWidth), v.Value, "Pen width must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        public virtual Color? PenColor
        {
            get => TryGetValueAs<Color>("pencolor", out var result) ? result : (Color?) null;
            set => AddOrRemove("pencolor", value, (k, v) => new DotColorAttribute(k, v.Value));
        }

        public virtual Color? FontColor
        {
            get => TryGetValueAs<Color>("fontcolor", out var result) ? result : (Color?) null;
            set => AddOrRemove("fontcolor", value, (k, v) => new DotColorAttribute(k, v.Value));
        }

        public virtual string FontName
        {
            get => TryGetValueAs<string>("fontname", out var result) ? result : null;
            set => AddOrRemove("fontname", value, (k, v) => new DotStringAttribute(k, v));
        }

        public virtual double? FontSize
        {
            get => TryGetValueAs<double>("fontsize", out var result) ? result : (double?) null;
            set => AddOrRemove("fontsize", value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(FontSize), v.Value, "Font size must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        public virtual DotLabel Label
        {
            get => TryGetValueAsLabel("label");
            set => AddOrRemove("label", value, (k, v) => new DotLabelAttribute(k, v));
        }

        public virtual DotLabel ExternalLabel
        {
            get => TryGetValueAsLabel("xlabel");
            set => AddOrRemove("xlabel", value, (k, v) => new DotLabelAttribute(k, v));
        }

        public virtual DotHorizontalAlignment? HorizontalLabelAlignment
        {
            get => TryGetValueAs<DotHorizontalAlignment>("labeljust", out var result) ? result : (DotHorizontalAlignment?) null;
            set => AddOrRemove("labeljust", value, (k, v) => new DotHorizontalAlignmentAttribute(k, v.Value));
        }

        public virtual DotVerticalAlignment? VerticalLabelAlignment
        {
            get => TryGetValueAs<DotVerticalAlignment>("labelloc", out var result) ? result : (DotVerticalAlignment?) null;
            set => AddOrRemove("labelloc", value, (k, v) => new DotVerticalAlignmentAttribute(k, v.Value));
        }

        public virtual DotEscapableString Tooltip
        {
            get => TryGetValueAsEscapableString("tooltip");
            set => AddOrRemove("tooltip", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotStyle? Style
        {
            get => TryGetValueAs<DotStyle>("style", out var result) ? result : (DotStyle?) null;
            set => AddOrRemove("style", value, (k, v) => new DotStyleAttribute(k, v.Value));
        }

        public virtual string Comment
        {
            get => TryGetValueAs<string>("comment", out var result) ? result : null;
            set => AddOrRemove("comment", value, (k, v) => new DotStringAttribute(k, v));
        }

        public virtual DotEscapableString Url
        {
            get => TryGetValueAsEscapableString("URL");
            set => AddOrRemove("URL", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString Href
        {
            get => TryGetValueAsEscapableString("href");
            set => AddOrRemove("href", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString UrlTarget
        {
            get => TryGetValueAsEscapableString("target");
            set => AddOrRemove("target", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotPoint Margin
        {
            get => TryGetValueAs<DotPoint>("margin", out var result) ? result : null;
            set => AddOrRemove("margin", value, (k, v) => new DotPointAttribute(k, v));
        }

        protected virtual DotColorDefinition TryGetValueAsColorDefinition(string key)
        {
            if (TryGetValueAs<DotColorDefinition>(key, out var colorDefinition))
            {
                return colorDefinition;
            }

            return TryGetValueAs<Color>(key, out var color) ? new DotColor(color) : null;
        }

        protected virtual DotLabel TryGetValueAsLabel(string key)
        {
            if (TryGetValueAs<DotLabel>(key, out var label))
            {
                return label;
            }

            return TryGetValueAsEscapableString(key);
        }

        protected virtual DotEscapableString TryGetValueAsEscapableString(string key)
        {
            if (TryGetValueAs<DotEscapableString>(key, out var dotEscapableString))
            {
                return dotEscapableString;
            }

            return TryGetValueAs<string>(key, out var value) ? (DotEscapedString) value : null;
        }
    }
}