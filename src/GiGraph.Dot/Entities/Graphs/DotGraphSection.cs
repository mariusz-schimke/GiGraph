using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Graphs.Attributes;

namespace GiGraph.Dot.Entities.Graphs;

public partial class DotGraphSection : DotCommonGraphSection
{
    public DotGraphSection()
        : this(new DotAttributeCollection())
    {
    }

    protected DotGraphSection(DotGraphSection source)
        : base(source)
    {
        Attributes = source.Attributes;
    }

    protected DotGraphSection(DotAttributeCollection attributes)
        : this(new DotGraphRootAttributes(attributes))
    {
    }

    protected DotGraphSection(DotGraphRootAttributes graphAttributes)
        : base(graphAttributes, new DotGraphClusterCollection(graphAttributes.Clusters))
    {
        Attributes = new DotEntityRootAttributesAccessor<IDotGraphAttributes, DotGraphRootAttributes>(graphAttributes);
    }

    /// <summary>
    ///     Provides access to the attributes of the graph.
    /// </summary>
    public DotEntityRootAttributesAccessor<IDotGraphAttributes, DotGraphRootAttributes> Attributes { get; }

    /// <inheritdoc cref="DotCommonGraphSection.Clusters"/>
    public new DotGraphClusterCollection Clusters => (DotGraphClusterCollection) base.Clusters;
}