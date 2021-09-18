using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Clusters.Collections
{
    public partial class DotGraphClusterCollection : IDotGraphClustersRootAttributes
    {
        /// <inheritdoc cref="IDotGraphClustersRootAttributes.Style" />
        public DotClusterStyleAttributeOptions Style => Attributes.Implementation.Style;

        /// <inheritdoc cref="IDotGraphClustersAttributes.AllowEdgeClipping" />
        public virtual bool? AllowEdgeClipping
        {
            get => Attributes.Implementation.AllowEdgeClipping;
            set => Attributes.Implementation.AllowEdgeClipping = value;
        }

        /// <inheritdoc cref="IDotGraphClustersAttributes.VisualizationMode" />
        public virtual DotClusterVisualizationMode? VisualizationMode
        {
            get => Attributes.Implementation.VisualizationMode;
            set => Attributes.Implementation.VisualizationMode = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.Color" />
        public virtual DotColorDefinition Color
        {
            get => Attributes.Implementation.Color;
            set => Attributes.Implementation.Color = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.FillColor" />
        public virtual DotColorDefinition FillColor
        {
            get => Attributes.Implementation.FillColor;
            set => Attributes.Implementation.FillColor = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.BorderWidth" />
        public virtual double? BorderWidth
        {
            get => Attributes.Implementation.BorderWidth;
            set => Attributes.Implementation.BorderWidth = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.BorderColor" />
        public virtual DotColor BorderColor
        {
            get => Attributes.Implementation.BorderColor;
            set => Attributes.Implementation.BorderColor = value;
        }
    }
}