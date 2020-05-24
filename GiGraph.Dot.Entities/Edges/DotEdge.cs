using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Elements;
using GiGraph.Dot.Entities.Subgraphs;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    public abstract class DotEdge : DotCommonEdge
    {
        protected DotEdge(IDotEdgeAttributes attributes)
            : base(attributes)
        {
        }

        /// <summary>
        /// Creates a new edge connecting two nodes.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node the edge should be connected to.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node the should be connected to.</param>
        public static DotEdge<DotEdgeNode, DotEdgeNode> OneToOne(string tailNodeId, string headNodeId)
        {
            return new DotEdge<DotEdgeNode, DotEdgeNode>
            (
                new DotEdgeNode(tailNodeId),
                new DotEdgeNode(headNodeId)
            );
        }

        /// <summary>
        /// Creates a new edge connecting a single tail node to the nodes of a subgraph as the head.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node the edge should be connected to.</param>
        /// <param name="headSubgraph">The subgraph to use as the head (destination, right) element the edge should be connected to.</param>
        public static DotEdge<DotEdgeNode, DotEdgeSubgraph> OneToMany(string tailNodeId, DotSubgraph headSubgraph)
        {
            return new DotEdge<DotEdgeNode, DotEdgeSubgraph>
            (
                tail: new DotEdgeNode(tailNodeId),
                head: new DotEdgeSubgraph(headSubgraph)
            );
        }

        /// <summary>
        /// Creates a new edge connecting the nodes of a subgraph as the tail to a single head node.
        /// </summary>
        /// <param name="tailSubgraph">The subgraph to use as the tail (source, left) element the edge should be connected to.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node the edge should be connected to.</param>
        public static DotEdge<DotEdgeSubgraph, DotEdgeNode> ManyToOne(DotSubgraph tailSubgraph, string headNodeId)
        {
            return new DotEdge<DotEdgeSubgraph, DotEdgeNode>
            (
                tail: new DotEdgeSubgraph(tailSubgraph),
                head: new DotEdgeNode(headNodeId)
            );
        }

        /// <summary>
        /// Creates a new edge connecting the nodes of a tail subgraph to the nodes of a head subgraph.
        /// </summary>
        /// <param name="tailSubgraph">The subgraph to use as the tail (source, left) element the edge should be connected to.</param>
        /// <param name="headSubgraph">The subgraph to use as the head (destination, right) element the edge should be connected to.</param>
        public static DotEdge<DotEdgeSubgraph, DotEdgeSubgraph> ManyToMany(DotSubgraph tailSubgraph, DotSubgraph headSubgraph)
        {
            return new DotEdge<DotEdgeSubgraph, DotEdgeSubgraph>
            (
                tail: new DotEdgeSubgraph(tailSubgraph),
                head: new DotEdgeSubgraph(headSubgraph)
            );
        }
    }

    /// <summary>
    /// Represents a graph edge that connects two elements.
    /// </summary>
    public class DotEdge<TTail, THead> : DotEdge
        where TTail : DotEdgeElement
        where THead : DotEdgeElement
    {
        /// <summary>
        /// The tail (source, left) element.
        /// </summary>
        public virtual TTail Tail { get; set; }

        /// <summary>
        /// The head (destination, right) element.
        /// </summary>
        public virtual THead Head { get; set; }

        /// <summary>
        /// Gets the elements (tail and head) of this edge.
        /// </summary>
        public override IEnumerable<DotEdgeElement> Elements => new DotEdgeElement[] { Tail, Head };

        /// <summary>
        /// The attributes of the edge.
        /// </summary>
        public override IDotEdgeAttributes Attributes => base.Attributes;

        protected DotEdge(TTail tail, THead head, IDotEdgeAttributes attributes)
            : base(attributes)
        {
            Tail = tail;
            Head = head;
        }

        /// <summary>
        /// Creates a new edge connecting two elements.
        /// </summary>
        /// <param name="tail">The tail (source, left) element the edge should be connected to.</param>
        /// <param name="head">The head (destination, right) element the should be connected to.</param>
        public DotEdge(TTail tail, THead head)
            : this(tail, head, new DotEntityAttributes())
        {
        }
    }
}
