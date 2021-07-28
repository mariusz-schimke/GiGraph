using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Styling;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common
{
    public abstract partial class DotClusterNodeCommonAttributes<TIEntityAttributeProperties> : DotEntityRootCommonAttributes<TIEntityAttributeProperties>
    {
        protected DotClusterNodeCommonAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotHyperlinkAttributes hyperlinkAttributes,
            DotStyleSheetAttributes styleSheetAttributes
        )
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
            StyleSheet = styleSheetAttributes;
        }

        /// <summary>
        ///     Style sheet attributes used for SVG output.
        /// </summary>
        public virtual DotStyleSheetAttributes StyleSheet { get; }

        [DotAttributeKey(DotAttributeKeys.Color)]
        public virtual DotColorDefinition Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemoveComplexAttribute(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.FillColor)]
        public virtual DotColorDefinition FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemoveComplexAttribute(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.GradientAngle)]
        public virtual int? GradientFillAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemoveNumericAttribute(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.PenWidth)]
        public virtual double? BorderWidth
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemoveBorderWidth(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Tooltip)]
        public virtual DotEscapeString Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemoveEscapeStringAttribute(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Margin)]
        public virtual DotPoint Padding
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemoveComplexAttribute(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.SortV)]
        public virtual int? SortIndex
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemoveNumericAttribute(MethodBase.GetCurrentMethod(), value);
        }

        protected abstract void SetFillStyle(DotStyles fillStyle);
    }
}