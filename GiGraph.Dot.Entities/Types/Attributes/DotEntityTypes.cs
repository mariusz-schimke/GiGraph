using System;

namespace GiGraph.Dot.Entities.Types.Attributes
{
    [Flags]
    public enum DotEntityTypes
    {
        Graph = 1 << 0,
        Subgraph = 1 << 1,
        Cluster = 1 << 2,
        Node = 1 << 3,
        Edge = 1 << 4
    }
}