using System.Drawing;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Clusters;

public class DotClusterAttributeTest
{
    [Fact]
    public void cluster_with_cluster_id_prefix_as_discriminator_has_an_id_prefixed_with_cluster_and_no_cluster_attribute()
    {
        const string snapshotName = "cluster_with_cluster_id_prefix_as_discriminator";

        var graph = CreateGraphWithCluster(out _);
        Snapshot.Match(graph.Build(syntaxOptions: CreateSyntaxOptions(DotClusterDiscriminator.IdPrefix)), snapshotName);
    }

    [Fact]
    public void cluster_with_cluster_id_prefix_and_cluster_attribute_as_discriminators_has_an_id_prefixed_with_cluster_and_a_cluster_attribute()
    {
        const string snapshotName = "cluster_with_cluster_id_prefix_and_cluster_attribute_as_discriminators";

        var graph = CreateGraphWithCluster(out _);
        Snapshot.Match(graph.Build(syntaxOptions: CreateSyntaxOptions(DotClusterDiscriminator.IdPrefixAndAttribute)), snapshotName);
    }

    [Fact]
    public void cluster_with_a_cluster_attribute_as_discriminator_has_the_attribute_set_to_true_instead_of_an_id_prefixed_with_cluster()
    {
        const string snapshotName = "cluster_with_cluster_attribute_as_discriminator";

        var graph = CreateGraphWithCluster(out var cluster);

        // the attribute should be present in the output script with a value of true when not set explicitly
        var syntaxOptions = CreateSyntaxOptions(DotClusterDiscriminator.Attribute);
        Snapshot.Match(graph.Build(syntaxOptions: syntaxOptions), snapshotName);

        // the attribute should not be added to the collection when the graph is built
        var isCluster = cluster.Attributes.GetValue(a => a.IsCluster);
        Assert.Null(isCluster);
    }

    [Fact]
    public void cluster_with_a_cluster_attribute_as_discriminator_and_the_attribute_set_to_false_should_be_written_as_is()
    {
        const string snapshotName = "cluster_with_cluster_attribute_as_discriminator_and_cluster_attribute_false";

        var graph = CreateGraphWithCluster(out var cluster);
        cluster.Attributes.SetValue(a => a.IsCluster, false);

        // the attribute should be present in the output script with the value of false set above
        var syntaxOptions = CreateSyntaxOptions(DotClusterDiscriminator.Attribute);
        Snapshot.Match(graph.Build(syntaxOptions: syntaxOptions), snapshotName);

        // the value should stay intact after the graph is built
        var isCluster = cluster.Attributes.GetValue(a => a.IsCluster);
        Assert.False(isCluster);
    }

    [Fact]
    public void cluster_attribute_is_settable_when_cluster_id_prefix_is_used_as_discriminator()
    {
        const string snapshotName = "cluster_with_cluster_id_prefix_as_discriminator_and_cluster_attribute_false";

        var graph = CreateGraphWithCluster(out var cluster);
        cluster.Attributes.SetValue(a => a.IsCluster, false);

        Snapshot.Match(graph.Build(syntaxOptions: CreateSyntaxOptions(DotClusterDiscriminator.IdPrefix)), snapshotName);
    }

    [Theory]
    [InlineData(DotClusterDiscriminator.IdPrefix)]
    [InlineData(DotClusterDiscriminator.Attribute)]
    [InlineData(DotClusterDiscriminator.IdPrefixAndAttribute)]
    public void cluster_attribute_preference_determines_how_clusters_are_referred_to(DotClusterDiscriminator discriminator)
    {
        var snapshotName = $"id_reference_to_cluster_with_cluster_{discriminator.ToString().ToLower()}_as_discriminator";

        var graph = new DotGraph
        {
            Clusters =
            {
                EnableEdgeClipping = true
            }
        };

        graph.Clusters.Add("c1", c => c.Nodes.Add("n2"));
        graph.Edges.Add("n1", "n2").Head.ClusterId = "c1";

        Snapshot.Match(graph.Build(syntaxOptions: CreateSyntaxOptions(discriminator)), snapshotName);
    }

    private static DotGraph CreateGraphWithCluster(out DotCluster cluster)
    {
        var graph = new DotGraph();

        cluster = graph.Clusters.Add(
            "c1",
            c =>
            {
                c.Nodes.Add("n1");

                // this is to make sure the cluster attribute is used only in the root section, not in subsections
                c.Subsections.Add(
                    s =>
                    {
                        s.Style.Color = Color.Red;
                        s.Nodes.Add("n2");
                    }
                );
            }
        );

        return graph;
    }

    private static DotSyntaxOptions CreateSyntaxOptions(DotClusterDiscriminator discriminator) =>
        new()
        {
            Clusters = { Discriminator = discriminator }
        };
}