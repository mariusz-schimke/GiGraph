using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
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
            DotEntityHyperlinkAttributes hyperlinkAttributes,
            DotEntityFontAttributes fontAttributes,
            DotClusterStyleAttributes styleAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
            Font = fontAttributes;
            Style = styleAttributes;
        }

        public DotClusterAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                ClusterAttributesKeyLookup,
                new DotEntityHyperlinkAttributes(attributes),
                new DotEntityFontAttributes(attributes),
                new DotClusterStyleAttributes(attributes)
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
        public virtual DotEntityFontAttributes Font { get; }

        /// <summary>
        ///     Style options.
        /// </summary>
        // the attribute key is added here redundantly so it appears in attribute key mapping
        [DotAttributeKey(DotEntityStyleAttributes.StyleKey)]
        public virtual DotClusterStyleAttributes Style { get; }

        // accessible only through the interface
        [DotAttributeKey(DotEntityStyleAttributes.StyleKey)]
        DotStyles? IDotClusterAttributes.Style
        {
            get => GetValueAs<DotStyles>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotStyles?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotStyleAttribute(k, v.Value));
        }

        // overridden to inherit comment from interface
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        // overridden to inherit comment from interface
        public override string ColorScheme
        {
            get => base.ColorScheme;
            set => base.ColorScheme = value;
        }

        // overridden to inherit comment from interface
        public override DotColorDefinition Color
        {
            get => base.Color;
            set => base.Color = value;
        }

        // overridden to inherit comment from interface
        public override DotColorDefinition FillColor
        {
            get => base.FillColor;
            set => base.FillColor = value;
        }

        // overridden to inherit comment from interface
        public override int? GradientAngle
        {
            get => base.GradientAngle;
            set => base.GradientAngle = value;
        }

        // overridden to inherit comment from interface
        public override DotVerticalAlignment? VerticalLabelAlignment
        {
            get => base.VerticalLabelAlignment;
            set => base.VerticalLabelAlignment = value;
        }

        // overridden to inherit comment from interface
        public override DotEscapeString Tooltip
        {
            get => base.Tooltip;
            set => base.Tooltip = value;
        }

        // overridden to inherit comment from interface
        public override DotPoint Margin
        {
            get => base.Margin;
            set => base.Margin = value;
        }

        // overridden to inherit comment from interface
        public override double? BorderWidth
        {
            get => base.BorderWidth;
            set => base.BorderWidth = value;
        }

        // overridden to inherit comment from interface
        public override int? SortIndex
        {
            get => base.SortIndex;
            set => base.SortIndex = value;
        }

        [DotAttributeKey(DotAttributeKeys.PenColor)]
        public virtual DotColor BorderColor
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.BgColor)]
        public virtual DotColorDefinition BackgroundColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Peripheries)]
        public virtual int? Peripheries
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemovePeripheries(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.LabelJust)]
        public virtual DotHorizontalAlignment? HorizontalLabelAlignment
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotHorizontalAlignment?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotHorizontalAlignmentAttribute(k, v.Value));
        }

        protected override void SetFillStyle(DotStyles fillStyle)
        {
            Style.FillStyle = (DotClusterFillStyle) fillStyle;
        }
    }
}