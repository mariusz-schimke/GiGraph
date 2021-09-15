using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Subgraphs.Attributes;

namespace GiGraph.Dot.Entities.Subgraphs
{
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

        private DotSubgraphSection(DotAttributeCollection attributes)
            : this(new DotSubgraphRootAttributes(attributes))
        {
        }

        private DotSubgraphSection(DotSubgraphRootAttributes attributes)
            : base(attributes)
        {
            Attributes = new DotEntityRootAttributes<IDotSubgraphAttributes, DotSubgraphRootAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the subgraph.
        /// </summary>
        public virtual DotEntityRootAttributes<IDotSubgraphAttributes, DotSubgraphRootAttributes> Attributes { get; }
    }
}