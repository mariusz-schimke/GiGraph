using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Types.Clusters;

namespace GiGraph.Dot.Entities.Clusters.Attributes
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