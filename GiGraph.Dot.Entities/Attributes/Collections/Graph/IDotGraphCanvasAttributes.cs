using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public interface IDotGraphCanvasAttributes
    {
        /// <summary>
        ///     If true, the drawing is centered in the output canvas (default: false).
        /// </summary>
        bool? CenterDrawing { get; set; }

        /// <summary>
        ///     Sets graph orientation to landscape or portrait (default). Used only if <see cref="OrientationAngle" /> is not defined. See
        ///     also <see cref="Landscape" />.
        /// </summary>
        DotOrientation? Orientation { get; set; }

        /// <summary>
        ///     If 90, sets drawing orientation to landscape (default: 0). See also <see cref="Orientation" /> and <see cref="Landscape" />.
        /// </summary>
        int? OrientationAngle { get; set; }

        /// <summary>
        ///     If true, the graph is rendered in landscape mode (default: false). Synonymous with <see cref="OrientationAngle" /> = 90 or
        ///     <see cref="Orientation" /> = <see cref="DotOrientation.Landscape" />.
        /// </summary>
        bool? Landscape { get; set; }
    }
}