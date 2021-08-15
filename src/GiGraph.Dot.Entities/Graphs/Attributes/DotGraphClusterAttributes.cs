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
    public partial class DotGraphClusterAttributes : DotEntityMappableAttributes<IDotGraphClusterAttributes>, IDotGraphClusterAttributesRoot
    {
        protected static readonly DotMemberAttributeKeyLookup GraphClusterAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphClusterAttributes, IDotGraphClusterAttributes>().Build();

        protected readonly DotGraphRootAttributes _graphAttributes;
        protected readonly DotClusterStyleAttributes _style;

        protected DotGraphClusterAttributes(
            DotGraphRootAttributes graphAttributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotClusterStyleAttributes styleAttributes
        )
            : base(graphAttributes.Collection, attributeKeyLookup)
        {
            _graphAttributes = graphAttributes;
            _style = styleAttributes;
        }

        public DotGraphClusterAttributes(DotGraphRootAttributes graphAttributes)
            : this(
                graphAttributes,
                GraphClusterAttributesKeyLookup,
                new DotClusterStyleAttributes(graphAttributes.Collection)
            )
        {
        }

        DotClusterStyleAttributes IDotGraphClusterAttributesRoot.Style => _style;

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