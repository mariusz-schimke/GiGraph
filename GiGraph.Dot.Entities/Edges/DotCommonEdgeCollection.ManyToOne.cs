using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    public partial class DotCommonEdgeCollection : IDotEntity, ICollection<DotCommonEdge>
    {
        /// <summary>
        /// Adds a group of edges where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to the <paramref name="headNodeId"/> as the head node.
        /// </summary>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes to connect to the head node.</param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(string headNodeId, params string[] tailNodeIds)
        {
            return AddManyToOne(tailNodeIds, headNodeId);
        }

        /// <summary>
        /// Adds a group of edges where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to the <paramref name="headNodeId"/> as the head node.
        /// </summary>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes to connect to the head node.</param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(Action<IDotEdgeAttributes> initEdge, string headNodeId, params string[] tailNodeIds)
        {
            return AddManyToOne(tailNodeIds, headNodeId, initEdge);
        }

        /// <summary>
        /// Adds a group of edges where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to the <paramref name="headNodeId"/> as the head node.
        /// </summary>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes to connect to the head node.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(IEnumerable<string> tailNodeIds, string headNodeId, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotManyToOneEdgeGroup(tailNodeIds, headNodeId), initEdge);
        }
    }
}
