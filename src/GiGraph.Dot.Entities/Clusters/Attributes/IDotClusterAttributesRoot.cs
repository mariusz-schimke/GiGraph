using GiGraph.Dot.Entities.Attributes.Properties.Common;

namespace GiGraph.Dot.Entities.Clusters.Attributes
{
    public interface IDotClusterAttributesRoot : IDotClusterAttributes
    {
        /// <summary>
        ///     Font properties.
        /// </summary>
        DotFontAttributes Font { get; }

        /// <summary>
        ///     Style options.
        /// </summary>
        new DotClusterStyleAttributes Style { get; }

        /// <summary>
        ///     Horizontal and vertical label alignment options.
        /// </summary>
        DotLabelAlignmentAttributes LabelAlignment { get; }
    }
}