using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public interface IDotEdgeRootAttributes : IDotEdgeAttributes
{
    /// <summary>
    ///     Attributes applied to the head of the edge.
    /// </summary>
    DotEdgeHeadAttributes Head { get; }

    /// <summary>
    ///     Attributes applied to the tail of the edge.
    /// </summary>
    DotEdgeTailAttributes Tail { get; }

    /// <summary>
    ///     Font attributes.
    /// </summary>
    DotFontAttributes Font { get; }

    /// <summary>
    ///     Attributes applied to labels specified for the head and the tail of the edge.
    /// </summary>
    DotEdgeEndpointLabelsAttributes EndpointLabels { get; }

    /// <summary>
    ///     Hyperlink attributes applied to the non-label parts of the edge.
    /// </summary>
    DotEdgeHyperlinkAttributes EdgeHyperlink { get; }

    /// <summary>
    ///     Hyperlink attributes applied to the label of the edge.
    /// </summary>
    DotEdgeLabelHyperlinkAttributes LabelHyperlink { get; }

    /// <summary>
    ///     Style attributes.
    /// </summary>
    DotEdgeStyleAttributes Style { get; }

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
    DotEdgeLayoutAttributes Layout { get; }

    /// <summary>
    ///     Label options attributes.
    /// </summary>
    DotEdgeLabelOptionsAttributes LabelOptions { get; }
}