using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public class DotGraphClustersAttributes : DotEntityAttributes<IDotGraphClustersAttributes, DotGraphClustersAttributes>, IDotGraphClustersRootAttributes
    {
        // TODO: jeśli te kolekcje staną się prywatne, można skrócić im nazwy
        protected static readonly Lazy<DotMemberAttributeKeyLookup> GraphClusterRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphClustersAttributes, IDotGraphClustersAttributes>().BuildLazy();

        public DotGraphClustersAttributes(DotAttributeCollection attributes)
            : base(attributes, GraphClusterRootAttributesKeyLookup)
        {
            Style = new DotClusterStyleAttributeOptions(attributes);
        }

        public virtual DotClusterStyleAttributeOptions Style { get; }

        [DotAttributeKey(DotAttributeKeys.Color)]
        public virtual DotColorDefinition Color
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

        [DotAttributeKey(DotAttributeKeys.PenColor)]
        public virtual DotColor BorderColor
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.FillColor)]
        public virtual DotColorDefinition FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Compound)]
        public virtual bool? AllowEdgeClipping
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.ClusterRank)]
        public virtual DotClusterVisualizationMode? VisualizationMode
        {
            get => GetValueAs<DotClusterVisualizationMode>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }
    }
}