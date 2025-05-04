using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Types.Graphs.Layout;
using GiGraph.Dot.Types.Graphs.Layout.Spacing;

namespace GiGraph.Dot.Examples.Complex;

public static class WithCustomNodeLayout
{
    [Pure]
    public static DotGraph Generate()
    {
        var graph = new DotGraph(directed: false);

        // see also how this attribute affects the layout of the nodes
        graph.Layout.Direction = DotLayoutDirection.LeftToRight;

        graph.Edges.Add("e", "h");
        graph.Edges.Add("g", "k");
        graph.Edges.Add("r", "t");

        graph.Edges.AddOneToMany("a", ["b", "c", "d"]);
        graph.Edges.AddOneToMany("b", ["c", "e"]);
        graph.Edges.AddOneToMany("c", ["e", "f"]);
        graph.Edges.AddOneToMany("d", ["f", "g"]);
        graph.Edges.AddOneToMany("f", ["h", "i", "j", "g"]);
        graph.Edges.AddOneToMany("h", ["o", "l"]);
        graph.Edges.AddOneToMany("i", ["l", "m", "j"]);
        graph.Edges.AddOneToMany("j", ["m", "n", "k"]);
        graph.Edges.AddOneToMany("k", ["n", "r"]);
        graph.Edges.AddOneToMany("l", ["o", "m"]);
        graph.Edges.AddOneToMany("m", ["o", "p", "n"]);
        graph.Edges.AddOneToMany("n", ["q", "r"]);
        graph.Edges.AddOneToMany("o", ["s", "p"]);
        graph.Edges.AddOneToMany("p", ["t", "q"]);
        graph.Edges.AddOneToMany("q", ["t", "r"]);

        // add subgraphs to control the layout of individual node groups
        // (check how the visualization changes when you remove these lines)
        graph.Subgraphs.AddWithNodes(DotRank.Same, ["b", "c", "d"]);
        graph.Subgraphs.AddWithNodes(DotRank.Same, ["e", "f", "g"]);
        graph.Subgraphs.AddWithNodes(DotRank.Same, ["h", "i", "j", "k"]);
        graph.Subgraphs.AddWithNodes(DotRank.Same, ["l", "m", "n"]);
        graph.Subgraphs.AddWithNodes(DotRank.Same, ["q", "r"]);
        graph.Subgraphs.AddWithNodes(DotRank.Max, ["o", "s", "p"]);

        return graph;
    }
}