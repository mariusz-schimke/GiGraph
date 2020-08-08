using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Collections.Node;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Graphs
{
    public abstract class DotCommonGraph<TAttributes> : DotCommonGraph
        where TAttributes : IDotAttributeCollection
    {
        protected DotCommonGraph(
            string id,
            TAttributes attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotSubgraphCollection subgraphs,
            DotClusterCollection clusters,
            IDotNodeAttributeCollection nodeDefaults,
            IDotEdgeAttributeCollection edgeDefaults)
            : base(id, attributes, nodes, edges, subgraphs, clusters, nodeDefaults, edgeDefaults)
        {
        }

        /// <summary>
        ///     The attributes of the element.
        /// </summary>
        public virtual TAttributes Attributes => (TAttributes) _attributes;
    }
}