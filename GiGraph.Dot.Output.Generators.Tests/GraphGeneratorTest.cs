using System.Drawing;
using System.Text;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Output.Generators.Tests
{
    public class AttributeGeneratorsTest
    {
        private readonly DotGenerationOptions _generationOptions = new DotGenerationOptions();
        private readonly DotSyntaxRules _syntaxRules = new DotSyntaxRules();

        private static DotGraph GetCompleteGraph(bool directed)
        {
            var graph = new DotGraph("graph1", directed);

            graph.Attributes.Compound = true;
            graph.Attributes.FillColor = Color.Brown;
            graph.Attributes.Comment = "graph_comment";

            graph.NodeDefaults.Color = Color.Red;
            graph.NodeDefaults.Label = "node_label";

            graph.EdgeDefaults.Color = Color.Blue;
            graph.EdgeDefaults.Label = "edge_label";


            graph.Nodes.Add("node3", attrs =>
            {
                attrs.Shape = DotNodeShape.Assembly;
                attrs.Style = DotStyle.Bold;
            });

            graph.Nodes.Add(attrs =>
            {
                attrs.Shape = DotNodeShape.Box;
                attrs.Style = DotStyle.Bold | DotStyle.Dashed;
            }, "node1", "node2");


            graph.Edges.Add("node6", "node7", edge =>
            {
                edge.Tail.Port.Name = "port6";
                edge.Tail.Port.CompassPoint = DotCompassPoint.East;

                edge.Attributes.Color = Color.Gold;
                edge.Attributes.Style = DotStyle.Dotted;
            });

            graph.Edges.AddSequence(edge =>
            {
                edge.Attributes.Constraint = true;
                edge.Attributes.Style = DotStyle.Solid;
            }, "node4", DotSubgraph.FromNodes("snode1", "snode2"), "node5");

            graph.Edges.AddSequence(edge =>
            {
                edge.Attributes.Color = Color.Beige;
                edge.Attributes.Style = DotStyle.Invisible;
            }, "node1", "node2", "node3");

            graph.Subgraphs.Add().Id = "Subgraph2";
            graph.Subgraphs.Add().Id = "Subgraph1";

            graph.Clusters.Add("Cluster2");
            graph.Clusters.Add("Cluster1");

            return graph;
        }

        private static DotGraph GetSectionedGraph(bool directed)
        {
            var graph = new DotGraph("graph1", directed);

            graph.Annotation = "graph comment";

            graph.Attributes.Compound = true;
            graph.NodeDefaults.Label = "node label";
            graph.EdgeDefaults.Label = "edge label";

            graph.Nodes.Add("node1");
            graph.Edges.Add("node1", "node2");

            graph.Subgraphs.Add(sg =>
            {
                sg.Annotation = "subgraph comment";
                sg.Attributes.Rank = DotRank.Min;

                sg.Subsections.Add(ss =>
                {
                    ss.Annotation = "subgraph subsection comment";
                    ss.Attributes.Rank = DotRank.Max;
                });
            });

            graph.Clusters.Add("cluster1", c =>
            {
                c.Annotation = "cluster comment";
                c.Attributes.Color = Color.Blue;

                c.Subsections.Add(ss =>
                {
                    ss.Annotation = "cluster subsection comment";
                    ss.Attributes.Color = Color.Magenta;
                });
            });

            return graph;
        }

        [Fact]
        public void graph_with_all_possible_elements_is_rendered_according_to_default_rules_and_options()
        {
            var graph = GetCompleteGraph(directed: true);

            var sb = new StringBuilder();
            sb.AppendLine("digraph graph1");
            sb.AppendLine("{");

            sb.AppendLine("    comment = graph_comment");
            sb.AppendLine("    compound = true");
            sb.AppendLine("    fillcolor = brown");
            sb.AppendLine();

            sb.AppendLine("    node [ color = red, label = node_label ]");
            sb.AppendLine("    edge [ color = blue, label = edge_label ]");
            sb.AppendLine();

            sb.AppendLine("    subgraph Subgraph2");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    subgraph Subgraph1");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    subgraph \"cluster Cluster2\"");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    subgraph \"cluster Cluster1\"");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    node3 [ shape = assembly, style = bold ]");
            sb.AppendLine("    node1, node2 [ shape = box, style = \"dashed, bold\" ]");
            sb.AppendLine();

            sb.AppendLine("    node6:port6:e -> node7 [ color = gold, style = dotted ]");
            sb.AppendLine("    node4 -> { snode1 snode2 } -> node5 [ constraint = true, style = solid ]");
            sb.AppendLine("    node1 -> node2 -> node3 [ color = beige, style = invis ]");

            sb.Append("}");

            Assert.Equal(sb.ToString(), graph.Build(generationOptions: _generationOptions, syntaxRules: _syntaxRules));
        }

        [Fact]
        public void graph_with_all_possible_elements_is_rendered_ordered_according_to_rules_and_options()
        {
            var graph = GetCompleteGraph(directed: true);

            var sb = new StringBuilder();
            sb.AppendLine("digraph graph1");
            sb.AppendLine("{");

            sb.AppendLine("    comment = graph_comment");
            sb.AppendLine("    compound = true");
            sb.AppendLine("    fillcolor = brown");
            sb.AppendLine();

            sb.AppendLine("    node [ color = red, label = node_label ]");
            sb.AppendLine("    edge [ color = blue, label = edge_label ]");
            sb.AppendLine();

            sb.AppendLine("    subgraph Subgraph1");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    subgraph Subgraph2");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    subgraph \"cluster Cluster1\"");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    subgraph \"cluster Cluster2\"");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    node1, node2 [ shape = box, style = \"bold, dashed\" ]");
            sb.AppendLine("    node3 [ shape = assembly, style = bold ]");
            sb.AppendLine();

            sb.AppendLine("    node1 -> node2 -> node3 [ color = beige, style = invis ]");
            sb.AppendLine("    node4 -> { snode1 snode2 } -> node5 [ constraint = true, style = solid ]");
            sb.AppendLine("    node6:port6:e -> node7 [ color = gold, style = dotted ]");

            sb.Append("}");

            var options = DotGenerationOptions.Custom(o => o.OrderElements = true);
            Assert.Equal(sb.ToString(), graph.Build(generationOptions: options, syntaxRules: _syntaxRules));
        }

        [Fact]
        public void graph_with_all_possible_elements_is_rendered_with_quoted_ids_based_on_options()
        {
            var graph = GetCompleteGraph(directed: true);

            var sb = new StringBuilder();
            sb.AppendLine("digraph \"graph1\"");
            sb.AppendLine("{");

            sb.AppendLine("    comment = graph_comment");
            sb.AppendLine("    compound = true");
            sb.AppendLine("    fillcolor = brown");
            sb.AppendLine();

            sb.AppendLine("    node [ color = red, label = node_label ]");
            sb.AppendLine("    edge [ color = blue, label = edge_label ]");
            sb.AppendLine();

            sb.AppendLine("    subgraph \"Subgraph2\"");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    subgraph \"Subgraph1\"");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    subgraph \"cluster Cluster2\"");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    subgraph \"cluster Cluster1\"");
            sb.AppendLine("    {");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    \"node3\" [ shape = assembly, style = bold ]");
            sb.AppendLine("    \"node1\", \"node2\" [ shape = box, style = \"dashed, bold\" ]");
            sb.AppendLine();

            sb.AppendLine("    \"node6\":\"port6\":\"e\" -> \"node7\" [ color = gold, style = dotted ]");
            sb.AppendLine("    \"node4\" -> { \"snode1\" \"snode2\" } -> \"node5\" [ constraint = true, style = solid ]");
            sb.AppendLine("    \"node1\" -> \"node2\" -> \"node3\" [ color = beige, style = invis ]");

            sb.Append("}");

            var options = DotGenerationOptions.Custom(o => o.PreferQuotedIdentifiers = true);
            Assert.Equal(sb.ToString(), graph.Build(generationOptions: options, syntaxRules: _syntaxRules));
        }

        [Fact]
        public void renders_empty_graph_in_expected_format()
        {
            var graph = new DotGraph();

            var sb = new StringBuilder();
            sb.AppendLine("digraph");
            sb.AppendLine("{");
            sb.Append("}");

            Assert.Equal(
                sb.ToString(),
                graph.Build(generationOptions: _generationOptions, syntaxRules: _syntaxRules));
        }

        [Fact]
        public void renders_empty_graph_in_expected_single_line_format()
        {
            var graph = new DotGraph();

            var sb = new StringBuilder();
            sb.Append("digraph { }");

            var options = new DotFormattingOptions
            {
                SingleLine = true
            };

            Assert.Equal(sb.ToString(), graph.Build(options, _generationOptions, _syntaxRules));
        }

        [Fact]
        public void renders_graph_subgraph_and_cluster_subsections()
        {
            var graph = GetSectionedGraph(directed: true);

            var sb = new StringBuilder();
            sb.AppendLine("// graph comment");
            sb.AppendLine("digraph graph1");
            sb.AppendLine("{");

            sb.AppendLine("    compound = true");
            sb.AppendLine();

            sb.AppendLine("    node [ label = \"node label\" ]");
            sb.AppendLine("    edge [ label = \"edge label\" ]");
            sb.AppendLine();

            sb.AppendLine("    // subgraph comment");
            sb.AppendLine("    {");
            sb.AppendLine("        rank = min");
            sb.AppendLine();
            sb.AppendLine("        /* subgraph subsection comment */");
            sb.AppendLine();
            sb.AppendLine("        rank = max");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    // cluster comment");
            sb.AppendLine("    subgraph \"cluster cluster1\"");
            sb.AppendLine("    {");
            sb.AppendLine("        color = blue");
            sb.AppendLine();
            sb.AppendLine("        /* cluster subsection comment */");
            sb.AppendLine();
            sb.AppendLine("        color = magenta");
            sb.AppendLine("    }");
            sb.AppendLine();

            sb.AppendLine("    node1");
            sb.AppendLine();

            sb.AppendLine("    node1 -> node2");

            sb.Append("}");

            Assert.Equal(sb.ToString(), graph.Build());
        }
    }
}