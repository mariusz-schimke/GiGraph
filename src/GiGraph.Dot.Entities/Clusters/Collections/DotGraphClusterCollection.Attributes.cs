using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Clusters.Collections
{
    public partial class DotGraphClusterCollection : IDotGraphClusterRootAttributes
    {
        /// <inheritdoc cref="IDotGraphClusterRootAttributes.Style" />
        public virtual DotClusterStyleAttributes Style => ((IDotGraphClusterRootAttributes) Attributes).Style;

        /// <inheritdoc cref="IDotGraphClusterAttributes.AllowEdgeClipping" />
        public virtual bool? AllowEdgeClipping
        {
            get => ((IDotGraphClusterAttributes) Attributes).AllowEdgeClipping;
            set => ((IDotGraphClusterAttributes) Attributes).AllowEdgeClipping = value;
        }

        /// <inheritdoc cref="IDotGraphClusterAttributes.VisualizationMode" />
        public virtual DotClusterVisualizationMode? VisualizationMode
        {
            get => ((IDotGraphClusterAttributes) Attributes).VisualizationMode;
            set => ((IDotGraphClusterAttributes) Attributes).VisualizationMode = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.Color" />
        public virtual DotColorDefinition Color
        {
            get => ((IDotGraphClusterCommonAttributes) Attributes).Color;
            set => ((IDotGraphClusterCommonAttributes) Attributes).Color = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.FillColor" />
        public virtual DotColorDefinition FillColor
        {
            get => ((IDotGraphClusterCommonAttributes) Attributes).FillColor;
            set => ((IDotGraphClusterCommonAttributes) Attributes).FillColor = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.BorderWidth" />
        public virtual double? BorderWidth
        {
            get => ((IDotGraphClusterCommonAttributes) Attributes).BorderWidth;
            set => ((IDotGraphClusterCommonAttributes) Attributes).BorderWidth = value;
        }

        /// <inheritdoc cref="IDotGraphClusterCommonAttributes.BorderColor" />
        public virtual DotColor BorderColor
        {
            get => ((IDotGraphClusterCommonAttributes) Attributes).BorderColor;
            set => ((IDotGraphClusterCommonAttributes) Attributes).BorderColor = value;
        }
    }
}