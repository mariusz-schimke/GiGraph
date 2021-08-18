using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Entities.Nodes.Attributes
{
    public interface IDotNodeRootAttributes : IDotNodeAttributes
    {
        /// <summary>
        ///     Font properties.
        /// </summary>
        DotFontAttributes Font { get; }

        /// <summary>
        ///     Style options.
        /// </summary>
        new DotNodeStyleAttributes Style { get; }

        /// <summary>
        ///     Node size properties.
        /// </summary>
        DotNodeSizeAttributes Size { get; }

        /// <summary>
        ///     Node geometry properties applicable if <see cref="IDotNodeAttributes.Shape" /> is set to <see cref="DotNodeShape.Polygon" />.
        /// </summary>
        DotNodeGeometryAttributes Geometry { get; }

        /// <summary>
        ///     Node image properties.
        /// </summary>
        DotNodeImageAttributes Image { get; }

        /// <summary>
        ///     Style sheet attributes used for SVG output.
        /// </summary>
        DotSvgStyleSheetAttributes SvgStyleSheet { get; }

        /// <summary>
        ///     Hyperlink attributes.
        /// </summary>
        DotHyperlinkAttributes Hyperlink { get; }
    }
}