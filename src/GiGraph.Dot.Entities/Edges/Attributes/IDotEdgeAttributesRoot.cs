using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public interface IDotEdgeAttributesRoot : IDotEdgeAttributes
    {
        /// <summary>
        ///     Properties applied to the head of the edge.
        /// </summary>
        DotEdgeHeadAttributes Head { get; }

        /// <summary>
        ///     Properties applied to the tail of the edge.
        /// </summary>
        DotEdgeTailAttributes Tail { get; }

        /// <summary>
        ///     Font properties.
        /// </summary>
        DotFontAttributes Font { get; }

        /// <summary>
        ///     Properties applied to labels specified for the head and the tail of the edge.
        /// </summary>
        DotEdgeEndpointLabelsAttributes EndpointLabels { get; }

        /// <summary>
        ///     Hyperlink properties applied to the non-label parts of the edge.
        /// </summary>
        DotEdgeHyperlinkAttributes EdgeHyperlink { get; }

        /// <summary>
        ///     Hyperlink properties applied to the label of the edge.
        /// </summary>
        DotEdgeLabelHyperlinkAttributes LabelHyperlink { get; }

        /// <summary>
        ///     Style options.
        /// </summary>
        new DotEdgeStyleAttributes Style { get; }

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