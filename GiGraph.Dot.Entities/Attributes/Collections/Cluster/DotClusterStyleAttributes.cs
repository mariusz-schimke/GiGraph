using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public class DotClusterStyleAttributes : DotClusterNodeCommonStyleAttributes<DotClusterFillStyle, DotClusterStyleOptions>
    {
        public DotClusterStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }
    }
}