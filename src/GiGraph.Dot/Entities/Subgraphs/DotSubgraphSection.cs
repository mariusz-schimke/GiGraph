using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Subgraphs.Attributes;

namespace GiGraph.Dot.Entities.Subgraphs;

public partial class DotSubgraphSection : DotCommonGraphSection
{
    public DotSubgraphSection()
        : this(new DotAttributeCollection())
    {
    }

    protected DotSubgraphSection(DotSubgraphSection source)
        : base(source)
    {
        Attributes = source.Attributes;
    }

    protected DotSubgraphSection(DotAttributeCollection attributes)
        : this(new DotSubgraphRootAttributes(attributes))
    {
    }

    protected DotSubgraphSection(DotSubgraphRootAttributes attributes)
        : base(attributes)
    {
        Attributes = new DotEntityRootAttributesAccessor<IDotSubgraphAttributes, DotSubgraphRootAttributes>(attributes);
    }

    /// <summary>
    ///     Provides access to the attributes of the subgraph.
    /// </summary>
    public DotEntityRootAttributesAccessor<IDotSubgraphAttributes, DotSubgraphRootAttributes> Attributes { get; }
}