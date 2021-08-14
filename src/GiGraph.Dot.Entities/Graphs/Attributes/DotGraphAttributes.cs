using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public partial class DotGraphAttributes : DotEntityRootCommonAttributes<IDotGraphAttributes>, IDotGraphAttributesRoot
    {
        protected static readonly DotMemberAttributeKeyLookup GraphAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphAttributes, IDotGraphAttributes>().Build();
        protected readonly DotGraphCanvasAttributes _canvas;
        protected readonly DotGraphFontAttributes _font;
        protected readonly DotLabelAlignmentAttributes _labelAlignment;
        protected readonly DotGraphLayoutAttributes _layout;
        protected readonly DotGraphStyleAttributes _style;
        protected readonly DotGraphSvgSvgStyleSheetAttributes _svgStyleSheet;

        protected DotGraphAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotHyperlinkAttributes hyperlinkAttributes,
            DotGraphFontAttributes fontAttributes,
            DotGraphStyleAttributes styleAttributes,
            DotGraphSvgSvgStyleSheetAttributes svgStyleSheetAttributes,
            DotGraphLayoutAttributes layoutAttributes,
            DotGraphCanvasAttributes canvasAttributes,
            DotLabelAlignmentAttributes labelAlignmentAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
            _font = fontAttributes;
            _style = styleAttributes;
            _svgStyleSheet = svgStyleSheetAttributes;
            _layout = layoutAttributes;
            _canvas = canvasAttributes;
            _labelAlignment = labelAlignmentAttributes;
        }

        public DotGraphAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                GraphAttributesKeyLookup,
                new DotHyperlinkAttributes(attributes),
                new DotGraphFontAttributes(attributes),
                new DotGraphStyleAttributes(attributes),
                new DotGraphSvgSvgStyleSheetAttributes(attributes),
                new DotGraphLayoutAttributes(attributes),
                new DotGraphCanvasAttributes(attributes),
                new DotLabelAlignmentAttributes(attributes)
            )
        {
        }

        public DotGraphAttributes()
            : this(new DotAttributeCollection(DotAttributeFactory.Instance))
        {
        }

        DotGraphFontAttributes IDotGraphAttributesRoot.Font => _font;
        DotGraphStyleAttributes IDotGraphAttributesRoot.Style => _style;
        DotGraphSvgSvgStyleSheetAttributes IDotGraphAttributesRoot.SvgStyleSheet => _svgStyleSheet;
        DotGraphLayoutAttributes IDotGraphAttributesRoot.Layout => _layout;
        DotGraphCanvasAttributes IDotGraphAttributesRoot.Canvas => _canvas;
        DotLabelAlignmentAttributes IDotGraphAttributesRoot.LabelAlignment => _labelAlignment;

        [DotAttributeKey(DotStyleAttributes.StyleKey)]
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