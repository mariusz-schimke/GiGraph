using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities
{
    public partial class DotFillableExtensionTest
    {
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