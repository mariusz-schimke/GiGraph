using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Tests.EntityPadding;

public class DotGraphWithCommentedAttributesTest
{
    [Fact]
    public void graph_attributes_have_no_padding_when_not_commented()
    {
        var graph = new DotGraph();
        graph.Font.Set("arial", 10);

        Snapshot.Match(graph.ToDot(), "commented_graph_attribute_without_padding.gv");

        var formatting = new DotFormattingOptions { SingleLine = true };
        Snapshot.Match(graph.ToDot(formatting), "commented_graph_attribute_without_padding_single_line.gv");
    }

    [Fact]
    public void commented_graph_attribute_has_top_and_bottom_padding_when_between_two_other_attributes()
    {
        var graph = new DotGraph();
        graph.Font.Set("arial", 10, Color.Red);
        graph.Font.Attributes.Get(x => x.Name)!.Annotation = "comment";

        Snapshot.Match(graph.ToDot(), "commented_graph_attribute_with_top_and_bottom_padding.gv");

        var formatting = new DotFormattingOptions { SingleLine = true };
        Snapshot.Match(graph.ToDot(formatting), "commented_graph_attribute_with_top_and_bottom_padding_single_line.gv");
    }

    [Fact]
    public void commented_graph_attribute_has_bottom_padding_only_when_first()
    {
        var graph = new DotGraph();
        graph.Font.Set("arial", 10, Color.Red);
        graph.Font.Attributes.Get(x => x.Color)!.Annotation = "comment";

        Snapshot.Match(graph.ToDot(), "commented_graph_attribute_with_bottom_padding.gv");

        var formatting = new DotFormattingOptions { SingleLine = true };
        Snapshot.Match(graph.ToDot(formatting), "commented_graph_attribute_with_bottom_padding_single_line.gv");
    }

    [Fact]
    public void commented_graph_attribute_has_top_padding_only_when_last()
    {
        var graph = new DotGraph();
        graph.Font.Set("arial", 10, Color.Red);
        graph.Font.Attributes.Get(x => x.Size)!.Annotation = "comment";

        Snapshot.Match(graph.ToDot(), "commented_graph_attribute_with_top_padding.gv");

        var formatting = new DotFormattingOptions { SingleLine = true };
        Snapshot.Match(graph.ToDot(formatting), "commented_graph_attribute_with_top_padding_single_line.gv");
    }
}