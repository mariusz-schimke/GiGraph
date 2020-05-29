using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    public partial class DotCommonEdgeCollection : IDotEntity, ICollection<DotCommonEdge>
    {
        /// <summary>
        /// Adds a group of edges where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to all <paramref name="headNodeIds"/> as head nodes.
        /// </summary>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes.</param>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        public virtual DotManyToManyEdgeGroup AddManyToMany(IEnumerable<string> tailNodeIds, IEnumerable<string> headNodeIds,
            Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotManyToManyEdgeGroup(tailNodeIds, headNodeIds), initEdge);
        }
    }
}
