﻿using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Graphs;

namespace GiGraph.Dot.Examples.Basic;

public static class HelloWorld
{
    [Pure]
    public static DotGraph Generate()
    {
        var graph = new DotGraph();

        // add an edge that connects the two specified nodes
        // (you don't have to add the nodes to the node collection of the graph
        // unless you need to specify some attributes for them)
        graph.Edges.Add("Hello", "World!");

        return graph;
    }
}