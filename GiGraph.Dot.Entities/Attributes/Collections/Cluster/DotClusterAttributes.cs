using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Geometry;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public class DotClusterAttributes : DotClusterNodeCommonAttributes<IDotClusterAttributes>, IDotClusterAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup ClusterAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotClusterAttributes, IDotClusterAttributes>().Build();

        protected DotClusterAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotHyperlinkAttributes hyperlinkAttributes,
            DotFontAttributes fontAttributes,
            DotClusterStyleAttributes styleAttributes,
            DotStyleSheetAttributes styleSheetAttributes,
            DotLabelAlignmentAttributes labelAlignmentAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes, styleSheetAttributes)
        {
            Font = fontAttributes;
            Style = styleAttributes;
            LabelAlignment = labelAlignmentAttributes;
        }

        public DotClusterAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                ClusterAttributesKeyLookup,
                new DotHyperlinkAttributes(attributes),
                new DotFontAttributes(attributes),
                new DotClusterStyleAttributes(attributes),
                new DotStyleSheetAttributes(attributes),
                new DotLabelAlignmentAttributes(attributes)
            )
        {
        }

        public DotClusterAttributes()
            : this(new DotAttributeCollection())
        {
        }

        /// <summary>
        ///     Font properties.
        /// </summary>
        public virtual DotFontAttributes Font { get; }

        /// <summary>
        ///     Style options.
        /// </summary>
        public virtual DotClusterStyleAttributes Style { get; }

        /// <summary>
        ///     Horizontal and vertical label alignment options.
        /// </summary>
        public virtual DotLabelAlignmentAttributes LabelAlignment { get; }

        // accessible only through the interface
        /// <inheritdoc cref="IDotClusterAttributes.Style" />
        [DotAttributeKey(DotStyleAttributes.StyleKey)]
        DotStyles? IDotClusterAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotStyles?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStyleAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotClusterAttributes.Label" />
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.ColorScheme" />
        public override string ColorScheme
        {
            get => base.ColorScheme;
            set => base.ColorScheme = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.Color" />
        public override DotColorDefinition Color
        {
            get => base.Color;
            set => base.Color = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.FillColor" />
        public override DotColorDefinition FillColor
        {
            get => base.FillColor;
            set => base.FillColor = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.GradientFillAngle" />
        public override int? GradientFillAngle
        {
            get => base.GradientFillAngle;
            set => base.GradientFillAngle = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.Tooltip" />
        public override DotEscapeString Tooltip
        {
            get => base.Tooltip;
            set => base.Tooltip = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.Padding" />
        public override DotPoint Padding
        {
            get => base.Padding;
            set => base.Padding = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.BorderWidth" />
        public override double? BorderWidth
        {
            get => base.BorderWidth;
            set => base.BorderWidth = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.SortIndex" />
        public override int? SortIndex
        {
            get => base.SortIndex;
            set => base.SortIndex = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.ObjectId" />
        public override DotEscapeString ObjectId
        {
            get => base.ObjectId;
            set => base.ObjectId = value;
        }

        /// <inheritdoc cref="IDotClusterAttributes.NodeRank" />
        [DotAttributeKey(DotAttributeKeys.Rank)]
        public virtual DotRank? NodeRank
        {
            get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotRank?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotRankAttribute(k, v.Value));
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.BorderColor" />
        [DotAttributeKey(DotAttributeKeys.PenColor)]
        public virtual DotColor BorderColor
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        /// <inheritdoc cref="IDotClusterAttributes.BackgroundColor" />
        [DotAttributeKey(DotAttributeKeys.BgColor)]
        public virtual DotColorDefinition BackgroundColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        /// <inheritdoc cref="IDotClusterAttributes.Peripheries" />
        [DotAttributeKey(DotAttributeKeys.Peripheries)]
        public virtual int? Peripheries
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemovePeripheries(MethodBase.GetCurrentMethod(), value);
        }

        protected override void SetFillStyle(DotStyles fillStyle)
        {
            Style.FillStyle = (DotClusterFillStyle) fillStyle;
        }
    }
}