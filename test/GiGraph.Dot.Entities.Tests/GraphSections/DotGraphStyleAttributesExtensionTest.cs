using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Clusters.Style;
using GiGraph.Dot.Types.Colors;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.GraphSections;

public class DotGraphStyleAttributesExtensionTest
{
    [Fact]
    private void sets_plain_background_color()
    {
        var graph = new DotGraph();

        graph.Style.SetBackground(Color.Gold);
        graph.Subsections.Add().Style.SetBackground(Color.Gold);

        Snapshot.Match(graph.ToDot(), "plain_graph_background");
    }

    [Fact]
    private void sets_gradient_background_color()
    {
        var graph = new DotGraph();

        // this should be removed by the extension method (radial style by none)
        graph.Clusters.Style.FillStyle = DotClusterFillStyle.Radial;

        graph.Style.SetGradientBackground(new DotGradientColor(Color.Gold, Color.DarkMagenta));

        // an overload (with the same result as the call above)
        graph.Subsections.Add().Style.SetGradientBackground(Color.Gold, Color.DarkMagenta);
        graph.Subsections.Add().Style.SetGradientBackground(Color.Gold, Color.DarkMagenta, 10);

        graph.Subsections
            .Add(s =>
                {
                    // this setting should not be removed by the extension method called below (this is a non-radial style)
                    s.Clusters.Style.FillStyle = DotClusterFillStyle.Striped;
                }
            )
            .Style
            .SetGradientBackground(new DotGradientColor(Color.Gold, Color.DarkMagenta), 20);

        Snapshot.Match(graph.ToDot(), "gradient_graph_background");
    }

    [Fact]
    private void sets_radial_gradient_background_color()
    {
        var graph = new DotGraph();

        // this setting should be overwritten by the extension method (a non-radial style by the radial style)
        graph.Clusters.Style.FillStyle = DotClusterFillStyle.Striped;
        graph.Style.SetRadialGradientBackground(new DotGradientColor(Color.Gold, Color.DarkMagenta));

        // an overload (with the same result as the call above)
        graph.Subsections.Add().Style.SetRadialGradientBackground(Color.Gold, Color.DarkMagenta);
        graph.Subsections.Add().Style.SetRadialGradientBackground(Color.Gold, Color.DarkMagenta, 10);

        graph.Subsections
            .Add()
            .Style
            .SetRadialGradientBackground(new DotGradientColor(Color.Gold, Color.DarkMagenta), 20);

        Snapshot.Match(graph.ToDot(), "radial_gradient_graph_background");
    }
}