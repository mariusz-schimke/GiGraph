using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
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
    public class DotGraphRootAttributes : DotEntityAttributes, IDotGraphRootAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> GraphRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphRootAttributes, IDotGraphAttributes>().BuildLazy();

        protected readonly DotGraphCanvasAttributes _canvasAttributes;
        protected readonly DotGraphFontAttributes _fontAttributes;
        protected readonly DotGraphClustersRootAttributes _clusterAttributes;
        protected readonly DotHyperlinkAttributes _hyperlinkAttributes;
        protected readonly DotLabelAlignmentAttributes _labelAlignmentAttributes;
        protected readonly DotGraphLayoutAttributes _layoutAttributes;
        protected readonly DotGraphStyleAttributeOptions _styleAttributeOptions;
        protected readonly DotGraphSvgStyleSheetAttributes _svgStyleSheetAttributes;

        protected DotGraphRootAttributes(
            DotAttributeCollection attributes,
            Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
            DotGraphClustersRootAttributes clusterAttributes,
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
            _clusterAttributes = clusterAttributes;
            _hyperlinkAttributes = hyperlinkAttributes;
            _fontAttributes = fontAttributes;
            _styleAttributeOptions = styleAttributeOptions;
            _svgStyleSheetAttributes = svgStyleSheetAttributes;
            _layoutAttributes = layoutAttributes;
            _canvasAttributes = canvasAttributes;
            _labelAlignmentAttributes = labelAlignmentAttributes;
        }

        // TODO: usunąć tego typu konstruktory (uprościć)?
        public DotGraphRootAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                GraphRootAttributesKeyLookup,
                new DotGraphClustersRootAttributes(attributes),
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

        public virtual DotGraphClustersRootAttributes Clusters => _clusterAttributes;
        public virtual DotGraphStyleAttributeOptions Style => _styleAttributeOptions;

        public virtual DotHyperlinkAttributes Hyperlink => _hyperlinkAttributes;
        public virtual DotGraphFontAttributes Font => _fontAttributes;
        public virtual DotGraphSvgStyleSheetAttributes SvgStyleSheet => _svgStyleSheetAttributes;
        public virtual DotGraphLayoutAttributes Layout => _layoutAttributes;
        public virtual DotGraphCanvasAttributes Canvas => _canvasAttributes;
        public virtual DotLabelAlignmentAttributes LabelAlignment => _labelAlignmentAttributes;

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
        DotStyles? IDotGraphAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Splines)]
        public virtual DotEdgeShape? EdgeShape
        {
            get => GetValueAs<DotEdgeShape>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Comment)]
        public virtual string Comment
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Charset)]
        public virtual string Charset
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.ImagePath)]
        public virtual string ImageDirectories
        {
            get => GetValueAsString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Root)]
        public virtual DotId RootNodeId
        {
            get => GetValueAsId(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}