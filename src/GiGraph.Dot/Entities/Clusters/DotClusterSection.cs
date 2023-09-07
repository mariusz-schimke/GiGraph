using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Entities.Graphs;

namespace GiGraph.Dot.Entities.Clusters;

public partial class DotClusterSection : DotCommonGraphSection
{
    public DotClusterSection()
        : this(new DotAttributeCollection())
    {
    }

    protected DotClusterSection(DotClusterSection source)
        : base(source)
    {
        Attributes = source.Attributes;
    }

    protected DotClusterSection(DotAttributeCollection attributes)
        : this(new DotClusterRootAttributes(attributes))
    {
    }

    protected DotClusterSection(DotClusterRootAttributes attributes)
        : base(attributes)
    {
        Attributes = new(attributes);
    }

    /// <summary>
    ///     Provides access to the attributes of the subgraph.
    /// </summary>
    public DotEntityRootAttributesAccessor<IDotClusterAttributes, DotClusterRootAttributes> Attributes { get; }
}