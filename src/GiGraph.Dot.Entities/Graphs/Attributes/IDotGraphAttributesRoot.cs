using GiGraph.Dot.Entities.Attributes.Properties.Common;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public interface IDotGraphAttributesRoot : IDotGraphAttributes
    {
        /// <summary>
        ///     Font properties.
        /// </summary>
        DotGraphFontAttributes Font { get; }

        /// <summary>
        ///     Style options. Note that the options are shared with those specified for <see cref="Clusters" />.
        /// </summary>
        new DotGraphStyleAttributes Style { get; }

        /// <summary>
        ///     Style sheet attributes used for SVG output.
        /// </summary>
        DotGraphSvgSvgStyleSheetAttributes SvgStyleSheet { get; }

        /// <summary>
        ///     Graph layout options.
        /// </summary>
        DotGraphLayoutAttributes Layout { get; }

        /// <summary>
        ///     Graph canvas properties.
        /// </summary>
        DotGraphCanvasAttributes Canvas { get; }

        /// <summary>
        ///     Horizontal and vertical label alignment options.
        /// </summary>
        DotLabelAlignmentAttributes LabelAlignment { get; }
    }
}