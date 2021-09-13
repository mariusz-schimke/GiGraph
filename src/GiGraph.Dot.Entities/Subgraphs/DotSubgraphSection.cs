using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Subgraphs.Attributes;

namespace GiGraph.Dot.Entities.Subgraphs
{
    public partial class DotSubgraphSection : DotCommonGraphSection
    {
        public DotSubgraphSection()
            : this(new DotSubgraphRootAttributes())
        {
        }

        protected DotSubgraphSection(DotSubgraphSection source)
            : base(source)
        {
            Attributes = source.Attributes;
        }

        protected DotSubgraphSection(DotSubgraphRootAttributes attributes)
            : base(attributes)
        {
            Attributes = new DotEntityRootAttributes<IDotSubgraphRootAttributes, DotSubgraphRootAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the subgraph.
        /// </summary>
        public virtual DotEntityRootAttributes<IDotSubgraphRootAttributes, DotSubgraphRootAttributes> Attributes { get; }

        protected override DotAttributeCollection AttributeCollection => Attributes.Collection;
    }
}