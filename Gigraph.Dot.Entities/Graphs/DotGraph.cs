using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Entities.Nodes;
using Gigraph.Dot.Entities.Subgraphs;

namespace Gigraph.Dot.Entities.Graphs
{
    public class DotGraph : DotCommonGraph
    {
        /// <summary>
        /// Gets or sets a value that determines if the graph is directed.
        /// The edges of directed graphs are presented as arrows, whereas edges in undirected graphs are presented as lines.
        /// </summary>
        public bool IsDirected { get; set; }

        /// <summary>
        /// Gets or sets a value that determines if the graph is strict.
        /// Strict graph forbids the creation of multi-edges, i.e., there can be at most one edge with a given tail node and head node in the directed case.
        /// </summary>
        public bool IsStrict { get; set; }

        /// <summary>
        /// The attributes of the graph.
        /// </summary>
        public new DotGraphAttributeCollection Attributes => (DotGraphAttributeCollection)base.Attributes;

        protected DotGraph(string id, bool isDirected, bool isStrict, DotGraphAttributeCollection attributes, DotNodeCollection nodes, DotEdgeCollection edges, DotCommonSubgraphCollection subgraphs)
            : base(id, attributes, nodes, edges, subgraphs)
        {
            IsDirected = isDirected;
            IsStrict = isStrict;
        }

        /// <summary>
        /// Creates a new graph instance.
        /// </summary>
        /// <param name="id">The identifier of the graph. Pass null if no identifier should be used.</param>
        /// <param name="isDirected">Determines if the graph should be directed.
        /// The edges of directed graphs are presented as arrows, whereas edges in undirected graphs are presented as lines.</param>
        /// <param name="isStrict">Determines if the graph is strict.
        /// Strict graph forbids the creation of multi-edges, i.e., there can be at most one edge with a given tail node and head node in the directed case.</param>
        public DotGraph(string id = null, bool isDirected = true, bool isStrict = false)
            : this(id, isDirected, isStrict, new DotGraphAttributeCollection(), new DotNodeCollection(), new DotEdgeCollection(), new DotCommonSubgraphCollection())
        {
        }
    }
}
