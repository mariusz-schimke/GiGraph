using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Ranks;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters.Attributes
{
    public class DotClusterAttributes : DotClusterNodeCommonAttributes<IDotClusterAttributes>, IDotClusterAttributesRoot
    {
        protected static readonly DotMemberAttributeKeyLookup ClusterAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotClusterAttributes, IDotClusterAttributes>().Build();

        protected readonly DotFontAttributes _font;
        protected readonly DotLabelAlignmentAttributes _labelAlignment;
        protected readonly DotClusterStyleAttributes _style;

        protected DotClusterAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotHyperlinkAttributes hyperlinkAttributes,
            DotFontAttributes fontAttributes,
            DotClusterStyleAttributes styleAttributes,
            DotSvgStyleSheetAttributes svgStyleSheetAttributes,
            DotLabelAlignmentAttributes labelAlignmentAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes, svgStyleSheetAttributes)
        {
            _font = fontAttributes;
            _style = styleAttributes;
            _labelAlignment = labelAlignmentAttributes;
        }

        public DotClusterAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                ClusterAttributesKeyLookup,
                new DotHyperlinkAttributes(attributes),
                new DotFontAttributes(attributes),
                new DotClusterStyleAttributes(attributes),
                new DotSvgStyleSheetAttributes(attributes),
                new DotLabelAlignmentAttributes(attributes)
            )
        {
        }

        public DotClusterAttributes()
            : this(new DotAttributeCollection(DotAttributeFactory.Instance))
        {
        }

        DotFontAttributes IDotClusterAttributesRoot.Font => _font;
        DotClusterStyleAttributes IDotClusterAttributesRoot.Style => _style;
        DotLabelAlignmentAttributes IDotClusterAttributesRoot.LabelAlignment => _labelAlignment;

        [DotAttributeKey(DotStyleAttributes.StyleKey)]
        DotStyles? IDotClusterAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.Rank)]
        DotRank? IDotClusterAttributes.NodeRank
        {
            get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }

        [DotAttributeKey(DotAttributeKeys.PenColor)]
        DotColor IDotGraphClusterCommonAttributes.BorderColor
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.BgColor)]
        DotColorDefinition IDotClusterAttributes.BackgroundColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Peripheries)]
        int? IDotClusterAttributes.Peripheries
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        protected override void SetFillStyle(DotStyles fillStyle)
        {
            _style.FillStyle = (DotClusterFillStyle) fillStyle;
        }
    }
}