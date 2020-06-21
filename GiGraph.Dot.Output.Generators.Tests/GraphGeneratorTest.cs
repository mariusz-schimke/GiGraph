using System.Drawing;
using System.Text;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Xunit;

namespace GiGraph.Dot.Tests
{
    public class AttributeGeneratorsTest
    {
        private DotGenerationOptions _generationOptions = new DotGenerationOptions();
        private DotSyntaxRules _syntaxRules = new DotSyntaxRules();

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

            var options = new DotFormattingOptions()
            {
                SingleLineOutput = true
            };

            Assert.Equal(sb.ToString(), graph.Build(options, _generationOptions, _syntaxRules));
        }

        [Fact]
        public void graph_with_all_possible_elements_is_rendered_according_to_rules_and_options()
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

            sb.AppendLine("    node1 [ shape = assembly, style = bold ]");
            sb.AppendLine("    node2, node3 [ shape = box, style = \"dashed, bold\" ]");
            sb.AppendLine();

            sb.AppendLine("    node1 -> node2 [ color = gold, style = dotted ]");
            sb.AppendLine("    node1 -> node2 -> node3 [ color = beige, style = invis ]");
            sb.AppendLine("    node1 -> { snode1 snode2 } -> node2 [ constraint = true, style = solid ]");

            sb.Append("}");

            Assert.Equal(
                sb.ToString(),
                graph.Build(generationOptions: _generationOptions, syntaxRules: _syntaxRules));
        }

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

            graph.Nodes.Add("node1", attrs =>
            {
                attrs.Shape = DotShape.Assembly;
                attrs.Style = DotStyle.Bold;
            });

            graph.Nodes.Add(attrs =>
            {
                attrs.Shape = DotShape.Box;
                attrs.Style = DotStyle.Bold | DotStyle.Dashed;
            }, "node2", "node3");

            graph.Edges.Add("node1", "node2", edge =>
            {
                edge.Attributes.Color = Color.Gold;
                edge.Attributes.Style = DotStyle.Dotted;
            });

            graph.Edges.AddSequence(edge =>
            {
                edge.Attributes.Color = Color.Beige;
                edge.Attributes.Style = DotStyle.Invisible;
            }, "node1", "node2", "node3");
            
            graph.Edges.AddSequence(edge =>
            {
                edge.Attributes.Constraint = true;
                edge.Attributes.Style = DotStyle.Solid;
            }, "node1", DotSubgraph.FromNodes("snode1", "snode2"), "node2");

            return graph;
        }
    }
}