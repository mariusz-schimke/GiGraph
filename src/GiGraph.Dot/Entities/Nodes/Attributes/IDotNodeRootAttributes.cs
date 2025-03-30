using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public interface IDotNodeRootAttributes : IDotNodeAttributes
{
    /// <summary>
    ///     Font attributes.
    /// </summary>
    DotFontAttributes Font { get; }

    /// <summary>
    ///     Style attributes.
    /// </summary>
    new DotNodeStyleAttributes Style { get; }

    /// <summary>
    ///     Node size attributes.
    /// </summary>
    DotNodeSizeAttributes Size { get; }

    /// <summary>
    ///     Node geometry attributes applicable if the <see cref="IDotNodeAttributes.Shape" /> is polygonal.
    /// </summary>
    DotNodeGeometryAttributes Geometry { get; }

    /// <summary>
    ///     Node image attributes.
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