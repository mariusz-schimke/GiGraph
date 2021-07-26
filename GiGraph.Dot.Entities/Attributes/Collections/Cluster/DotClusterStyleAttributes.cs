using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Types.Clusters;

namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public class DotClusterStyleAttributes : DotClusterNodeCommonStyleAttributes<DotClusterFillStyle, DotClusterStyleOptions>
    {
        public DotClusterStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <inheritdoc cref="DotClusterNodeCommonStyleAttributes{TFillStyle,TFillStyleOptions}.CopyFrom" />
        public virtual void CopyFrom(DotClusterStyleAttributes attributes)
        {
            base.CopyFrom(attributes);
        }
    }
}