using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;
using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    public partial class DotEdgeCollection
    {
        /// <summary>
        /// Adds a group of edges where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to all <paramref name="headNodeIds"/> as head nodes.
        /// </summary>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes.</param>
        /// <param name="init">An optional initializer delegate to call for the created edge group.</param>
        public virtual DotManyToManyEdgeGroup AddManyToMany(IEnumerable<string> tailNodeIds, IEnumerable<string> headNodeIds, Action<DotManyToManyEdgeGroup> init = null)
        {
            return Add(new DotManyToManyEdgeGroup(tailNodeIds, headNodeIds), init);
        }

        /// <summary>
        /// Adds a group of edges where all nodes in the specified tail endpoint group is connected to
        /// all nodes in the specified head endpoint group.
        /// </summary>
        /// <param name="tail">The group whose nodes should be the tail endpoints.</param>
        /// <param name="head">The group whose nodes (as the head endpoints) the <paramref name="tail"/> nodes should be connected to.</param>
        /// <param name="init">An optional initializer delegate to call for the created edge group.</param>
        public virtual DotManyToManyEdgeGroup AddManyToMany(DotEndpointGroup tail, DotEndpointGroup head, Action<DotManyToManyEdgeGroup> init = null)
        {
            return Add(new DotManyToManyEdgeGroup(tail, head), init);
        }

        /// <summary>
        /// Adds a group of edges where all nodes in the specified tail subgraph is connected to
        /// all nodes in the specified head subgraph.
        /// </summary>
        /// <param name="tail">The subgraph whose nodes should be the tail endpoints.</param>
        /// <param name="head">The subgraph whose nodes (as the head endpoints) the <paramref name="tail"/> nodes should be connected to.</param>
        /// <param name="init">An optional initializer delegate to call for the created edge group.</param>
        public virtual DotManyToManyEdgeGroup AddManyToMany(DotSubgraph tail, DotSubgraph head, Action<DotManyToManyEdgeGroup> init = null)
        {
            return Add(new DotManyToManyEdgeGroup(tail, head), init);
        }
    }
}