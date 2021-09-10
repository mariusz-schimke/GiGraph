using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public class DotGraphRootAttributes : DotEntityRootAttributes<IDotGraphAttributes>, IDotGraphRootAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> GraphRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphRootAttributes, IDotGraphAttributes>().BuildLazy();

        protected readonly DotGraphCanvasAttributes _canvasAttributes;
        protected readonly DotGraphFontAttributes _fontAttributes;
        protected readonly DotHyperlinkAttributes _hyperlinkAttributes;
        protected readonly DotLabelAlignmentAttributes _labelAlignmentAttributes;
        protected readonly DotGraphLayoutAttributes _layoutAttributes;
        protected readonly DotGraphStyleAttributeOptions _styleAttributeOptions;
        protected readonly DotGraphSvgStyleSheetAttributes _svgStyleSheetAttributes;

        protected DotGraphRootAttributes(
            DotAttributeCollection attributes,
            Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
            DotHyperlinkAttributes hyperlinkAttributes,
            DotGraphFontAttributes fontAttributes,
            DotGraphStyleAttributeOptions styleAttributeOptions,
            DotGraphSvgStyleSheetAttributes svgStyleSheetAttributes,
            DotGraphLayoutAttributes layoutAttributes,
            DotGraphCanvasAttributes canvasAttributes,
            DotLabelAlignmentAttributes labelAlignmentAttributes
        )
            : base(attributes, attributeKeyLookup)
        {
            _hyperlinkAttributes = hyperlinkAttributes;
            _fontAttributes = fontAttributes;
            _styleAttributeOptions = styleAttributeOptions;
            _svgStyleSheetAttributes = svgStyleSheetAttributes;
            _layoutAttributes = layoutAttributes;
            _canvasAttributes = canvasAttributes;
            _labelAlignmentAttributes = labelAlignmentAttributes;
        }

        public DotGraphRootAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                GraphRootAttributesKeyLookup,
                new DotHyperlinkAttributes(attributes),
                new DotGraphFontAttributes(attributes),
                new DotGraphStyleAttributeOptions(attributes),
                new DotGraphSvgStyleSheetAttributes(attributes),
                new DotGraphLayoutAttributes(attributes),
                new DotGraphCanvasAttributes(attributes),
                new DotLabelAlignmentAttributes(attributes)
            )
        {
        }

        public DotGraphRootAttributes()
            : this(new DotAttributeCollection(DotAttributeFactory.Instance))
        {
        }

        DotHyperlinkAttributes IDotGraphRootAttributes.Hyperlink => _hyperlinkAttributes;
        DotGraphFontAttributes IDotGraphRootAttributes.Font => _fontAttributes;
        DotGraphStyleAttributeOptions IDotGraphRootAttributes.Style => _styleAttributeOptions;
        DotGraphSvgStyleSheetAttributes IDotGraphRootAttributes.SvgStyleSheet => _svgStyleSheetAttributes;
        DotGraphLayoutAttributes IDotGraphRootAttributes.Layout => _layoutAttributes;
        DotGraphCanvasAttributes IDotGraphRootAttributes.Canvas => _canvasAttributes;
        DotLabelAlignmentAttributes IDotGraphRootAttributes.LabelAlignment => _labelAlignmentAttributes;

        [DotAttributeKey(DotAttributeKeys.Label)]
        DotLabel IDotGraphAttributes.Label
        {
            get => GetValueAsLabel(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.ColorScheme)]
        string IDotGraphAttributes.ColorScheme
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Id)]
        DotEscapeString IDotGraphAttributes.ObjectId
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotStyleAttributeOptions.StyleKey)]
        DotStyles? IDotGraphAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Splines)]
        DotEdgeShape? IDotGraphAttributes.EdgeShape
        {
            get => GetValueAs<DotEdgeShape>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Comment)]
        string IDotGraphAttributes.Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Charset)]
        string IDotGraphAttributes.Charset
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.ImagePath)]
        string IDotGraphAttributes.ImageDirectories
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Root)]
        DotId IDotGraphAttributes.RootNodeId
        {
            get => GetValueAsId(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}