using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotEdgeAttributes : DotEntityAttributes, IDotEdgeAttributes
    {
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

        public virtual DotArrowType? ArrowHead
        {
            get => TryGetValueAs<DotArrowType>("arrowhead", out var result) ? result : (DotArrowType?) null;
            set => AddOrRemove("arrowhead", value, (k, v) => new DotArrowTypeAttribute(k, v.Value));
        }

        public virtual DotArrowType? ArrowTail
        {
            get => TryGetValueAs<DotArrowType>("arrowtail", out var result) ? result : (DotArrowType?) null;
            set => AddOrRemove("arrowtail", value, (k, v) => new DotArrowTypeAttribute(k, v.Value));
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

        public virtual bool? Constraint
        {
            get => TryGetValueAs<bool>("constraint", out var result) ? result : (bool?) null;
            set => AddOrRemove("constraint", value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        public virtual DotEscapableString HeadUrl
        {
            get => TryGetValueAsEscapableString("headURL");
            set => AddOrRemove("headURL", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString HeadHref
        {
            get => TryGetValueAsEscapableString("headhref");
            set => AddOrRemove("headhref", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString HeadUrlTarget
        {
            get => TryGetValueAsEscapableString("headtarget");
            set => AddOrRemove("headtarget", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString HeadUrlTooltip
        {
            get => TryGetValueAsEscapableString("headtooltip");
            set => AddOrRemove("headtooltip", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString TailUrl
        {
            get => TryGetValueAsEscapableString("tailURL");
            set => AddOrRemove("tailURL", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString TailHref
        {
            get => TryGetValueAsEscapableString("tailhref");
            set => AddOrRemove("tailhref", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString TailUrlTarget
        {
            get => TryGetValueAsEscapableString("tailtarget");
            set => AddOrRemove("tailtarget", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString TailUrlTooltip
        {
            get => TryGetValueAsEscapableString("tailtooltip");
            set => AddOrRemove("tailtooltip", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString LabelUrl
        {
            get => TryGetValueAsEscapableString("labelURL");
            set => AddOrRemove("labelURL", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString LabelHref
        {
            get => TryGetValueAsEscapableString("labelhref");
            set => AddOrRemove("labelhref", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString LabelUrlTarget
        {
            get => TryGetValueAsEscapableString("labeltarget");
            set => AddOrRemove("labeltarget", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString LabelUrlTooltip
        {
            get => TryGetValueAsEscapableString("labeltooltip");
            set => AddOrRemove("labeltooltip", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString EdgeUrl
        {
            get => TryGetValueAsEscapableString("edgeURL");
            set => AddOrRemove("edgeURL", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString EdgeHref
        {
            get => TryGetValueAsEscapableString("edgehref");
            set => AddOrRemove("edgehref", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString EdgeUrlTarget
        {
            get => TryGetValueAsEscapableString("edgetarget");
            set => AddOrRemove("edgetarget", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public virtual DotEscapableString EdgeUrlTooltip
        {
            get => TryGetValueAsEscapableString("edgetooltip");
            set => AddOrRemove("edgetooltip", value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        public override void SetFilled(DotColorDefinition value)
        {
            FillColor = value;
        }
    }
}