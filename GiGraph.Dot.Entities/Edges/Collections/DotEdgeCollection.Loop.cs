using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    public partial class DotEdgeCollection
    {
        /// <summary>
        /// Adds a loop edge that connects the specified node to itself.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        /// <param name="init">An optional edge initializer delegate.</param>
        public virtual DotEdge AddLoop(string nodeId, Action<DotEdge> init = null)
        {
            return Add(DotEdge.Loop(nodeId), init);
        }

        /// <summary>
        /// Gets the first matching loop edge that connects the specified node to itself.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        public virtual DotEdge GetLoop(string nodeId)
        {
            return GetAllLoops(nodeId).FirstOrDefault();
        }

        /// <summary>
        /// Gets all loop edges.
        /// </summary>
        public virtual IEnumerable<DotEdge> GetAllLoops()
        {
            return this.OfType<DotEdge>()
                       .Where(edge => edge.IsLoop);
        }

        /// <summary>
        /// Gets loop edges that connect the specified node to itself.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        public virtual IEnumerable<DotEdge> GetAllLoops(string nodeId)
        {
            return GetAll(nodeId, nodeId);
        }

        /// <summary>
        /// Determines whether the collection contains any loop edges.
        /// </summary>
        public virtual bool ContainsLoops()
        {
            return Exists(_matchLoopPredicate);
        }

        /// <summary>
        /// Determines whether the collection contains any loop edge that connects the specified node to itself.
        /// </summary>
        /// <param name="nodeId">The node identifier to locate.</param>
        public virtual bool ContainsLoop(string nodeId)
        {
            return GetAllLoops(nodeId).Any();
        }

        /// <summary>
        /// Removes the first matching loop edge that connects the specified node to itself.
        /// </summary>
        /// <param name="nodeId">The node identifier of the loop edge to remove.</param>
        public virtual bool RemoveLoop(string nodeId)
        {
            return Remove(nodeId, nodeId);
        }

        /// <summary>
        /// Removes all loop edges from the collection.
        /// </summary>
        public virtual int RemoveAllLoops()
        {
            return RemoveAll(_matchLoopPredicate);
        }

        /// <summary>
        /// Removes all loop edges that connect the specified node to itself.
        /// </summary>
        /// <param name="nodeId">The node identifier of the loop edges to remove.</param>
        public virtual int RemoveAllLoops(string nodeId)
        {
            return RemoveAll(nodeId, nodeId);
        }
    }
}