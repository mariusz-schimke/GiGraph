using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Clusters;

public class DotClusterAttributeTest
{
    [Fact]
    public void cluster_with_a_cluster_attribute_preference_has_the_attribute_instead_of_an_id_prefix()
    {
        const string snapshotName = "cluster_with_cluster_attribute_preference";

        var graph = new DotGraph();

        var cluster = graph.Clusters.Add("c1", c =>
        {
            c.Nodes.Add("n1");

            // this is to make sure the cluster attribute is used only in the root section, not in subsections
            c.Subsections.Add(s =>
            {
                s.Color = Color.Red;
                s.Nodes.Add("n2");
            });
        });

        var syntaxOptions = CreateSyntaxOptions(true);
        Snapshot.Match(graph.Build(syntaxOptions: syntaxOptions), snapshotName);

        // set this attribute explicitly, and it should be still overwritten with a value of true
        cluster.Attributes.SetValue(a => a.IsCluster, false);
        Snapshot.Match(graph.Build(syntaxOptions: syntaxOptions), snapshotName);

        // the value should stay intact after the graph is built
        var isCluster = cluster.Attributes.GetValue(a => a.IsCluster);
        Assert.False(isCluster);
    }

    [Fact]
    public void cluster_with_no_cluster_attribute_preference_has_an_id_prefix_without_the_attribute()
    {
        const string snapshotName = "cluster_with_no_cluster_attribute_preference";

        var graph = new DotGraph();

        graph.Clusters.Add("c1", c =>
        {
            c.Nodes.Add("n1");
            c.Subsections.Add(s =>
            {
                s.Color = Color.Red;
                s.Nodes.Add("n2");
            });
        });

        Snapshot.Match(graph.Build(syntaxOptions: CreateSyntaxOptions(false)), snapshotName);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void cluster_attribute_preference_determines_how_clusters_are_referred_to(bool preferClusterAttribute)
    {
        var snapshotName = $"reference_to_cluster_with_cluster_attribute_preference_set_to_{preferClusterAttribute.ToString().ToLower()}";

        var graph = new DotGraph
        {
            Clusters =
            {
                AllowEdgeClipping = true
            }
        };

        graph.Clusters.Add("c1", c => c.Nodes.Add("n2"));
        graph.Edges.Add("n1", "n2").Head.ClusterId = "c1";

        Snapshot.Match(graph.Build(syntaxOptions: CreateSyntaxOptions(preferClusterAttribute)), snapshotName);
    }

    [Fact]
    public void cluster_attribute_is_settable_when_no_cluster_attribute_preference_is_set()
    {
        const string snapshotName = "cluster_with_cluster_attribute_specified_explicitly";

        var graph = new DotGraph();
        graph.Clusters.Add("c1", c =>
        {
            c.Attributes.SetValue(a => a.IsCluster, false);
        });

        Snapshot.Match(graph.Build(syntaxOptions: CreateSyntaxOptions(false)), snapshotName);
    }

    private static DotSyntaxOptions CreateSyntaxOptions(bool preferClusterAttribute) =>
        new()
        {
            Clusters = { PreferClusterAttribute = preferClusterAttribute }
        };
}