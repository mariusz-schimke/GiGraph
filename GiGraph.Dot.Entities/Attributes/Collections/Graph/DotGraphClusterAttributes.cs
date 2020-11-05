using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Cluster;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public partial class DotGraphClusterAttributes : DotEntityMappableAttributes<IDotGraphClusterAttributes>, IDotGraphClusterAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphClusterAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphClusterAttributes, IDotGraphClusterAttributes>().Build();

        protected DotGraphClusterAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotClusterStyleAttributes styleAttributes
        )
            : base(attributes, attributeKeyLookup)
        {
            Style = styleAttributes;
        }

        public DotGraphClusterAttributes(DotAttributeCollection attributes)
            : this(
                attributes,
                GraphClusterAttributesKeyLookup,
                new DotClusterStyleAttributes(attributes)
            )
        {
        }

        /// <summary>
        ///     Style options. Note that the options are shared with those of the graph.
        /// </summary>
        public virtual DotClusterStyleAttributes Style { get; }

        [DotAttributeKey(DotAttributeKeys.Color)]
        public virtual DotColorDefinition Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.PenWidth)]
        public virtual double? BorderWidth
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => AddOrRemoveBorderWidth(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.PenColor)]
        public virtual DotColor BorderColor
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.FillColor)]
        public virtual DotColorDefinition FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotColorDefinitionAttribute(k, v));
        }

        [DotAttributeKey(DotAttributeKeys.Compound)]
        public virtual bool? AllowEdgeClipping
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotBoolAttribute(k, v.Value));
        }

        [DotAttributeKey(DotAttributeKeys.ClusterRank)]
        public virtual DotClusterVisualizationMode? VisualizationMode
        {
            get => GetValueAs<DotClusterVisualizationMode>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotClusterVisualizationMode?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotClusterVisualizationModeAttribute(k, v.Value));
        }
    }
}