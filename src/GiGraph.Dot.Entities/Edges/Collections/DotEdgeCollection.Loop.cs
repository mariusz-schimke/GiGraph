using System;
using GiGraph.Dot.Entities.Edges.Endpoints;

namespace GiGraph.Dot.Entities.Edges.Collections;

public partial class DotEdgeCollection
{
    /// <summary>
    ///     Adds a loop edge that joins the specified node to itself.
    /// </summary>
    /// <param name="nodeId">
    ///     The node identifier.
    /// </param>
    /// <param name="init">
    ///     An optional edge initializer delegate.
    /// </param>
    public virtual DotEdge AddLoop(string nodeId, Action<DotEdge> init = null)
    {
        return Add(new DotEdge(nodeId), init);
    }

    /// <summary>
    ///     Adds a loop edge that joins the specified node to itself.
    /// </summary>
    /// <param name="endpoint">
    ///     The endpoint to add.
    /// </param>
    /// <param name="init">
    ///     An optional edge initializer delegate.
    /// </param>
    public virtual DotEdge AddLoop(DotEndpoint endpoint, Action<DotEdge> init = null)
    {
        return Add(new DotEdge(endpoint), init);
    }
}