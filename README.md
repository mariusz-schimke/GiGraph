<p align="center">
  <img src="/Assets/social-preview.png">
</p>
------

**GiGraph DOT** is a solution for generating graphs in the <a href="https://en.wikipedia.org/wiki/DOT_(graph_description_language)" target="_blank">DOT language</a>. The output generated by this library is a textual script that can be visualized and/or converted to an image with the help of external tools. A handy one is a plugin for <a href="https://code.visualstudio.com" target="_blank">Visual Studio Code</a>, named <a href="https://marketplace.visualstudio.com/items?itemName=EFanZh.graphviz-preview" target="_blank">Graphviz Preview</a> (you will need to install <a href="https://www.graphviz.org/download" target="_blank">Graphviz</a> as well). There are also online tools like <a href="http://www.webgraphviz.com" target="_blank">WebGraphviz</a>, where you can paste the generated script to view your graph.

For the complete documentation of the DOT language, and the visualization capabilities of the available software, please go to <a href="https://graphviz.gitlab.io/documentation" target="_blank">Graphviz - Graph Vizualization Software</a>.

###### Built with [.NET Standard 2.0](https://docs.microsoft.com/en-US/dotnet/standard/net-standard#net-implementation-support) (compatible with *.NET Core 2.0* and above, *.NET Framework 4.6.1* and above).

###### Available on NuGet: [![#](https://img.shields.io/nuget/v/GiGraph.Dot)](https://www.nuget.org/packages/GiGraph.Dot/)



# Generating a graph

Create a new **DotGraph** instance, and add some edges to its *Edges* collection. To generate the output graph script, call the ***Build*** extension method on the graph instance as follows. Here's a simple *Hello World!* graph example with two nodes joined by an edge.

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
            // create a new graph (directed or undirected)
            var graph = new DotGraph(isDirected: true);
            
            // add an edge that joins the two specified nodes
            // (you don't have to add the nodes to the node collection of the graph
            // unless you need to specify some attributes for them)
            graph.Edges.Add("Hello", "World!");

            // write it to console as string
            Console.WriteLine(graph.Build());
            
            // or save it to a file (.gv and .dot are the default extensions)
            graph.SaveToFile(@"C:\MyGraphs\example.gv");
            
            Console.Read();
        }
    }
}
```



Here's what you get on the console, and in the file:

```dot
digraph
{
    Hello -> "World!"
}
```



Here's how the script is visualized:

<p align="center">
  <img src="/Assets/Examples/hello-world-directed.svg">
</p>




And here's an example of an undirected version of the same graph:

```c#
var graph = new DotGraph(isDirected: false);
```

```dot
graph
{
    Hello -- "World!"
}
```

<p align="center">
  <img src="/Assets/Examples/hello-world-undirected.svg">
</p>



## Customizing style

Graph nodes and edges can by styled globally, locally, and individually.

- To set their attributes globally, for the whole graph, use *NodeDefaults* and *EdgeDefaults* on the graph instance.
- To set them locally, for a group of nodes and edges, use a subgraph or a cluster, and set above properties on the subgraph/cluster instance (see the examples below to know the difference between a subgraph and a cluster).
- To set them individually for edges and nodes, use the *Attributes* property on the edge/node instances.

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

            // set left to right layout direction of the graph using graph attributes
            graph.Attributes.LayoutDirection = DotRankDirection.LeftToRight;


            // set the defaults for all nodes of the graph
            graph.NodeDefaults.Shape = DotShape.Rectangle;
            graph.NodeDefaults.Style = DotStyle.Filled | DotStyle.Bold;
            graph.NodeDefaults.FillColor = Color.DarkOrange;

            // set the defaults for all edges of the graph
            graph.EdgeDefaults.ArrowHead = DotArrowType.Vee;


            // -- add nodes --

            // the Add method returns the newly added node, so you can easily access its attributes
            graph.Nodes.Add("Entry").Attributes.Shape = DotShape.Circle;

            // or you can set the attributes using a delegate
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


            // -- add edges --

            // join the nodes by edges
            graph.Edges.Add("Entry", "Decision");

            // you can set custom attributes for the added edge the same way you can do it for nodes
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

            // this is a shorthand for adding two edges at once, that join multiple nodes with one node
            graph.Edges.AddManyToOne("Exit", "Option1", "Option2");


            // build a graph as string
            var graphString = graph.Build();
            Console.WriteLine(graphString);

            // or save it to a file (.gv and .dot are the default extensions)
            graph.SaveToFile(@"C:\MyGraphs\example.gv");

            Console.ReadLine();
        }
    }
}
```

```dot
digraph
{
    rankdir = LR

    node [ shape = rectangle, style = "bold, filled", fillcolor = "#ff8c00ff" ]
    edge [ arrowhead = vee ]

    Entry [ shape = circle ]
    Decision [ shape = diamond, label = "Decision\npoint" ]
    Option1 [ color = "#008000ff", label = "Positive path" ]
    Option2 [ color = "#8b0000ff", label = "Negative path" ]
    Exit [ shape = doublecircle ]

    Entry -> Decision
    Decision -> Option1 [ color = "#008000ff", label = yes ]
    Decision -> Option2 [ color = "#8b0000ff", label = no ]
    { Option1 Option2 } -> Exit
}
```

<p align="center">
  <img src="/Assets/Examples/graph-defaults.svg">
</p>





## Using clusters

A cluster is represented by the **DotCluster** class. It is a special type of subgraph whose appearance can be customized (as opposed to the subgraph represented by the **DotSubgraph** class). If supported, the layout engine used to render a cluster subgraph, will do the layout so that the nodes belonging to the cluster are drawn together, with the entire drawing of the cluster contained within a bounding rectangle. 

*Note that cluster subgraphs are not part of the DOT language, but solely a syntactic convention adhered to by certain of the layout engines.*

Cluster subgraphs do not support setting custom node layout the way normal subgraphs do, but they do support setting common style of nodes and edges within them.

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

            // set graph attributes
            graph.Attributes.Label = "Example Flow";
            graph.Attributes.LayoutDirection = DotRankDirection.LeftToRight;

            // set individual node styles
            graph.Nodes.Add("Start").Attributes.Shape = DotShape.Circle;
            graph.Nodes.Add("Decision").Attributes.Shape = DotShape.Diamond;
            graph.Nodes.Add("Exit").Attributes.Shape = DotShape.DoubleCircle;


            // --- define edges ---

            graph.Edges.Add("Start", "Decision");

            // (!) Note that CROSS-DIAGRAM EDGES SHOULD BE DEFINED IN THE COMMON PARENT LEVEL GRAPH/SUBGRAPH
            // (which is the root graph in this case)
            graph.Edges.Add("Decision", "Cluster 1 Start").Attributes.Label = "yes";
            graph.Edges.Add("Decision", "Cluster 2 Start").Attributes.Label = "no";

            graph.Edges.Add("Cluster 1 Exit", "Exit");
            graph.Edges.Add("Cluster 2 Exit", "Exit");


            // --- add clusters ---

            // (!) Note that even though clusters do not require an identifier, when you don't specify it
            // for multiple of them, or specify the same identifier for multiple clusters,
            // they will be treated as one cluster when visualized.

            graph.Clusters.Add(id: "Positive path", cluster =>
            {
                cluster.Attributes.BackgroundColor = Color.LightGreen;
                cluster.Attributes.Label = "Positive path";

                cluster.Edges.AddSequence("Cluster 1 Start", "Cluster 1 Node", "Cluster 1 Exit");
            });

            graph.Clusters.Add(id: "Negative path", cluster =>
            {
                cluster.Attributes.Label = "Negative path";
                cluster.Attributes.BackgroundColor = Color.LightPink;

                cluster.Edges.AddSequence("Cluster 2 Start", "Cluster 2 Node", "Cluster 2 Exit");
            });


            // build a graph as string
            var graphString = graph.Build();
            Console.WriteLine(graphString);

            // or save it to a file (.gv and .dot are the default extensions)
            graph.SaveToFile(@"C:\MyGraphs\example.gv");

            Console.ReadLine();
        }
    }
}
```

```dot
digraph
{
    label = "Example Flow"
    rankdir = LR

    Start [ shape = circle ]
    Decision [ shape = diamond ]
    Exit [ shape = doublecircle ]

    Start -> Decision
    Decision -> "Cluster 1 Start" [ label = yes ]
    Decision -> "Cluster 2 Start" [ label = no ]
    "Cluster 1 Exit" -> Exit
    "Cluster 2 Exit" -> Exit

    subgraph "cluster Positive path"
    {
        bgcolor = "#90ee90ff"
        label = "Positive path"

        "Cluster 1 Start" -> "Cluster 1 Node" -> "Cluster 1 Exit"
    }

    subgraph "cluster Negative path"
    {
        label = "Negative path"
        bgcolor = "#ffb6c1ff"

        "Cluster 2 Start" -> "Cluster 2 Node" -> "Cluster 2 Exit"
    }
}
```

<p align="center">
  <img src="/Assets/Examples/clusters.svg">
</p>



## Subgraphs example

Subgraph, represented by the **DotSubgraph** class, is a collection of nodes constrained with a rank attribute, that determines their layout.  Use a subgraph when you want to have more granular control on the layout and style of specific nodes.

Subgraph does not have any border or fill, as opposed to cluster subgraph, represented by the **DotCluster** class, which supports them.

Subgraph supports setting common style of nodes and edges within it, as well as the layout of nodes (by the **rank attribute**). Subgraph can also be used as a head or tail of an edge, in which case all nodes within it are connected to the other side of the edge.



Consider the following graph in which all nodes are laid out automatically:

<p align="center">
  <img src="/Assets/Examples/complex-graph.svg">
</p>




By using **subgraphs with a rank attribute** specified, you can change the way individual node groups are visualized:

<p align="center">
  <img src="/Assets/Examples/complex-graph-with-subgraphs.svg">
</p>




The latter example is generated by the following code. When you remove the lines of code where subgraphs are added, you will get the layout from the former example.

```c#
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions; // Build(), SaveToFile()
using System;

namespace GiGraph.Examples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var graph = new DotGraph(isDirected: false);

            graph.Attributes.LayoutDirection = DotRankDirection.LeftToRight;

            graph.Edges.Add("e", "h");
            graph.Edges.Add("g", "k");
            graph.Edges.Add("r", "t");
            graph.Edges.Add("s", "z");
            graph.Edges.Add("t", "z");

            graph.Edges.AddOneToMany("a", "b", "c", "d");
            graph.Edges.AddOneToMany("b", "c", "e");
            graph.Edges.AddOneToMany("c", "e", "f");
            graph.Edges.AddOneToMany("d", "f", "g");
            graph.Edges.AddOneToMany("f", "h", "i", "j", "g");
            graph.Edges.AddOneToMany("h", "o", "l");
            graph.Edges.AddOneToMany("i", "l", "m", "j");
            graph.Edges.AddOneToMany("j", "m", "n", "k");
            graph.Edges.AddOneToMany("k", "n", "r");
            graph.Edges.AddOneToMany("l", "o", "m");
            graph.Edges.AddOneToMany("m", "o", "p", "n");
            graph.Edges.AddOneToMany("n", "q", "r");
            graph.Edges.AddOneToMany("o", "s", "p");
            graph.Edges.AddOneToMany("p", "s", "t", "q");
            graph.Edges.AddOneToMany("q", "t", "r");


            // add subgraphs to control the layout of some node groups
            graph.Subgraphs.AddSubgraph(DotRank.Same).Nodes.Add("b", "c", "d");
            graph.Subgraphs.AddSubgraph(DotRank.Same).Nodes.Add("e", "f", "g");
            graph.Subgraphs.AddSubgraph(DotRank.Same).Nodes.Add("h", "i", "j", "k");
            graph.Subgraphs.AddSubgraph(DotRank.Same).Nodes.Add("l", "m", "n");
            graph.Subgraphs.AddSubgraph(DotRank.Same).Nodes.Add("o", "p", "q", "r");
            graph.Subgraphs.AddSubgraph(DotRank.Same).Nodes.Add("s", "t");


            // build a graph as string
            var graphString = graph.Build();
            Console.WriteLine(graphString);

            // or save it to a file (.gv and .dot are the default extensions)
            graph.SaveToFile( @"C:\MyGraphs\subgraphs-example.gv" );

            Console.ReadLine();
        }
    }
}
```



# Building blocks

There are three basic types that are the building blocks of a graph:

- **DotGraph** - the *root* graph itself,
- **DotNode** - a node of the graph,
- **DotEdge** - an edge that connects two nodes (or more, when subgraphs are used).

In some cases **subgraphs** come in handy, and there are two types of them:

- **DotSubgraph** - groups nodes together *logically* and allows you to control their layout against other nodes in the graph,
- **DotCluster** - a special type of subgraph that groups nodes together *visually* by placing them inside a rectangle.



### Graph

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



### Node

Nodes are distinguished by their **identifiers**. The identifiers are used by edges to refer to a head and a tail node that they connect. If you don't specify a **label** attribute for a node, the identifier will also be used as a label when visualized.

```c#
myGraph.Nodes.Add("MyNodeId1", node =>
{
    node.Attributes.Label = "Hello World!";
    node.Attributes.Shape = DotShape.Hexagon;
});
```



*Note that **a node does not necessarily have to be added to the nodes collection** of the graph or subgraph when it is referenced by an edge in the collection of edges (as long as there is no need to specify any attributes for the node, for example).*



### Edge

Edges **connect two nodes** by referring to their identifiers. Edges may also **connect two subgraphs** or **a single node with a subgraph** (or the other way round). In both these cases such connection is interpreted as a many-to-many or a one-to-many connection respectively, between the nodes within the subgraphs or between the single node, and the nodes in the subgraph.

```c#
myGraph.Edges.Add("MyNodeId1", "MyNodeId2");
```



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



# Custom output formatting

The DOT generation engine supports setting some custom preferences for generating the output. These include syntax preferences, and formatting preferences. 

### Formatting preferences

Formatting preferences can be modified using the **DotFormattingOptions** class. If you want to change the indentation level, the indentation character, set a custom line break character/sequence, or generate the output as a single line, pass a customized formatting options instance to the **Build** or **SaveToFile** method on a graph instance.

```c#
...
using GiGraph.Dot.Writers.Options;

...

var formatting = new DotFormattingOptions()
{
    SingleLineOutput = true
};

Console.WriteLine( graph.Build(formatting) );

graph.SaveToFile( @"C:\MyGraphs\hello-world.gv", formatting );
```

The hello world example from the earlier chapter of the text would render like this:

```dot
digraph { Hello -> "World!" }
```



### Syntax preferences

Syntax preferences can be modified using the **DotGenerationOptions** class. You can for example force statement delimiters (*;*) at the end of lines or require identifiers to be quoted, even if it is not required.

```c#
...
using GiGraph.Dot.Generators.Options;

...

var options = DotGenerationOptions.Custom(o =>
{
    o.PreferQuotedIdentifiers = true;
    o.PreferStatementDelimiter = true;

    o.Attributes.PreferQuotedValue = true;
});

Console.WriteLine( graph.Build(generationOptions: options) );

graph.SaveToFile( @"C:\MyGraphs\example.gv", generationOptions: options );
```

An example graph output based on the code above: 

```dot
digraph
{
    "Node1" [ shape = "box" ];

    "Hello" -> "World!";
}
```

The same graph output with the default preferences:

```dot
digraph
{
    Node1 [ shape = box ]

    Hello -> "World!"
}
```



#### Sorting elements of the DOT script

Using mentioned **DotFormattingOptions**, and its *OrderElements* property, you can also enable sorting elements of the output script alphabetically. This comes in handy when the graph is built based on some input elements the order of which changes each time you generate the graph. Sometimes you need to compare the output to its other versions, and in such cases you want to see only actual differences, not the lines that only moved from one place of the file to another, without actually changing. When you enable this setting, all attribute lists, the lists of edges, nodes, and subgraphs/clusters, will always be ordered alphabetically. This way you should get more consistent outputs on every build.

Have in mind, however, that even though this feature does not affect the structure of the graph, it may affect the locations of some elements when the graph is visualized, but in the described scenario this will probably be of no importance.