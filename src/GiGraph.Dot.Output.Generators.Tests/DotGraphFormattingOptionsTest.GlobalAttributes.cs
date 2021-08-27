using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Generators.Tests
{
    public partial class DotGraphFormattingOptionsTest
    {
        [Fact]
        public void renders_graph_with_multiline_global_graph_attribute_list()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var formatting = new DotFormattingOptions
            {
                GlobalAttributes = { SingleLineGraphAttributeList = false }
            };

            var syntax = new DotSyntaxOptions
            {
                Graph = { AttributesAsStatements = false }
            };

            var dot = graph.Build(formatting, syntax);
            Snapshot.Match(dot, "graph_with_multiline_global_graph_attribute_list.gv");
        }

        [Fact]
        public void renders_graph_with_single_line_global_graph_attribute_list()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var formatting = new DotFormattingOptions
            {
                GlobalAttributes = { SingleLineGraphAttributeList = true }
            };

            var syntax = new DotSyntaxOptions
            {
                Graph = { AttributesAsStatements = false }
            };

            var dot = graph.Build(formatting, syntax);
            Snapshot.Match(dot, "graph_with_single_line_global_graph_attribute_list.gv");
        }

        [Fact]
        public void renders_graph_with_multiline_global_node_attribute_list()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var options = new DotFormattingOptions
            {
                GlobalAttributes = { SingleLineNodeAttributeList = false }
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_multiline_global_node_attribute_list.gv");
        }

        [Fact]
        public void renders_graph_with_multiline_node_attribute_list()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var options = new DotFormattingOptions
            {
                Nodes = { SingleLineAttributeLists = false }
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_multiline_node_attribute_list.gv");
        }

        [Fact]
        public void renders_graph_with_multiline_global_edge_attribute_list()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var options = new DotFormattingOptions
            {
                GlobalAttributes = { SingleLineEdgeAttributeList = false }
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_multiline_global_edge_attribute_list.gv");
        }

        [Fact]
        public void renders_graph_with_multiline_edge_attribute_list()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var options = new DotFormattingOptions
            {
                Edges = { SingleLineAttributeLists = false }
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_multiline_edge_attribute_list.gv");
        }

        [Fact]
        public void renders_graph_with_multiline_global_attribute_lists()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var formatting = new DotFormattingOptions
            {
                GlobalAttributes = { SingleLineAttributeLists = false }
            };

            var syntax = new DotSyntaxOptions
            {
                Graph = { AttributesAsStatements = false }
            };

            var dot = graph.Build(formatting, syntax);
            Snapshot.Match(dot, "graph_with_multiline_global_attribute_lists.gv");
        }
    }
}