using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public partial class DotEdgeAttributes : DotEntityRootAttributes<IDotEdgeAttributes>, IDotEdgeAttributesRoot
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeAttributes, IDotEdgeAttributes>().Build();

        protected readonly DotEdgeHyperlinkAttributes _edgeHyperlink;
        protected readonly DotEdgeEndpointLabelAttributes _endpointLabels;
        protected readonly DotFontAttributes _font;
        protected readonly DotEdgeHeadAttributes _head;
        protected readonly DotHyperlinkAttributes _hyperlinkAttributes;
        protected readonly DotEdgeLabelHyperlinkAttributes _labelHyperlink;
        protected readonly DotEdgeStyleAttributes _style;
        protected readonly DotSvgStyleSheetAttributes _svgStyleSheet;
        protected readonly DotEdgeTailAttributes _tail;

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
            DotSvgStyleSheetAttributes svgStyleSheetAttributes
        )
            : base(attributes, attributeKeyLookup)
        {
            _hyperlinkAttributes = hyperlinkAttributes;
            _head = headAttributes;
            _tail = tailAttributes;
            _font = fontAttributes;
            _style = edgeStyleAttributes;
            _svgStyleSheet = svgStyleSheetAttributes;
            _endpointLabels = endpointLabelAttributes;
            _edgeHyperlink = edgeHyperlinkAttributes;
            _labelHyperlink = labelHyperlinkAttributes;
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
                new DotSvgStyleSheetAttributes(attributes)
            )
        {
        }

        public DotEdgeAttributes()
            : this(new DotAttributeCollection(DotAttributeFactory.Instance))
        {
        }

        DotEdgeHeadAttributes IDotEdgeAttributesRoot.HeadAttributes => _head;
        DotEdgeTailAttributes IDotEdgeAttributesRoot.TailAttributes => _tail;
        DotFontAttributes IDotEdgeAttributesRoot.Font => _font;
        DotEdgeEndpointLabelAttributes IDotEdgeAttributesRoot.EndpointLabels => _endpointLabels;
        DotEdgeHyperlinkAttributes IDotEdgeAttributesRoot.EdgeHyperlink => _edgeHyperlink;
        DotEdgeLabelHyperlinkAttributes IDotEdgeAttributesRoot.LabelHyperlink => _labelHyperlink;
        DotEdgeStyleAttributes IDotEdgeAttributesRoot.Style => _style;
        DotSvgStyleSheetAttributes IDotEdgeAttributesRoot.SvgStyleSheet => _svgStyleSheet;
        DotHyperlinkAttributes IDotEdgeAttributesRoot.Hyperlink => _hyperlinkAttributes;

        [DotAttributeKey(DotAttributeKeys.Label)]
        DotLabel IDotEdgeAttributes.Label
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.ColorScheme)]
        string IDotEdgeAttributes.ColorScheme
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Id)]
        DotEscapeString IDotEdgeAttributes.ObjectId
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotStyleAttributes.StyleKey)]
        DotStyles? IDotEdgeAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Comment)]
        string IDotEdgeAttributes.Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Tooltip)]
        DotEscapeString IDotEdgeAttributes.Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Color)]
        DotColorDefinition IDotEdgeAttributes.Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.FillColor)]
        DotColorDefinition IDotEdgeAttributes.FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.XLabel)]
        DotLabel IDotEdgeAttributes.ExternalLabel
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.PenWidth)]
        double? IDotEdgeAttributes.Width
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Weight)]
        double? IDotEdgeAttributes.Weight
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Len)]
        double? IDotEdgeAttributes.Length
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.MinLen)]
        int? IDotEdgeAttributes.MinLength
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.ArrowSize)]
        double? IDotEdgeAttributes.ArrowheadScale
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Dir)]
        DotEdgeDirections? IDotEdgeAttributes.Directions
        {
            get => GetValueAs<DotEdgeDirections>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Decorate)]
        bool? IDotEdgeAttributes.AttachLabel
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.LabelFloat)]
        bool? IDotEdgeAttributes.AllowLabelFloat
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Constraint)]
        bool? IDotEdgeAttributes.Constrain
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}