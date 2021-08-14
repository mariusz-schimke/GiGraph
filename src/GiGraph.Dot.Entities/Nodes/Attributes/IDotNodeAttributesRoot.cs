using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Entities.Nodes.Attributes
{
    public interface IDotNodeAttributesRoot : IDotNodeAttributes
    {
        /// <summary>
        ///     Font properties.
        /// </summary>
        DotFontAttributes Font { get; }

        /// <summary>
        ///     Node image properties.
        /// </summary>
        DotNodeImageAttributes Image { get; }

        /// <summary>
        ///     Node geometry properties applicable if <see cref="Shape" /> is set to <see cref="DotNodeShape.Polygon" />.
        /// </summary>
        DotNodeGeometryAttributes Geometry { get; }

        /// <summary>
        ///     Node size properties.
        /// </summary>
        DotNodeSizeAttributes Size { get; }

        /// <summary>
        ///     Style options.
        /// </summary>
        new DotNodeStyleAttributes Style { get; }
    }
}