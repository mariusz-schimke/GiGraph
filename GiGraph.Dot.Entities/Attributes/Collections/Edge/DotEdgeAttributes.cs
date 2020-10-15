using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeAttributes : DotEntityCommonAttributes<IDotEdgeAttributes>, IDotEdgeAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEdgeAttributes));

        protected DotEdgeAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEdgeHeadAttributes headAttributes,
            DotEdgeTailAttributes tailAttributes,
            DotEntityFontAttributes fontAttributes,
            DotEntityHyperlinkAttributes hyperlinkAttributes,
            DotEdgeEndpointLabelAttributes endpointLabelAttributes,
            DotEdgeHyperlinkAttributes edgeHyperlinkAttributes,
            DotEdgeLabelHyperlinkAttributes labelHyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
            Head = headAttributes;
            Tail = tailAttributes;
            Font = fontAttributes;
            EndpointLabels = endpointLabelAttributes;
            EdgeHyperlink = edgeHyperlinkAttributes;
            LabelHyperlink = labelHyperlinkAttributes;
        }

        public DotEdgeAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                EdgeAttributesKeyLookup,
                new DotEdgeHeadAttributes(attributes),
                new DotEdgeTailAttributes(attributes),
                new DotEntityFontAttributes(attributes),
                new DotEntityHyperlinkAttributes(attributes),
                new DotEdgeEndpointLabelAttributes(attributes),
                new DotEdgeHyperlinkAttributes(attributes),
                new DotEdgeLabelHyperlinkAttributes(attributes)
            )
        {
        }

        public DotEdgeAttributes()
            : this(new DotAttributeCollection())
        {
        }

        /// <summary>
        ///     Properties applied to the head of the edge.
        /// </summary>
        public virtual DotEdgeHeadAttributes Head { get; }

        /// <summary>
        ///     Properties applied to the tail of the edge.
        /// </summary>
        public virtual DotEdgeTailAttributes Tail { get; }

        /// <summary>
        ///     Font properties.
        /// </summary>
        public virtual DotEntityFontAttributes Font { get; }

        /// <summary>
        ///     Properties applied to labels specified for the <see cref="Head" /> and the <see cref="Tail" /> of the edge.
        /// </summary>
        public virtual DotEdgeEndpointLabelAttributes EndpointLabels { get; }

        /// <summary>
        ///     Hyperlink properties applied to the non-label parts of the edge.
        /// </summary>
        public virtual DotEdgeHyperlinkAttributes EdgeHyperlink { get; }

        /// <summary>
        ///     Hyperlink properties applied to the label of the edge.
        /// </summary>
        public virtual DotEdgeLabelHyperlinkAttributes LabelHyperlink { get; }

        [DotAttributeKey("tooltip")]
        public virtual DotEscapeString Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey("color")]
        public virtual DotColorDefinition Color
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

        [DotAttributeKey("xlabel")]
        public virtual DotLabel ExternalLabel
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotLabelAttribute(k, v));
        }

        [DotAttributeKey("penwidth")]
        public virtual double? PenWidth
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(PenWidth), v.Value, "Pen width must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

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

        [DotAttributeKey("arrowsize")]
        public virtual double? ArrowheadScale
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(ArrowheadScale), v.Value, "Arrowhead scale must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v.Value));
        }

        [DotAttributeKey("dir")]
        public virtual DotEdgeDirections? Directions
        {
            get => GetValueAs<DotEdgeDirections>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotEdgeDirections?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEdgeDirectionsAttribute(k, v.Value));
        }

        [DotAttributeKey("decorate")]
        public virtual bool? AttachLabel
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("labelfloat")]
        public virtual bool? AllowLabelFloat
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("constraint")]
        public virtual bool? Constrain
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }
    }
}