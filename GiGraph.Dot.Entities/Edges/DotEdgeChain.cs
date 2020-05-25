using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Elements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents an chain of edges that connect multiple consecutive elements.
    /// </summary>
    public class DotEdgeChain : DotCommonEdge
    {
        /// <summary>
        /// The attributes of the edge chain.
        /// </summary>
        public override IDotEdgeAttributes Attributes => base.Attributes;

        /// <summary>
        /// Gets the elements of this edge chain.
        /// </summary>
        public override IEnumerable<DotEdgeElement> Elements { get; }

        protected DotEdgeChain(ICollection<DotEdgeElement> elements, IDotEdgeAttributes attributes)
            : base(attributes)
        {
            Elements = elements.Count > 1
                ? elements
                : throw new ArgumentException("At least a pair of elements has to be specified for an edge chain.", nameof(elements));
        }

        /// <summary>
        /// Creates a new edge chain initialized with the specified elements.
        /// At least a pair of elements has to be specified.
        /// </summary>
        /// <param name="elements">The elements to initialize the instance with.</param>
        public DotEdgeChain(params DotEdgeElement[] elements)
            : this((IEnumerable<DotEdgeElement>)elements)
        {
        }

        /// <summary>
        /// Creates a new edge chain initialized with the specified elements.
        /// At least a pair of elements has to be specified.
        /// </summary>
        /// <param name="elements">The elements to initialize the instance with.</param>
        public DotEdgeChain(IEnumerable<DotEdgeElement> elements)
            : this(new List<DotEdgeElement>(elements), new DotEntityAttributes())
        {
        }

        /// <summary>
        /// Creates a new edge chain initialized with the specified node identifiers.
        /// At least a pair of identifiers has to be specified.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public static DotEdgeChain FromNodes(params string[] nodeIds)
        {
            return FromNodes((IEnumerable<string>)nodeIds);
        }

        /// <summary>
        /// Creates a new edge chain initialized with the specified node identifiers.
        /// At least a pair of identifiers has to be specified.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public static DotEdgeChain FromNodes(IEnumerable<string> nodeIds)
        {
            return new DotEdgeChain
            (
                nodeIds.Select(nodeId => new DotEdgeNode(nodeId))
            );
        }
    }
}
