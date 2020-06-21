using System.Drawing;
using System.Text;
using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Generators.GraphGenerators;
using GiGraph.Dot.Output.Generators.Providers;
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
        public void a()
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

            return graph;
        }
    }
}