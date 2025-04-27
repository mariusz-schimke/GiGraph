using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

public interface IDotClusterRootAttributes : IDotClusterAttributes
{
    /// <summary>
    ///     Font attributes.
    /// </summary>
    DotFontAttributes Font { get; }

    /// <summary>
    ///     Style attributes.
    /// </summary>
    DotClusterStyleAttributes Style { get; }

    /// <summary>
    ///     Label options attributes.
    /// </summary>
    DotLabelOptionsAttributes LabelOptions { get; }

    /// <summary>
    ///     Style sheet attributes used for SVG output.
    /// </summary>
    DotSvgStyleSheetAttributes SvgStyleSheet { get; }

    /// <summary>
    ///     Hyperlink attributes.
    /// </summary>
    DotHyperlinkAttributes Hyperlink { get; }

    /// <summary>
    ///     Layout attributes.
    /// </summary>
    DotClusterLayoutAttributes Layout { get; }
}