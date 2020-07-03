using System;
using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes : DotAttributeCollection
    {
        public virtual DotColorDefinition Color
        {
            get => TryGetValueAsColorDefinition("color");
            set => AddOrRemove("color", value, v => new DotColorDefinitionAttribute("color", v));
        }

        public virtual DotColorDefinition BackgroundColor
        {
            get => TryGetValueAsColorDefinition("bgcolor");
            set => AddOrRemove("bgcolor", value, v => new DotColorDefinitionAttribute("bgcolor", v));
        }

        public virtual DotColorDefinition FillColor
        {
            get => TryGetValueAsColorDefinition("fillcolor");
            set => AddOrRemove("fillcolor", value, v => new DotColorDefinitionAttribute("fillcolor", v));
        }

        public virtual int? GradientAngle
        {
            get => TryGetValueAs<int>("gradientangle", out var result) ? result : (int?) null;
            set => AddOrRemove("gradientangle", value, v => new DotIntAttribute("gradientangle", v.Value));
        }

        public virtual int? Peripheries
        {
            get => TryGetValueAs<int>("peripheries", out var result) ? result : (int?) null;
            set => AddOrRemove("peripheries", value, v => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(Peripheries), v.Value, "The number of peripheries must be greater than or equal to 0.")
                : new DotIntAttribute("peripheries", v.Value));
        }

        public virtual double? PenWidth
        {
            get => TryGetValueAs<double>("penwidth", out var result) ? result : (double?) null;
            set => AddOrRemove("penwidth", value, v => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(PenWidth), v.Value, "Pen width must be greater than or equal to 0.")
                : new DotDoubleAttribute("penwidth", v.Value));
        }

        public virtual Color? PenColor
        {
            get => TryGetValueAs<Color>("pencolor", out var result) ? result : (Color?) null;
            set => AddOrRemove("pencolor", value, v => new DotColorAttribute("pencolor", v.Value));
        }

        public virtual Color? FontColor
        {
            get => TryGetValueAs<Color>("fontcolor", out var result) ? result : (Color?) null;
            set => AddOrRemove("fontcolor", value, v => new DotColorAttribute("fontcolor", v.Value));
        }

        public virtual string FontName
        {
            get => TryGetValueAs<string>("fontname", out var result) ? result : null;
            set => AddOrRemove("fontname", value, v => new DotStringAttribute("fontname", v));
        }

        public virtual double? FontSize
        {
            get => TryGetValueAs<double>("fontsize", out var result) ? result : (double?) null;
            set => AddOrRemove("fontsize", value, v => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(FontSize), v.Value, "Font size must be greater than or equal to 0.")
                : new DotDoubleAttribute("fontsize", v.Value));
        }

        public virtual DotLabel Label
        {
            get => TryGetValueAsLabel("label");
            set => AddOrRemove("label", value, v => new DotLabelAttribute("label", v));
        }

        public virtual DotLabel ExternalLabel
        {
            get => TryGetValueAsLabel("xlabel");
            set => AddOrRemove("xlabel", value, v => new DotLabelAttribute("xlabel", v));
        }

        public virtual DotHorizontalLabelAlignment? HorizontalLabelAlignment
        {
            get => TryGetValueAs<DotHorizontalLabelAlignment>("labeljust", out var result) ? result : (DotHorizontalLabelAlignment?) null;
            set => AddOrRemove("labeljust", value, v => new DotHorizontalLabelAlignmentAttribute("labeljust", v.Value));
        }

        public virtual DotVerticalLabelAlignment? VerticalLabelAlignment
        {
            get => TryGetValueAs<DotVerticalLabelAlignment>("labelloc", out var result) ? result : (DotVerticalLabelAlignment?) null;
            set => AddOrRemove("labelloc", value, v => new DotVerticalLabelAlignmentAttribute("labelloc", v.Value));
        }

        public virtual DotEscapableString Tooltip
        {
            get => TryGetValueAsEscapableString("tooltip");
            set => AddOrRemove("tooltip", value, v => new DotEscapeStringAttribute("tooltip", v));
        }

        public virtual DotStyle? Style
        {
            get => TryGetValueAs<DotStyle>("style", out var result) ? result : (DotStyle?) null;
            set => AddOrRemove("style", value, v => new DotStyleAttribute("style", v.Value));
        }

        public virtual string Comment
        {
            get => TryGetValueAs<string>("comment", out var result) ? result : null;
            set => AddOrRemove("comment", value, v => new DotStringAttribute("comment", v));
        }

        public virtual DotEscapableString Url
        {
            get => TryGetValueAsEscapableString("URL");
            set => AddOrRemove("URL", value, v => new DotEscapeStringAttribute("URL", v));
        }

        public virtual DotEscapableString Href
        {
            get => TryGetValueAsEscapableString("href");
            set => AddOrRemove("href", value, v => new DotEscapeStringAttribute("href", v));
        }

        public virtual DotEscapableString UrlTarget
        {
            get => TryGetValueAsEscapableString("target");
            set => AddOrRemove("target", value, v => new DotEscapeStringAttribute("target", v));
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