using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Entities.Attributes.Collections.Node;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Graphs.Collections;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Graphs
{
    /// <summary>
    ///     Represents a graph (the root DOT graph).
    /// </summary>
    public class DotGraph : DotCommonGraph<IDotGraphAttributeCollection>
    {
        protected DotGraph(
            string id,
            bool isDirected,
            bool isStrict,
            IDotGraphAttributeCollection attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotSubgraphCollection subgraphs,
            DotClusterCollection clusters,
            IDotNodeAttributeCollection nodeDefaults,
            IDotEdgeAttributeCollection edgeDefaults,
            DotGraphSectionCollection<IDotGraphAttributeCollection> subsections)
            : base(id, attributes, nodes, edges, subgraphs, clusters, nodeDefaults, edgeDefaults, subsections)
        {
            IsDirected = isDirected;
            IsStrict = isStrict;
        }

        protected DotGraph(
            string id,
            bool isDirected,
            bool isStrict,
            DotGraphSection<IDotGraphAttributeCollection> rootSection,
            DotGraphSectionCollection<IDotGraphAttributeCollection> subsections)
            : this(id, isDirected, isStrict, rootSection.Attributes, rootSection.Nodes, rootSection.Edges, rootSection.Subgraphs, rootSection.Clusters, rootSection.NodeDefaults, rootSection.EdgeDefaults, subsections)
        {
        }

        /// <summary>
        ///     Creates a new graph instance.
        /// </summary>
        /// <param name="id">
        ///     The identifier of the graph. Pass null if no identifier should be used.
        /// </param>
        /// <param name="isDirected">
        ///     Determines if the graph should be directed. The edges of directed graphs are presented as arrows, whereas edges in undirected
        ///     graphs are presented as lines.
        /// </param>
        /// <param name="isStrict">
        ///     Determines if the graph is strict. Strict graph forbids the creation of multi-edges, i.e., there may be at most one edge with
        ///     a given tail node and head node in the directed case.
        /// </param>
        public DotGraph(string id = null, bool isDirected = true, bool isStrict = false)
            : this(id, isDirected, isStrict, CreateSection(), new DotGraphSectionCollection<IDotGraphAttributeCollection>(CreateSection))
        {
        }

        /// <summary>
        ///     Gets or sets a value that determines if the graph is directed. The edges of directed graphs are presented as arrows, whereas
        ///     edges in undirected graphs are presented as lines.
        /// </summary>
        public virtual bool IsDirected { get; set; }

        /// <summary>
        ///     Gets or sets a value that determines if the graph is strict. Strict graph forbids the creation of multi-edges, i.e., there
        ///     may be at most one edge with a given tail node and head node in the directed case.
        /// </summary>
        public virtual bool IsStrict { get; set; }

        protected static DotGraphSection<IDotGraphAttributeCollection> CreateSection()
        {
            return Create(new DotGraphAttributeCollection());
        }
    }
}