using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Tests.CommentedAttributes
{
    public class DotCommentedAttributePaddingTest
    {
        [Fact]
        public void graph_attributes_have_no_padding_when_not_commented()
        {
            var graph = new DotGraph();
            graph.Font.Set("arial", 10);

            var dot = graph.Build();
            Snapshot.Match(dot, "commented_graph_attribute_without_padding.gv");
        }

        [Fact]
        public void graph_commented_attribute_has_padding_before_and_after_when_between_two_other_attributes()
        {
            var graph = new DotGraph();
            graph.Font.Set("arial", 10, Color.Red);
            graph.Font.Get(x => x.Name).Annotation = "comment";

            var dot = graph.Build();
            Snapshot.Match(dot, "commented_graph_attribute_with_padding_before_and_after.gv");
        }

        [Fact]
        public void graph_commented_attribute_has_padding_after_only_when_first()
        {
            var graph = new DotGraph();
            graph.Font.Set("arial", 10, Color.Red);
            graph.Font.Get(x => x.Color).Annotation = "comment";

            var dot = graph.Build();
            Snapshot.Match(dot, "commented_graph_attribute_with_padding_after.gv");
        }

        [Fact]
        public void graph_commented_attribute_has_padding_before_only_when_last()
        {
            var graph = new DotGraph();
            graph.Font.Set("arial", 10, Color.Red);
            graph.Font.Get(x => x.Size).Annotation = "comment";

            var dot = graph.Build();
            Snapshot.Match(dot, "commented_graph_attribute_with_padding_before.gv");
        }
    }
}