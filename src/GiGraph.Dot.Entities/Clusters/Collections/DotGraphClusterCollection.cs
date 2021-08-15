using GiGraph.Dot.Entities.Graphs.Attributes;

namespace GiGraph.Dot.Entities.Clusters.Collections
{
    public partial class DotGraphClusterCollection : DotClusterCollection
    {
        public DotGraphClusterCollection(DotGraphClusterRootAttributes attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     Global graph attributes applied to clusters.
        /// </summary>
        public virtual DotGraphClusterRootAttributes Attributes { get; }
    }
}