using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Types.Nodes;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public class DotNodeStyleAttributes : DotClusterNodeCommonStyleAttributes<DotNodeFillStyle, DotNodeStyleOptions>
    {
        public DotNodeStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <inheritdoc cref="DotClusterNodeCommonStyleAttributes{TFillStyle,TFillStyleOptions}.CopyFrom" />
        public virtual void CopyFrom(DotNodeStyleAttributes attributes)
        {
            base.CopyFrom(attributes);
        }
    }
}