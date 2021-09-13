using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Entities.Graphs;

namespace GiGraph.Dot.Entities.Clusters
{
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

        private DotClusterSection(DotAttributeCollection attributes)
            : this(new DotClusterRootAttributes(attributes))
        {
        }

        private DotClusterSection(DotClusterRootAttributes attributes)
            : base(attributes)
        {
            Attributes = new DotEntityRootAttributes<IDotClusterRootAttributes, DotClusterRootAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the subgraph.
        /// </summary>
        public virtual DotEntityRootAttributes<IDotClusterRootAttributes, DotClusterRootAttributes> Attributes { get; }

        protected override DotAttributeCollection AttributeCollection => Attributes.Collection;
    }
}