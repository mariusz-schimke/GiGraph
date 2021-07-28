using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Labels;
using GiGraph.Dot.Types.Styling;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public partial class DotEdgeAttributes : DotEntityRootCommonAttributes<IDotEdgeAttributes>, IDotEdgeAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeAttributes, IDotEdgeAttributes>().Build();

        protected DotEdgeAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEdgeHeadAttributes headAttributes,
            DotEdgeTailAttributes tailAttributes,
            DotFontAttributes fontAttributes,
            DotHyperlinkAttributes hyperlinkAttributes,
            DotEdgeEndpointLabelAttributes endpointLabelAttributes,
            DotEdgeLabelHyperlinkAttributes labelHyperlinkAttributes,
            DotEdgeHyperlinkAttributes edgeHyperlinkAttributes,
            DotEdgeStyleAttributes edgeStyleAttributes,
            DotStyleSheetAttributes styleSheetAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
            Head = headAttributes;
            Tail = tailAttributes;
            Font = fontAttributes;
            Style = edgeStyleAttributes;
            StyleSheet = styleSheetAttributes;
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
                new DotFontAttributes(attributes),
                new DotHyperlinkAttributes(attributes),
                new DotEdgeEndpointLabelAttributes(attributes),
                new DotEdgeLabelHyperlinkAttributes(attributes),
                new DotEdgeHyperlinkAttributes(attributes),
                new DotEdgeStyleAttributes(attributes),
                new DotStyleSheetAttributes(attributes)
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
        public virtual DotFontAttributes Font { get; }

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

        /// <summary>
        ///     Style options.
        /// </summary>
        public virtual DotEdgeStyleAttributes Style { get; }

        /// <summary>
        ///     Style sheet attributes used for SVG output.
        /// </summary>
        public virtual DotStyleSheetAttributes StyleSheet { get; }

        // accessible only through the interface
        [DotAttributeKey(DotStyleAttributes.StyleKey)]
        DotStyles? IDotEdgeAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEnumAttribute<DotStyles>(k, v!.Value));
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Label" />
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.ColorScheme" />
        public override string ColorScheme
        {
            get => base.ColorScheme;
            set => base.ColorScheme = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.ObjectId" />
        public override DotEscapeString ObjectId
        {
            get => base.ObjectId;
            set => base.ObjectId = value;
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Comment" />
        [DotAttributeKey(DotAttributeKeys.Comment)]
        public virtual string Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Tooltip" />
        [DotAttributeKey(DotAttributeKeys.Tooltip)]
        public virtual DotEscapeString Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Color" />
        [DotAttributeKey(DotAttributeKeys.Color)]
        public virtual DotColorDefinition Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemoveComplexAttribute(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotEdgeAttributes.FillColor" />
        [DotAttributeKey(DotAttributeKeys.FillColor)]
        public virtual DotColorDefinition FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemoveComplexAttribute(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotEdgeAttributes.ExternalLabel" />
        [DotAttributeKey(DotAttributeKeys.XLabel)]
        public virtual DotLabel ExternalLabel
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemoveComplexAttribute(MethodBase.GetCurrentMethod(), value);
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Width" />
        [DotAttributeKey(DotAttributeKeys.PenWidth)]
        public virtual double? Width
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v!.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Width), v!.Value, "Width must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v!.Value));
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Weight" />
        [DotAttributeKey(DotAttributeKeys.Weight)]
        public virtual double? Weight
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v!.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(Weight), v!.Value, "Weight must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v!.Value));
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Length" />
        [DotAttributeKey(DotAttributeKeys.Len)]
        public virtual double? Length
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotDoubleAttribute(k, v!.Value));
        }

        /// <inheritdoc cref="IDotEdgeAttributes.MinLength" />
        [DotAttributeKey(DotAttributeKeys.MinLen)]
        public virtual int? MinLength
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v!.Value < 0
                ? throw new ArgumentOutOfRangeException(nameof(MinLength), v!.Value, "Minimum length must be greater than or equal to 0.")
                : new DotIntAttribute(k, v!.Value));
        }

        /// <inheritdoc cref="IDotEdgeAttributes.ArrowheadScale" />
        [DotAttributeKey(DotAttributeKeys.ArrowSize)]
        public virtual double? ArrowheadScale
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => v!.Value < 0.0
                ? throw new ArgumentOutOfRangeException(nameof(ArrowheadScale), v!.Value, "Arrowhead scale must be greater than or equal to 0.")
                : new DotDoubleAttribute(k, v!.Value));
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Directions" />
        [DotAttributeKey(DotAttributeKeys.Dir)]
        public virtual DotEdgeDirections? Directions
        {
            get => GetValueAs<DotEdgeDirections>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEnumAttribute<DotEdgeDirections>(k, v!.Value));
        }

        /// <inheritdoc cref="IDotEdgeAttributes.AttachLabel" />
        [DotAttributeKey(DotAttributeKeys.Decorate)]
        public virtual bool? AttachLabel
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v!.Value));
        }

        /// <inheritdoc cref="IDotEdgeAttributes.AllowLabelFloat" />
        [DotAttributeKey(DotAttributeKeys.LabelFloat)]
        public virtual bool? AllowLabelFloat
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v!.Value));
        }

        /// <inheritdoc cref="IDotEdgeAttributes.Constrain" />
        [DotAttributeKey(DotAttributeKeys.Constraint)]
        public virtual bool? Constrain
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v!.Value));
        }
    }
}