using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Ranks;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters.Attributes
{
    public class DotClusterRootAttributes : DotEntityRootCommonAttributes<IDotClusterAttributes, DotClusterRootAttributes>, IDotClusterRootAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> ClusterRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotClusterRootAttributes, IDotClusterAttributes>().BuildLazy();

        protected readonly DotFontAttributes _fontAttributes;
        protected readonly DotLabelAlignmentAttributes _labelAlignmentAttributes;
        protected readonly DotClusterStyleAttributeOptions _styleAttributeOptions;
        protected readonly DotSvgStyleSheetAttributes _svgStyleSheetAttributes;

        protected DotClusterRootAttributes(
            DotAttributeCollection attributes,
            Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
            DotHyperlinkAttributes hyperlinkAttributes,
            DotFontAttributes fontAttributes,
            DotClusterStyleAttributeOptions styleAttributeOptions,
            DotSvgStyleSheetAttributes svgStyleSheetAttributes,
            DotLabelAlignmentAttributes labelAlignmentAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
            _fontAttributes = fontAttributes;
            _styleAttributeOptions = styleAttributeOptions;
            _svgStyleSheetAttributes = svgStyleSheetAttributes;
            _labelAlignmentAttributes = labelAlignmentAttributes;
        }

        public DotClusterRootAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                ClusterRootAttributesKeyLookup,
                new DotHyperlinkAttributes(attributes),
                new DotFontAttributes(attributes),
                new DotClusterStyleAttributeOptions(attributes),
                new DotSvgStyleSheetAttributes(attributes),
                new DotLabelAlignmentAttributes(attributes)
            )
        {
        }

        public virtual DotFontAttributes Font => _fontAttributes;
        public virtual DotClusterStyleAttributeOptions Style => _styleAttributeOptions;
        public virtual DotSvgStyleSheetAttributes SvgStyleSheet => _svgStyleSheetAttributes;
        public virtual DotLabelAlignmentAttributes LabelAlignment => _labelAlignmentAttributes;

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

        [DotAttributeKey(DotAttributeKeys.PenWidth)]
        public virtual double? BorderWidth
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.GradientAngle)]
        public virtual int? GradientFillAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Tooltip)]
        public virtual DotEscapeString Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Margin)]
        public virtual DotPoint Padding
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.SortV)]
        public virtual int? SortIndex
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotStyleAttributeOptions.StyleKey)]
        DotStyles? IDotClusterAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Rank)]
        public virtual DotRank? NodeRank
        {
            get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.PenColor)]
        public virtual DotColor BorderColor
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.BgColor)]
        public virtual DotColorDefinition BackgroundColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Peripheries)]
        public virtual int? Peripheries
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }
    }
}