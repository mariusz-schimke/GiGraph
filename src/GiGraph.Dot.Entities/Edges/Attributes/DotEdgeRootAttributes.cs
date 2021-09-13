using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
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
    public class DotEdgeRootAttributes : DotEntityAttributes, IDotEdgeRootAttributes
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

        // TODO: usunąć tego typu konstruktory
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

        public virtual DotEdgeHeadAttributes Head => _headAttributes;
        public virtual DotEdgeTailAttributes Tail => _tailAttributes;

        public virtual DotFontAttributes Font => _fontAttributes;
        public virtual DotEdgeEndpointLabelsAttributes EndpointLabels => _endpointLabelsAttributes;
        public virtual DotEdgeHyperlinkAttributes EdgeHyperlink => _edgeHyperlinkAttributes;
        public virtual DotEdgeLabelHyperlinkAttributes LabelHyperlink => _labelHyperlinkAttributes;
        public virtual DotEdgeStyleAttributeOptions Style => _styleAttributeOptions;
        public virtual DotSvgStyleSheetAttributes SvgStyleSheet => _svgStyleSheetAttributes;
        public virtual DotHyperlinkAttributes Hyperlink => _hyperlinkAttributes;

        [DotAttributeKey(DotAttributeKeys.Label)]
        public virtual DotLabel Label
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.ColorScheme)]
        public virtual string ColorScheme
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Id)]
        public virtual DotEscapeString ObjectId
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
        public virtual string Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Tooltip)]
        public virtual DotEscapeString Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Color)]
        public virtual DotColorDefinition Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.FillColor)]
        public virtual DotColorDefinition FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.XLabel)]
        public virtual DotLabel ExternalLabel
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.PenWidth)]
        public virtual double? Width
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Weight)]
        public virtual double? Weight
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Len)]
        public virtual double? Length
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.MinLen)]
        public virtual int? MinLength
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.ArrowSize)]
        public virtual double? ArrowheadScale
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Dir)]
        public virtual DotEdgeDirections? Directions
        {
            get => GetValueAs<DotEdgeDirections>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Decorate)]
        public virtual bool? AttachLabel
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.LabelFloat)]
        public virtual bool? AllowLabelFloat
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Constraint)]
        public virtual bool? Constrain
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}