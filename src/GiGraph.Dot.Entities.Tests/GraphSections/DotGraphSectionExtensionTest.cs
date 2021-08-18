using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.GraphSections
{
    public class DotGraphSectionExtensionTest
    {
        [Fact]
        private void sets_plain_background_color()
        {
            var graph = new DotGraph();

            graph.SetBackground(Color.Gold);
            graph.Subsections.Add().SetBackground(Color.Gold);

            Snapshot.Match(graph.Build(), "plain_graph_background");
        }

        [Fact]
        private void sets_gradient_background_color()
        {
            var graph = new DotGraph();

            // this should be removed by the extension method (radial style by none)
            graph.Clusters.Style.FillStyle = DotClusterFillStyle.Radial;

            graph.SetGradientBackground(new DotGradientColor(Color.Gold, Color.DarkMagenta));
            graph.Subsections.Add(s =>
                {
                    // this should not be removed by the extension method (non-radial style)
                    s.Clusters.Style.FillStyle = DotClusterFillStyle.Striped;
                })
               .SetGradientBackground(new DotGradientColor(Color.Gold, Color.DarkMagenta));

            Snapshot.Match(graph.Build(), "gradient_graph_background");
        }

        [Fact]
        private void sets_radial_gradient_background_color()
        {
            var graph = new DotGraph();

            // this should be overwritten by the extension method (non-radial style by radial)
            graph.Clusters.Style.FillStyle = DotClusterFillStyle.Striped;

            graph.SetRadialGradientBackground(new DotGradientColor(Color.Gold, Color.DarkMagenta));
            graph.Subsections.Add()
               .SetRadialGradientBackground(new DotGradientColor(Color.Gold, Color.DarkMagenta));

            Snapshot.Match(graph.Build(), "radial_gradient_graph_background");
        }
    }
}