using GiGraph.Dot.Entities.Attributes.Collections.Graph;

namespace GiGraph.Dot.Entities.Clusters.Collections
{
    public class DotGraphClusterCollection : DotClusterCollection
    {
        public DotGraphClusterCollection(DotGraphClusterAttributes attributes)
        {
            Attributes = attributes;
        }

        /// <summary>
        ///     The global graph attributes applied to clusters.
        /// </summary>
        public virtual DotGraphClusterAttributes Attributes { get; }
    }
}