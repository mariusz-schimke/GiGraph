using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Graphs.Attributes;

namespace GiGraph.Dot.Entities.Clusters.Collections
{
    public partial class DotGraphClusterCollection : DotClusterCollection
    {
        private readonly DotGraphRootAttributes _graphAttributes;

        public DotGraphClusterCollection(DotGraphRootAttributes graphAttributes, DotGraphClustersRootAttributes graphClustersAttributes)
        {
            _graphAttributes = graphAttributes;
            Attributes = new DotEntityAttributesAccessor<IDotGraphClusterAttributes, DotGraphClustersRootAttributes>(graphClustersAttributes);
        }

        /// <summary>
        ///     Provides access to the global graph attributes applied to clusters.
        /// </summary>
        public virtual DotEntityAttributesAccessor<IDotGraphClusterAttributes, DotGraphClustersRootAttributes> Attributes { get; }
    }
}