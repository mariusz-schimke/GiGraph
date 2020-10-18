using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public class DotGraphClusterAttributes : DotEntityAttributes<IDotGraphClusterAttributes>, IDotGraphClusterAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphClusterAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotGraphClusterAttributes));

        protected DotGraphClusterAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotGraphClusterAttributes(DotAttributeCollection attributes)
            : base(attributes, GraphClusterAttributesKeyLookup)
        {
        }

        [DotAttributeKey("color")]
        public virtual DotColorDefinition Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey("pencolor")]
        public virtual DotColor BoundingBoxColor
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey("fillcolor")]
        public virtual DotColorDefinition FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey("compound")]
        public virtual bool? AllowEdgeClipping
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey("clusterrank")]
        public virtual DotClusterVisualizationMode? VisualizationMode
        {
            get => GetValueAs<DotClusterVisualizationMode>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotClusterVisualizationMode?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotClusterVisualizationModeAttribute(k, v.Value));
        }
    }
}