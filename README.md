# GiGraph

<p align="center">
  <img src="/Assets/social-preview.png">
</p>

------

A simple solution for generating graphs in the <a href="https://en.wikipedia.org/wiki/DOT_(graph_description_language)" target="_blank">DOT language</a>. The output generated by this library is a textual script that can be visualized and/or converted to an image with the help of external tools. A handy one is a plugin for <a href="https://code.visualstudio.com" target="_blank">Visual Studio Code</a>, named <a href="https://marketplace.visualstudio.com/items?itemName=EFanZh.graphviz-preview" target="_blank">Graphviz Preview</a> (you will need to install <a href="https://www.graphviz.org/download" target="_blank">Graphviz</a> as well). There are also online tools like <a href="http://www.webgraphviz.com" target="_blank">WebGraphviz</a>, where you can paste the generated script to view your graph.



###### Built with [.NET Standard 2.0](https://docs.microsoft.com/en-US/dotnet/standard/net-standard#net-implementation-support) (compatible with *.NET Core 2.0* and above, *.NET Framework 4.6.1* and above).

###### Available on NuGet: [![#](https://img.shields.io/nuget/v/GiGraph.Dot)](https://www.nuget.org/packages/GiGraph.Dot/)



# Intro

### Building blocks

There are three basic types that are the building blocks of a graph:

- **DotGraph** - the *root* graph itself,
- **DotNode** - a node of the graph,
- **DotEdge** - an edge that connects two nodes (or more, when subgraphs are used).

In some cases **subgraphs** come in handy, and there are two types of them:

- **DotSubgraph** - groups nodes together *logically* and allows you to control their layout against other nodes in the graph,
- **DotCluster** - a special type of subgraph that groups nodes together *visually* by placing them inside a rectangle.



### Attributes

Each individual element described above may have **attributes**, like background color, style, node shape, arrow head shape and so on. You don't have to specify them, however, and if you don't, the visualizing tool will use its own style defaults for rendering them.

```c#
myElement.Attributes.Label = "This is a label";
```



### Default attributes

The root graph and the subgraphs allow you to set **global defaults** for all nodes and/or edges within them, so that you don't have to set them individually for every element they contain.

```c#
myGraph.NodeDefaults.Color = Color.Yellow;
```

```c#
myGraph.EdgeDefaults.Color = Color.Red;
```



## Graph

Graphs contains nodes (vertices) and edges, and may optionally have some attributes set, that determine their style, layout etc.



There are two types of graphs:

- **directed** (the edges are presented as arrows),
- **undirected** (the edges are presented as lines).

```c#
myGraph.IsDirected = true;
```



When you want to forbid creating multi-edges, use the *IsStrict* property. In strict graphs there can be at most one edge with a given tail node and head node in the directed case.

```c#
myGraph.IsStrict = true;
```





## Node

Nodes are distinguished by their **identifiers**. The identifiers are used by edges to refer to a head and a tail node that they connect. If you don't specify a **label** attribute for a node, the identifier will also be used as a label when visualized.

```c#
myGraph.Nodes.Add("MyNodeId1", node =>
{
    node.Attributes.Label = "Hello World!";
    node.Attributes.Shape = DotShape.Hexagon;
});
```



*Note that **a node does not necessarily have to be added to the nodes collection** of the graph or subgraph when it is referenced by an edge in the collection of edges (as long as there is no need to specify any attributes for the node, for example).*



## Edge

Edges **connect two nodes** by referring to their identifiers. Edges may also **connect two subgraphs** or **a single node with a subgraph** (or the other way round). In both these cases such connection is interpreted as a many-to-many or a one-to-many connection respectively, between the nodes within the subgraphs or between the single node, and the nodes in the subgraph.

```c#
myGraph.Edges.Add("MyNodeId1", "MyNodeId2");
```



# Generating a graph

To generate a graph script, just call the ***Build()*** extension method on a graph instance as follows:

```c#
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions; // Build(), SaveToFile()
using System;

namespace GiGraph.Examples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var graph = new DotGraph(isDirected: true);
            graph.Edges.Add("Hello", "World!");

            // write it to console as string
            Console.WriteLine( graph.Build() );
            
            // or save it to a file (.gv and .dot are the default extensions)
            graph.SaveToFile( @"C:\MyGraphs\hello-world.gv" );
            
            Console.Read();
        }
    }
}
```



Here's what you get on the console and in the file:

```dot
digraph
{
    Hello -> "World!"
}
```



And when visualized, it looks like this:

<p align="center">
  <img src="/Assets/Examples/hello-world.svg">
</p>


# Examples

#### Graph defaults example

```c#
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions; // Build(), SaveToFile()
using System;
using System.Drawing;

namespace GiGraph.Examples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var graph = new DotGraph(isDirected: true);

            // set left to right layout direction of the graph
            graph.Attributes.LayoutDirection = DotRankDirection.LeftToRight;


            // set the defaults for all nodes
            graph.NodeDefaults.Shape = DotShape.Rectangle;
            graph.NodeDefaults.Style = DotStyle.Filled | DotStyle.Bold;
            graph.NodeDefaults.FillColor = Color.DarkOrange;

            // set the defaults for all edges
            graph.EdgeDefaults.ArrowHead = DotArrowType.Vee;


            // -- add some nodes --

            graph.Nodes.Add("Entry").Attributes.Shape = DotShape.Circle;

            graph.Nodes.Add("Decision", attrs =>
            {
                attrs.Shape = DotShape.Diamond;
                attrs.Label = $"Decision{Environment.NewLine}point";
            });

            graph.Nodes.Add("Option1", attrs =>
            {
                attrs.Color = Color.Green;
                attrs.Label = "Positive path";
            });

            graph.Nodes.Add("Option2", attrs =>
            {
                attrs.Color = Color.DarkRed;
                attrs.Label = "Negative path";
            });

            graph.Nodes.Add("Exit").Attributes.Shape = DotShape.DoubleCircle;


            // join the nodes with edges
            graph.Edges.Add("Entry", "Decision");

            graph.Edges.Add("Decision", "Option1", attrs =>
            {
                attrs.Color = Color.Green;
                attrs.Label = "yes";
            });

            graph.Edges.Add("Decision", "Option2", attrs =>
            {
                attrs.Color = Color.DarkRed;
                attrs.Label = "no";
            });

            graph.Edges.AddManyToOne("Exit", "Option1", "Option2");


            // build a graph as string
            var graphString = graph.Build();
            Console.WriteLine(graphString);

            // or save it to a file (.gv and .dot are the default extensions)
            graph.SaveToFile(@"C:\MyGraphs\hello-world.gv");

            Console.ReadLine();
        }
    }
}
```

```dot
digraph
{
    rankdir = LR

    node [ fillcolor = "#ff8c00ff", shape = rectangle, style = "bold, filled" ]
    edge [ arrowhead = vee ]

    Decision [ label = "Decision\npoint", shape = diamond ]
    Entry [ shape = circle ]
    Exit [ shape = doublecircle ]
    Option1 [ color = "#008000ff", label = "Positive path" ]
    Option2 [ color = "#8b0000ff", label = "Negative path" ]

    Decision -> Option1 [ color = "#008000ff", label = yes ]
    Decision -> Option2 [ color = "#8b0000ff", label = no ]
    Entry -> Decision
    Option1 -> Exit
    Option2 -> Exit
}
```

<p align="center">
  <img src="/Assets/Examples/graph-defaults.svg">
</p>
