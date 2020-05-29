using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    public partial class DotCommonEdgeCollection : IDotEntity, ICollection<DotCommonEdge>
    {
        /// <summary>
        /// Adds a group of edges where the <paramref name="tailNodeId"/> as the tail node is connected
        /// to all <paramref name="headNodeIds"/> as the head nodes.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes to connect the tail node to.</param>
        public virtual DotOneToManyEdgeGroup AddOneToMany(string tailNodeId, params string[] headNodeIds)
        {
            return AddOneToMany(tailNodeId, (IEnumerable<string>)headNodeIds);
        }

        /// <summary>
        /// Adds a group of edges where the <paramref name="tailNodeId"/> as the tail node is connected
        /// to all <paramref name="headNodeIds"/> as the head nodes.
        /// </summary>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes to connect the tail node to.</param>
        public virtual DotOneToManyEdgeGroup AddOneToMany(Action<IDotEdgeAttributes> initEdge, string tailNodeId, params string[] headNodeIds)
        {
            return AddOneToMany(tailNodeId, headNodeIds, initEdge);
        }

        /// <summary>
        /// Adds a group of edges where the <paramref name="tailNodeId"/> as the tail node is connected
        /// to all <paramref name="headNodeIds"/> as the head nodes.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes to connect the tail node to.</param>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        public virtual DotOneToManyEdgeGroup AddOneToMany(string tailNodeId, IEnumerable<string> headNodeIds, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotOneToManyEdgeGroup(tailNodeId, headNodeIds), initEdge);
        }
    }
}
