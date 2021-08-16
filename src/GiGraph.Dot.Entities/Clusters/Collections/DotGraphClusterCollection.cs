using GiGraph.Dot.Entities.Graphs.Attributes;

namespace GiGraph.Dot.Entities.Clusters.Collections
{
    public partial class DotGraphClusterCollection : DotClusterCollection
    {
        protected readonly DotGraphRootAttributes _graphAttributes;

        public DotGraphClusterCollection(DotGraphRootAttributes graphAttributes, DotGraphClusterRootAttributes graphClusterAttributes)
        {
            _graphAttributes = graphAttributes;
            Attributes = graphClusterAttributes;
        }

        /// <summary>
        ///     Global graph attributes applied to clusters.
        /// </summary>
        public virtual DotGraphClusterRootAttributes Attributes { get; }
    }
}