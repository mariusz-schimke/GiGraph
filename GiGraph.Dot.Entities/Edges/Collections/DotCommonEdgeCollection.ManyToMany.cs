using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;
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
        /// <param name="initEdge">An optional initializer delegate to call for the attributes of the created edge group.</param>
        public virtual DotManyToManyEdgeGroup AddManyToMany(IEnumerable<string> tailNodeIds, IEnumerable<string> headNodeIds,
            Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotManyToManyEdgeGroup(tailNodeIds, headNodeIds), initEdge);
        }

        /// <summary>
        /// Adds a group of edges where all nodes in the specified tail endpoint group is connected to
        /// all nodes in the specified head endpoint group.
        /// </summary>
        /// <param name="tail">The group whose nodes should be the tail endpoints.</param>
        /// <param name="head">The group whose nodes (as the head endpoints) the <paramref name="tail"/> nodes should be connected to.</param>
        /// <param name="initEdge">An optional initializer delegate to call for the attributes of the created edge group.</param>
        public virtual DotManyToManyEdgeGroup AddManyToMany(DotEndpointGroup tail, DotEndpointGroup head,
            Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotManyToManyEdgeGroup(tail, head), initEdge);
        }

        /// <summary>
        /// Adds a group of edges where all nodes in the specified tail subgraph is connected to
        /// all nodes in the specified head subgraph.
        /// </summary>
        /// <param name="tail">The subgraph whose nodes should be the tail endpoints.</param>
        /// <param name="head">The subgraph whose nodes (as the head endpoints) the <paramref name="tail"/> nodes should be connected to.</param>
        /// <param name="initEdge">An optional initializer delegate to call for the attributes of the created edge group.</param>
        public virtual DotManyToManyEdgeGroup AddManyToMany(DotSubgraph tail, DotSubgraph head,
            Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotManyToManyEdgeGroup(tail, head), initEdge);
        }
    }
}
