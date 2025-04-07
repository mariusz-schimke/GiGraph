using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Graphs.Collections;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Clusters;

/// <summary>
///     Represents a cluster subgraph. A cluster subgraph is a special type of subgraph whose appearance can be customized. If
///     supported, the layout engine used to render it, will do the layout so that the nodes belonging to the cluster are drawn
///     together, with the entire drawing of the cluster contained within a bounding rectangle. Note that cluster subgraphs are not
///     part of the DOT language, but solely a syntactic convention adhered to by certain of the layout engines.
/// </summary>
public class DotCluster : DotClusterSection, IDotGraph, IDotOrderable
{
    /// <summary>
    ///     Creates a new cluster subgraph.
    /// </summary>
    /// <param name="id">
    ///     The unique identifier of the cluster.
    /// </param>
    public DotCluster(string id)
        : this(new DotClusterSection(), new DotGraphSectionCollection<DotClusterSection>())
    {
        Id = id ?? throw new ArgumentNullException(nameof(id), "Cluster identifier must not be null.");
    }

    protected DotCluster(DotClusterSection rootSection, DotGraphSectionCollection<DotClusterSection> subsections)
        : base(rootSection)
    {
        Subsections = subsections;
    }

    /// <summary>
    ///     <para>
    ///         The subsections of the graph. They appear consecutively in the output DOT script, and inherit the graph attributes, and
    ///         the global node and/or edge attributes of their predecessors. When overridden in any subsection, the new graph attributes
    ///         and global node/edge attributes apply to the elements the section itself contains, and also to those that belong to the
    ///         sections that follow it (if any).
    ///     </para>
    ///     <para>
    ///         Note that each subsection is dependent on the graph attributes and the global node and edge attributes specified by the
    ///         sections that precede it (including those of the root section represented by the current element). Note also that some
    ///         graph attributes cannot be overriden, and apply to the whole graph no matter in which section they are set.
    ///     </para>
    ///     <para>
    ///         As far as setting global node and/or edge attributes for a specific group of elements is concerned,
    ///         <see cref="Subgraphs"/> may be the cleaner and preferable way to achieve the effect.
    ///     </para>
    /// </summary>
    public DotGraphSectionCollection<DotClusterSection> Subsections { get; }

    /// <summary>
    ///     Gets or sets the identifier of the cluster.
    /// </summary>
    public virtual string Id { get; set; } = null!;

    IEnumerable<IDotGraphSection> IDotGraph.Subsections => Subsections;

    string IDotOrderable.OrderingKey => Id;

    /// <summary>
    ///     Returns attributes from the collection based on the syntax options specified. Because Graphviz introduced the 'cluster'
    ///     attribute at some point as an alternative way of specifying that a subgraph should be interpreted as a cluster, this method
    ///     makes sure that the attribute is present in the returned collection when there is a preference in the options to use it
    ///     instead of the 'cluster' prefix in the ID of the subgraph.
    /// </summary>
    /// <param name="options">
    ///     The options to apply.
    /// </param>
    protected override DotAttributeCollection GetAttributes(DotSyntaxOptions options)
    {
        var result = base.GetAttributes(options);

        // if the user sets the attribute to false explicitly, let's preserve it the way it is
        if (!options.Clusters.Discriminator.HasFlag(DotClusterDiscriminator.Attribute) || result.ContainsKey(DotAttributeKeys.Cluster))
        {
            return result;
        }

        result = new DotAttributeCollection(result);
        result.SetValue(DotAttributeKeys.Cluster, true);
        return result;
    }

    /// <summary>
    ///     Creates a new cluster with the specified nodes.
    /// </summary>
    /// <param name="id">
    ///     The unique identifier of the cluster.
    /// </param>
    /// <param name="nodeIds">
    ///     The identifiers of nodes to add to the subgraph.
    /// </param>
    public static DotCluster FromNodes(string id, params string[] nodeIds) => FromNodes(id, (IEnumerable<string>) nodeIds);

    /// <summary>
    ///     Creates a new cluster with the specified nodes.
    /// </summary>
    /// <param name="id">
    ///     The unique identifier of the cluster.
    /// </param>
    /// <param name="nodeIds">
    ///     The identifiers of nodes to add to the subgraph.
    /// </param>
    public static DotCluster FromNodes(string id, IEnumerable<string> nodeIds)
    {
        var result = new DotCluster(id);
        result.Nodes.AddRange(nodeIds);
        return result;
    }
}