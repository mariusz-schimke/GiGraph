using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    public partial class DotCommonEdgeCollection : IDotEntity, ICollection<DotCommonEdge>
    {
        /// <summary>
        /// Adds a sequence of edges that join specified nodes consecutively.
        /// At least a pair of identifiers has to be provided.
        /// </summary>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges (at least a pair is required).</param>
        public virtual DotEdgeSequence AddSequence(params string[] nodeIds)
        {
            return AddSequence(nodeIds, initEdge: null);
        }

        /// <summary>
        /// Adds a sequence of edges that join specified nodes consecutively.
        /// At least a pair of identifiers has to be provided.
        /// </summary>
        /// <param name="initEdge">An optional initializer delegate to call for the attributes of the created sequence.</param>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges (at least a pair is required).</param>
        public virtual DotEdgeSequence AddSequence(Action<IDotEdgeAttributes> initEdge, params string[] nodeIds)
        {
            return AddSequence(nodeIds, initEdge);
        }

        /// <summary>
        /// Adds a sequence of edges that join specified nodes consecutively.
        /// At least a pair of identifiers has to be provided.
        /// </summary>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges (at least a pair is required).</param>
        /// <param name="initEdge">An optional initializer delegate to call for the attributes of the created sequence.</param>
        public virtual DotEdgeSequence AddSequence(IEnumerable<string> nodeIds, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(DotEdgeSequence.FromNodes(nodeIds), initEdge);
        }

        /// <summary>
        /// Adds a sequence of edges that connect the specified endpoints consecutively.
        /// At least a pair of endpoints has to be provided.
        /// </summary>
        /// <param name="endpoints">The endpoints to initialize the instance with (at least a pair is required).</param>
        public virtual DotEdgeSequence AddSequence(params DotCommonEndpoint[] endpoints)
        {
            return AddSequence(endpoints, initEdge: null);
        }

        /// <summary>
        /// Adds a sequence of edges that connect the specified endpoints consecutively.
        /// At least a pair of endpoints has to be provided.
        /// </summary>
        /// <param name="initEdge">An optional initializer delegate to call for the attributes of the created sequence.</param>
        /// <param name="endpoints">The endpoints to initialize the instance with (at least a pair is required).</param>
        public virtual DotEdgeSequence AddSequence(Action<IDotEdgeAttributes> initEdge, params DotCommonEndpoint[] endpoints)
        {
            return AddSequence(endpoints, initEdge);
        }

        /// <summary>
        /// Adds a sequence of edges that connect the specified endpoints consecutively.
        /// At least a pair of endpoints has to be provided.
        /// </summary>
        /// <param name="endpoints">The endpoints to initialize the instance with (at least a pair is required).</param>
        /// <param name="initEdge">An optional initializer delegate to call for the attributes of the created sequence.</param>
        public virtual DotEdgeSequence AddSequence(IEnumerable<DotCommonEndpoint> endpoints, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotEdgeSequence(endpoints), initEdge);
        }
    }
}
