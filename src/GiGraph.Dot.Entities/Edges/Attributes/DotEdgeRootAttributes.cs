using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public class DotEdgeRootAttributes : DotEntityRootAttributes<IDotEdgeAttributes>, IDotEdgeRootAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> EdgeRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeRootAttributes, IDotEdgeAttributes>().BuildLazy();

        protected readonly DotEdgeHyperlinkAttributes _edgeHyperlinkAttributes;
        protected readonly DotEdgeEndpointLabelsAttributes _endpointLabelsAttributes;
        protected readonly DotFontAttributes _fontAttributes;
        protected readonly DotEdgeHeadAttributes _headAttributes;
        protected readonly DotHyperlinkAttributes _hyperlinkAttributes;
        protected readonly DotEdgeLabelHyperlinkAttributes _labelHyperlinkAttributes;
        protected readonly DotEdgeStyleAttributeOptions _styleAttributeOptions;
        protected readonly DotSvgStyleSheetAttributes _svgStyleSheetAttributes;
        protected readonly DotEdgeTailAttributes _tailAttributes;

        protected DotEdgeRootAttributes(
            DotAttributeCollection attributes,
            Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
            DotEdgeHeadAttributes headAttributes,
            DotEdgeTailAttributes tailAttributes,
            DotFontAttributes fontAttributes,
            DotHyperlinkAttributes hyperlinkAttributes,
            DotEdgeEndpointLabelsAttributes endpointLabelsAttributes,
            DotEdgeLabelHyperlinkAttributes labelHyperlinkAttributes,
            DotEdgeHyperlinkAttributes edgeHyperlinkAttributes,
            DotEdgeStyleAttributeOptions edgeStyleAttributeOptions,
            DotSvgStyleSheetAttributes svgStyleSheetAttributes
        )
            : base(attributes, attributeKeyLookup)
        {
            _headAttributes = headAttributes;
            _tailAttributes = tailAttributes;
            _hyperlinkAttributes = hyperlinkAttributes;
            _fontAttributes = fontAttributes;
            _styleAttributeOptions = edgeStyleAttributeOptions;
            _svgStyleSheetAttributes = svgStyleSheetAttributes;
            _endpointLabelsAttributes = endpointLabelsAttributes;
            _edgeHyperlinkAttributes = edgeHyperlinkAttributes;
            _labelHyperlinkAttributes = labelHyperlinkAttributes;
        }

        public DotEdgeRootAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                EdgeRootAttributesKeyLookup,
                new DotEdgeHeadAttributes(attributes),
                new DotEdgeTailAttributes(attributes),
                new DotFontAttributes(attributes),
                new DotHyperlinkAttributes(attributes),
                new DotEdgeEndpointLabelsAttributes(attributes),
                new DotEdgeLabelHyperlinkAttributes(attributes),
                new DotEdgeHyperlinkAttributes(attributes),
                new DotEdgeStyleAttributeOptions(attributes),
                new DotSvgStyleSheetAttributes(attributes)
            )
        {
        }

        public DotEdgeRootAttributes()
            : this(new DotAttributeCollection(DotAttributeFactory.Instance))
        {
        }

        DotEdgeHeadAttributes IDotEdgeRootAttributes.Head => _headAttributes;
        DotEdgeTailAttributes IDotEdgeRootAttributes.Tail => _tailAttributes;

        DotFontAttributes IDotEdgeRootAttributes.Font => _fontAttributes;
        DotEdgeEndpointLabelsAttributes IDotEdgeRootAttributes.EndpointLabels => _endpointLabelsAttributes;
        DotEdgeHyperlinkAttributes IDotEdgeRootAttributes.EdgeHyperlink => _edgeHyperlinkAttributes;
        DotEdgeLabelHyperlinkAttributes IDotEdgeRootAttributes.LabelHyperlink => _labelHyperlinkAttributes;
        DotEdgeStyleAttributeOptions IDotEdgeRootAttributes.Style => _styleAttributeOptions;
        DotSvgStyleSheetAttributes IDotEdgeRootAttributes.SvgStyleSheet => _svgStyleSheetAttributes;
        DotHyperlinkAttributes IDotEdgeRootAttributes.Hyperlink => _hyperlinkAttributes;

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

        [DotAttributeKey(DotStyleAttributeOptions.StyleKey)]
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