using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Entities.Nodes.Attributes
{
    public class DotNodeStyleAttributes : DotClusterNodeCommonStyleAttributes<DotNodeFillStyle, DotNodeStyleProperties>
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