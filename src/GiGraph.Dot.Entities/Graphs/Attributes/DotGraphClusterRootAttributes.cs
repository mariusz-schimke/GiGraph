using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public class DotGraphClusterRootAttributes : DotEntityAttributesAccessor<IDotGraphClusterAttributes>, IDotGraphClusterRootAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> GraphClusterRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphClusterRootAttributes, IDotGraphClusterAttributes>().BuildLazy();

        protected readonly DotClusterStyleAttributeOptions _styleAttributeOptions;

        protected DotGraphClusterRootAttributes(
            DotGraphRootAttributes graphAttributes,
            Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
            DotClusterStyleAttributeOptions styleAttributeOptions
        )
            : base(graphAttributes.Collection, attributeKeyLookup)
        {
            _styleAttributeOptions = styleAttributeOptions;
        }

        public DotGraphClusterRootAttributes(DotGraphRootAttributes graphAttributes)
            : this(
                graphAttributes,
                GraphClusterRootAttributesKeyLookup,
                new DotClusterStyleAttributeOptions(graphAttributes.Collection)
            )
        {
        }

        DotClusterStyleAttributeOptions IDotGraphClusterRootAttributes.Style => _styleAttributeOptions;

        [DotAttributeKey(DotAttributeKeys.Color)]
        DotColorDefinition IDotGraphClusterCommonAttributes.Color
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.PenWidth)]
        double? IDotGraphClusterCommonAttributes.BorderWidth
        {
            get => GetValueAsDouble(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.PenColor)]
        DotColor IDotGraphClusterCommonAttributes.BorderColor
        {
            get => GetValueAsColor(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.FillColor)]
        DotColorDefinition IDotGraphClusterCommonAttributes.FillColor
        {
            get => GetValueAsColorDefinition(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.Compound)]
        bool? IDotGraphClusterAttributes.AllowEdgeClipping
        {
            get => GetValueAsBool(MethodBase.GetCurrentMethod());
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
        }

        [DotAttributeKey(DotAttributeKeys.ClusterRank)]
        DotClusterVisualizationMode? IDotGraphClusterAttributes.VisualizationMode
        {
            get => GetValueAs<DotClusterVisualizationMode>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }
    }
}