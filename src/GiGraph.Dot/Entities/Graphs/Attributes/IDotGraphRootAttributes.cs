using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public interface IDotGraphRootAttributes : IDotGraphAttributes
{
    /// <summary>
    ///     Attributes applied to clusters.
    /// </summary>
    DotGraphClustersAttributes Clusters { get; }

    /// <summary>
    ///     Style attributes.
    /// </summary>
    new DotGraphStyleAttributes Style { get; }

    /// <summary>
    ///     Font attributes.
    /// </summary>
    DotGraphFontAttributes Font { get; }

    /// <summary>
    ///     Style sheet attributes used for SVG output.
    /// </summary>
    DotGraphSvgStyleSheetAttributes SvgStyleSheet { get; }

    /// <summary>
    ///     Graph layout options.
    /// </summary>
    DotGraphLayoutAttributes Layout { get; }

    /// <summary>
    ///     Graph canvas attributes.
    /// </summary>
    DotGraphCanvasAttributes Canvas { get; }

    /// <summary>
    ///     Horizontal and vertical label alignment options.
    /// </summary>
    DotLabelAlignmentAttributes LabelAlignment { get; }

    /// <summary>
    ///     Hyperlink attributes.
    /// </summary>
    DotHyperlinkAttributes Hyperlink { get; }
}