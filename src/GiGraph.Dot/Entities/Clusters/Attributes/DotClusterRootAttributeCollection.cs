using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

public class DotClusterRootAttributeCollection : DotAttributeCollection
{
    public DotClusterRootAttributeCollection(DotAttributeFactory attributeFactory)
        : base(attributeFactory)
    {
    }

    public DotClusterRootAttributeCollection()
    {
    }

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
        if (!options.Clusters.PreferClusterAttribute)
        {
            return this;
        }

        var result = new DotAttributeCollection(_attributeFactory, this);
        result.Set(DotAttributeKeys.Cluster, true);
        return result;
    }
}