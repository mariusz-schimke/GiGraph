using System;
using System.Drawing;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Entities;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotEdgeAttributeCollection : DotEntityAttributeCollection<IDotEdgeAttributes>, IDotEdgeAttributeCollection
    {
        [DotAttributeKey("weight")]
        public virtual double? Weight
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Weight), v.Value, "Weight must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("len")]
        public virtual double? Length
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("minlen")]
        public virtual int? MinLength
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(MinLength), v.Value, "Minimum length must be greater than or equal to 0.")
                : new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey("labelfontname")]
        public virtual string LabelFontName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("labelfontcolor")]
        public virtual Color? LabelFontColor
        {
            get => GetValueAs<Color>(MethodBase.GetCurrentMethod(), out var result) ? result : (Color?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorAttribute(k, v.Value));
        }

        [DotAttributeKey("labelfontsize")]
        public virtual double? LabelFontSize
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(LabelFontSize), v.Value, "Label font size must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("taillabel")]
        public virtual DotLabel TailLabel
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLabelAttribute(k, v));
        }

        [DotAttributeKey("headlabel")]
        public virtual DotLabel HeadLabel
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLabelAttribute(k, v));
        }

        [DotAttributeKey("headURL")]
        public virtual DotEscapeString HeadUrl
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("headhref")]
        public virtual DotEscapeString HeadHref
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("headtarget")]
        public virtual DotEscapeString HeadUrlTarget
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("headtooltip")]
        public virtual DotEscapeString HeadUrlTooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("tailURL")]
        public virtual DotEscapeString TailUrl
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("tailhref")]
        public virtual DotEscapeString TailHref
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("tailtarget")]
        public virtual DotEscapeString TailUrlTarget
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("tailtooltip")]
        public virtual DotEscapeString TailUrlTooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("labelURL")]
        public virtual DotEscapeString LabelUrl
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("labelhref")]
        public virtual DotEscapeString LabelHref
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("labeltarget")]
        public virtual DotEscapeString LabelUrlTarget
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("labeltooltip")]
        public virtual DotEscapeString LabelUrlTooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("edgeURL")]
        public virtual DotEscapeString EdgeUrl
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("edgehref")]
        public virtual DotEscapeString EdgeHref
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("edgetarget")]
        public virtual DotEscapeString EdgeUrlTarget
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("edgetooltip")]
        public virtual DotEscapeString EdgeUrlTooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("headclip")]
        public virtual bool? ClipHead
        {
            get => GetValueAs<bool>(MethodBase.GetCurrentMethod(), out var result) ? result : (bool?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("tailclip")]
        public virtual bool? ClipTail
        {
            get => GetValueAs<bool>(MethodBase.GetCurrentMethod(), out var result) ? result : (bool?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("samehead")]
        public virtual string HeadGroupName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("sametail")]
        public virtual string TailGroupName
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        [DotAttributeKey("arrowsize")]
        public virtual double? ArrowSize
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(ArrowSize), v.Value, "Arrow size must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("arrowhead")]
        public virtual DotArrowheadDefinition ArrowHead
        {
            get => TryGetValueAsArrowheadDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotArrowheadDefinitionAttribute(k, v));
        }

        [DotAttributeKey("arrowtail")]
        public virtual DotArrowheadDefinition ArrowTail
        {
            get => TryGetValueAsArrowheadDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotArrowheadDefinitionAttribute(k, v));
        }

        [DotAttributeKey("dir")]
        public virtual DotArrowDirection? ArrowDirection
        {
            get => GetValueAs<DotArrowDirection>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotArrowDirection?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotArrowDirectionAttribute(k, v.Value));
        }

        [DotAttributeKey("headport")]
        public virtual DotEndpointPort HeadPort
        {
            get => GetValueAs<DotEndpointPort>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEndpointPortAttribute(k, v));
        }

        [DotAttributeKey("tailport")]
        public virtual DotEndpointPort TailPort
        {
            get => GetValueAs<DotEndpointPort>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEndpointPortAttribute(k, v));
        }

        [DotAttributeKey("lhead")]
        public virtual string LogicalHeadId
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLogicalEndpointAttribute(k, v));
        }

        [DotAttributeKey("ltail")]
        public virtual string LogicalTailId
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLogicalEndpointAttribute(k, v));
        }

        [DotAttributeKey("decorate")]
        public virtual bool? Decorate
        {
            get => GetValueAs<bool>(MethodBase.GetCurrentMethod(), out var result) ? result : (bool?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("labelfloat")]
        public virtual bool? LabelFloat
        {
            get => GetValueAs<bool>(MethodBase.GetCurrentMethod(), out var result) ? result : (bool?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("labeldistance")]
        public virtual double? LabelDistance
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(LabelDistance), v.Value, "Label distance must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("labelangle")]
        public virtual double? LabelAngle
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("constraint")]
        public virtual bool? Constraint
        {
            get => GetValueAs<bool>(MethodBase.GetCurrentMethod(), out var result) ? result : (bool?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        public override void SetFilled(DotColorDefinition value)
        {
            FillColor = value;
        }

        protected virtual DotArrowheadDefinition TryGetValueAsArrowheadDefinition(string key)
        {
            if (TryGetValueAs<DotArrowheadDefinition>(key, out var definition))
            {
                return definition;
            }

            return TryGetValueAs<DotArrowheadShape>(key, out var shape) ? new DotArrowhead(shape) : null;
        }

        protected virtual DotArrowheadDefinition TryGetValueAsArrowheadDefinition(MethodBase propertyMethod)
        {
            return TryGetValueAsArrowheadDefinition(GetKey(propertyMethod));
        }
    }
}