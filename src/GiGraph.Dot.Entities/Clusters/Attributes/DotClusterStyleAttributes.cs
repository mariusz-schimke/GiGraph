using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.ClusterNode;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters.Attributes
{
    public class DotClusterStyleAttributes : DotClusterNodeCommonStyleAttributes<DotClusterFillStyle, DotClusterStyleProperties>
    {
        public DotClusterStyleAttributes(DotAttributeCollection attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Applies the specified style options.
        /// </summary>
        /// <param name="fillStyle">
        ///     The fill style to set.
        /// </param>
        /// <param name="borderStyle">
        ///     The border style to set.
        /// </param>
        /// <param name="borderWeight">
        ///     The border weight to set.
        /// </param>
        /// <param name="cornerStyle">
        ///     The corner style to set.
        /// </param>
        /// <param name="invisible">
        ///     Determines whether the node should be invisible.
        /// </param>
        public virtual void Set(DotClusterFillStyle fillStyle = default, DotBorderStyle borderStyle = default,
            DotBorderWeight borderWeight = default, DotCornerStyle cornerStyle = default, bool invisible = false)
        {
            base.SetProperties(fillStyle, borderStyle, borderWeight, cornerStyle, invisible);
        }

        /// <inheritdoc cref="DotClusterNodeCommonStyleAttributes{TFillStyle,TStyleProperties}.CopyFrom" />
        public virtual void CopyFrom(DotClusterStyleAttributes attributes)
        {
            base.CopyFrom(attributes);
        }
    }
}