using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public class DotNodeStyleAttributes : DotEntityCommonStyleAttributes<DotNodeFillStyle, DotNodeStyleOptions>
    {
        public DotNodeStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }
    }
}