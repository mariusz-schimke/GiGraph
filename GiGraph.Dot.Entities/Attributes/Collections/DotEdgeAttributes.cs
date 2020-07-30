using System;
using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotEdgeAttributes : DotEntityAttributes, IDotEdgeAttributes
    {
        public virtual string LabelFontName
        {
            get => TryGetValueAs<string>("labelfontname", out var result) ? result : null;
            set => AddOrRemove("labelfontname", value, (k, v) => new DotStringAttribute(k, v));
        }

        public virtual Color? LabelFontColor
        {
            get => TryGetValueAs<Color>("labelfontcolor", out var result) ? result : (Color?) null;
            set => AddOrRemove("labelfontcolor", value, (k, v) => new DotColorAttribute(k, v.Value));
        }

        public virtual double? LabelFontSize
        {
            get => TryGetValueAs<double>("labelfontsize", out var result) ? result : (double?) null;
            set => AddOrRemove("labelfontsize", value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(LabelFontSize), v.Value, "Label font size must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        public virtual DotLabel TailLabel
        {
            get => TryGetValueAsLabel("taillabel");
            set => AddOrRemove("taillabel", value, (k, v) => new DotLabelAttribute(k, v));
        }

        public virtual DotLabel HeadLabel
        {
            get => TryGetValueAsLabel("headlabel");
            set => AddOrRemove("headlabel", value, (k, v) => new DotLabelAttribute(k, v));
        }

        public virtual DotEscapeString HeadUrl
        {
            get => TryGetValueAsEscapeString("headURL");
            set => AddOrRemove("headURL", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString HeadHref
        {
            get => TryGetValueAsEscapeString("headhref");
            set => AddOrRemove("headhref", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString HeadUrlTarget
        {
            get => TryGetValueAsEscapeString("headtarget");
            set => AddOrRemove("headtarget", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString HeadUrlTooltip
        {
            get => TryGetValueAsEscapeString("headtooltip");
            set => AddOrRemove("headtooltip", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString TailUrl
        {
            get => TryGetValueAsEscapeString("tailURL");
            set => AddOrRemove("tailURL", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString TailHref
        {
            get => TryGetValueAsEscapeString("tailhref");
            set => AddOrRemove("tailhref", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString TailUrlTarget
        {
            get => TryGetValueAsEscapeString("tailtarget");
            set => AddOrRemove("tailtarget", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString TailUrlTooltip
        {
            get => TryGetValueAsEscapeString("tailtooltip");
            set => AddOrRemove("tailtooltip", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString LabelUrl
        {
            get => TryGetValueAsEscapeString("labelURL");
            set => AddOrRemove("labelURL", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString LabelHref
        {
            get => TryGetValueAsEscapeString("labelhref");
            set => AddOrRemove("labelhref", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString LabelUrlTarget
        {
            get => TryGetValueAsEscapeString("labeltarget");
            set => AddOrRemove("labeltarget", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString LabelUrlTooltip
        {
            get => TryGetValueAsEscapeString("labeltooltip");
            set => AddOrRemove("labeltooltip", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString EdgeUrl
        {
            get => TryGetValueAsEscapeString("edgeURL");
            set => AddOrRemove("edgeURL", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString EdgeHref
        {
            get => TryGetValueAsEscapeString("edgehref");
            set => AddOrRemove("edgehref", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString EdgeUrlTarget
        {
            get => TryGetValueAsEscapeString("edgetarget");
            set => AddOrRemove("edgetarget", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapeString EdgeUrlTooltip
        {
            get => TryGetValueAsEscapeString("edgetooltip");
            set => AddOrRemove("edgetooltip", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual bool? ClipHead
        {
            get => TryGetValueAs<bool>("headclip", out var result) ? result : (bool?) null;
            set => AddOrRemove("headclip", value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        public virtual bool? ClipTail
        {
            get => TryGetValueAs<bool>("tailclip", out var result) ? result : (bool?) null;
            set => AddOrRemove("tailclip", value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        public virtual double? ArrowSize
        {
            get => TryGetValueAs<double>("arrowsize", out var result) ? result : (double?) null;
            set => AddOrRemove("arrowsize", value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(ArrowSize), v.Value, "Arrow size must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        public virtual DotArrowShape? ArrowHead
        {
            get => TryGetValueAs<DotArrowShape>("arrowhead", out var result) ? result : (DotArrowShape?) null;
            set => AddOrRemove("arrowhead", value, (k, v) => new DotArrowShapeAttribute(k, v.Value));
        }

        public virtual DotArrowShape? ArrowTail
        {
            get => TryGetValueAs<DotArrowShape>("arrowtail", out var result) ? result : (DotArrowShape?) null;
            set => AddOrRemove("arrowtail", value, (k, v) => new DotArrowShapeAttribute(k, v.Value));
        }

        public virtual DotArrowDirection? ArrowDirection
        {
            get => TryGetValueAs<DotArrowDirection>("dir", out var result) ? result : (DotArrowDirection?) null;
            set => AddOrRemove("dir", value, (k, v) => new DotArrowDirectionAttribute(k, v.Value));
        }

        public virtual DotEndpointPort HeadPort
        {
            get => TryGetValueAs<DotEndpointPort>("headport", out var result) ? result : null;
            set => AddOrRemove("headport", value, (k, v) => new DotEndpointPortAttribute(k, v));
        }

        public virtual DotEndpointPort TailPort
        {
            get => TryGetValueAs<DotEndpointPort>("tailport", out var result) ? result : null;
            set => AddOrRemove("tailport", value, (k, v) => new DotEndpointPortAttribute(k, v));
        }

        public virtual string LogicalHeadId
        {
            get => TryGetValueAs<string>("lhead", out var result) ? result : null;
            set => AddOrRemove("lhead", value, (k, v) => new DotLogicalEndpointAttribute(k, v));
        }

        public virtual string LogicalTailId
        {
            get => TryGetValueAs<string>("ltail", out var result) ? result : null;
            set => AddOrRemove("ltail", value, (k, v) => new DotLogicalEndpointAttribute(k, v));
        }

        public virtual bool? Decorate
        {
            get => TryGetValueAs<bool>("decorate", out var result) ? result : (bool?) null;
            set => AddOrRemove("decorate", value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        public virtual bool? LabelFloat
        {
            get => TryGetValueAs<bool>("labelfloat", out var result) ? result : (bool?) null;
            set => AddOrRemove("labelfloat", value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        public virtual double? LabelDistance
        {
            get => TryGetValueAs<double>("labeldistance", out var result) ? result : (double?) null;
            set => AddOrRemove("labeldistance", value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(LabelDistance), v.Value, "Label distance must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        public virtual double? LabelAngle
        {
            get => TryGetValueAs<double>("labelangle", out var result) ? result : (double?) null;
            set => AddOrRemove("labelangle", value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        public virtual bool? Constraint
        {
            get => TryGetValueAs<bool>("constraint", out var result) ? result : (bool?) null;
            set => AddOrRemove("constraint", value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        public override void SetFilled(DotColorDefinition value)
        {
            FillColor = value;
        }
    }
}