using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Styling;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities
{
    public partial class DotFillableExtensionTest
    {
        [Fact]
        public void does_not_overwrite_other_cluster_style_flags()
        {
            var graph = new DotGraph();

            graph.Clusters.Add(c =>
                {
                    c.Style.BorderStyle = DotBorderStyle.Solid;
                    c.Style.CornerStyle = DotCornerStyle.Rounded;
                    c.Style.BorderWeight = DotBorderWeight.Bold;
                    c.Style.Invisible = true;
                })
               .SetPlainColorFill(Color.Red);

            graph.Clusters.Style.BorderStyle = DotBorderStyle.Solid;
            graph.Clusters.Style.CornerStyle = DotCornerStyle.Rounded;
            graph.Clusters.Style.BorderWeight = DotBorderWeight.Bold;
            graph.Clusters.Style.Invisible = true;
            graph.Clusters.SetPlainColorFill(Color.Red);

            Snapshot.Match(graph.Build(), "gradient_fill_on_clusters_with_other_styles_set");
        }

        [Fact]
        public void sets_plain_color_fill_on_cluster()
        {
            var graph = new DotGraph();
            graph.Clusters.Add().SetPlainColorFill(Color.Red);
            Snapshot.Match(graph.Build(), "plain_color_fill_on_cluster");
        }

        [Fact]
        public void sets_plain_color_fill_on_cluster_collection()
        {
            var graph = new DotGraph();
            graph.Clusters.SetPlainColorFill(Color.Red);
            Snapshot.Match(graph.Build(), "plain_color_fill_on_cluster_collection");
        }
    }
}