using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public abstract class DotClusterNodeCommonAttributes<TIEntityAttributeProperties> : DotEntityCommonAttributes<TIEntityAttributeProperties>
    {
        protected DotClusterNodeCommonAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup, DotEntityHyperlinkAttributes hyperlinkAttributes)
            : base(attributes, attributeKeyLookup, hyperlinkAttributes)
        {
        }

        [DotAttributeKey(DotAttributeKeys.Color)]
        public virtual DotColorDefinition Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.FillColor)]
        public virtual DotColorDefinition FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.GradientAngle)]
        public virtual int? GradientAngle
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.PenWidth)]
        public virtual double? BorderWidth
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemoveBorderWidth(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.LabelLoc)]
        public virtual DotVerticalAlignment? VerticalLabelAlignment
        {
            get => GetValueAs<DotVerticalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotVerticalAlignment?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotVerticalAlignmentAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.Tooltip)]
        public virtual DotEscapeString Tooltip
        {
            get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEscapeStringAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Margin)]
        public virtual DotPoint Margin
        {
            get => GetValueAsPoint(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotPointAttribute(k, v));
        }
        
        [DotAttributeKey(DotAttributeKeys.SortV)]
        public virtual int? SortIndex
        {
            get => GetValueAsInt(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotIntAttribute(k, v.Value));
        }
    }
}