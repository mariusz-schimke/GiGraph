using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public class DotClusterStyleAttributes : DotEntityCommonStyleAttributes<DotClusterFillStyle, DotClusterStyleOptions>
    {
        public DotClusterStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }
    }
}