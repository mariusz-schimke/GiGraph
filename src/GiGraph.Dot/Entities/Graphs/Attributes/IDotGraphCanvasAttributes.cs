using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Orientation;
using GiGraph.Dot.Types.Scaling;
using GiGraph.Dot.Types.Viewport;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public interface IDotGraphCanvasAttributes
{
    /// <summary>
    ///     If true, the drawing is centered in the output canvas (default: false).
    /// </summary>
    bool? CenterDrawing { get; set; }

    /// <summary>
    ///     Sets graph orientation to landscape or portrait (default). Used only if <see cref="OrientationAngle"/> is not defined. See
    ///     also <see cref="LandscapeOrientation"/>.
    /// </summary>
    DotOrientation? Orientation { get; set; }

    /// <summary>
    ///     If 90, sets drawing orientation to landscape (default: 0). See also <see cref="Orientation"/> and
    ///     <see cref="LandscapeOrientation"/>.
    /// </summary>
    int? OrientationAngle { get; set; }

    /// <summary>
    ///     If true, the graph is rendered in landscape mode (default: false). Synonymous with <see cref="OrientationAngle"/> = 90 or
    ///     <see cref="Orientation"/> = <see cref="DotOrientation.Landscape"/>.
    /// </summary>
    bool? LandscapeOrientation { get; set; }

    /// <summary>
    ///     Specifies the expected number of pixels per inch on a display device (svg, bitmap output only; default: 96.0, 0.0). For
    ///     bitmap output, this guarantees that text rendering will be done more accurately, both in size and in placement. For SVG
    ///     output, it is used to guarantee that the dimensions in the output correspond to the correct number of points or inches.
    /// </summary>
    double? Dpi { get; set; }

    /// <summary>
    ///     This is a synonym for the <see cref="Dpi"/> attribute (svg, bitmap output only; default: 96.0, 0.0).
    /// </summary>
    double? Resolution { get; set; }

    /// <summary>
    ///     <para>
    ///         The maximum width and height of drawing, in inches. If only a single number is given, this is used for both the width and
    ///         the height.
    ///     </para>
    ///     <para>
    ///         If defined and the drawing is larger than the given size, the drawing is uniformly scaled down so that it fits within the
    ///         given size.
    ///     </para>
    ///     <para>
    ///         If <see cref="DotPoint.IsFixed"/> is set, then the size specified is taken to be the desired size. In this case, if both
    ///         dimensions of the drawing are less than size, the drawing is scaled up uniformly until at least one dimension equals its
    ///         dimension in size.
    ///     </para>
    ///     <para>
    ///         Note that there is some interaction between the <see cref="Size"/> and the <see cref="Scaling"/> attributes.
    ///     </para>
    /// </summary>
    DotPoint? Size { get; set; }

    /// <summary>
    ///     <para>
    ///         Specifies how much, in inches, to extend the drawing area around the minimal area needed to draw the graph. This area is
    ///         part of the drawing, and will be filled with the background color, if appropriate. Default: 0.0555 (4 points).
    ///     </para>
    ///     <para>
    ///         Normally, a small pad is used for aesthetic reasons, especially when a background color is used, to avoid having nodes
    ///         and edges abutting the boundary of the drawn region.
    ///     </para>
    /// </summary>
    DotPoint? Padding { get; set; }

    /// <summary>
    ///     <para>
    ///         Sets x and y margins of canvas, in inches (default: device-dependent). If the margin is a single double, both margins are
    ///         set equal to the given value.
    ///     </para>
    ///     <para>
    ///         Note that the margin is not part of the drawing but just empty space left around the drawing. It basically corresponds to
    ///         a translation of drawing, as would be necessary to center a drawing on a page. Nothing is actually drawn in the margin.
    ///         To actually extend the background of a drawing, see the <see cref="Padding"/> attribute.
    ///     </para>
    /// </summary>
    DotPoint? Margin { get; set; }

    /// <summary>
    ///     <para>
    ///         Gets or sets the aspect ratio (drawing height / drawing width) for the drawing. Note that this is adjusted before the
    ///         <see cref="Size"/> attribute constraints are enforced. In addition, the calculations usually ignore the node sizes, so
    ///         the final drawing size may only approximate what is desired.
    ///     </para>
    ///     <para>
    ///         If ratio is numeric (<see cref="DotGraphAspectRatio"/>), it is taken as the desired aspect ratio. Then, if the
    ///         actual aspect ratio is less than the desired ratio, the drawing height is scaled up to achieve the desired ratio; if the
    ///         actual ratio is greater than that desired ratio, the drawing width is scaled up.
    ///     </para>
    ///     <para>
    ///         See also <see cref="DotGraphScaling"/> for non-numeric options of the ratio.
    ///     </para>
    /// </summary>
    DotGraphScalingDefinition? Scaling { get; set; }

    /// <summary>
    ///     <para>
    ///         Gets or sets the clipping window on final drawing. Supersedes any <see cref="Size"/> attribute. The width and height of
    ///         the viewport specify precisely the final size of the output.
    ///     </para>
    ///     <para>
    ///         To specify width, height, and zoom of the final drawing, use <see cref="DotViewport"/>. To also specify a central point
    ///         of the drawing, use <see cref="DotPointCenteredViewport"/>, or, to specify a node as a central point, use
    ///         <see cref="DotNodeCenteredViewport"/>. By default, the focus is the center of the graph bounding box, i.e., (bbx / 2, bby
    ///         / 2), where "bbx, bby" is the value of the bounding box attribute bb.
    ///     </para>
    /// </summary>
    DotViewport? Viewport { get; set; }
}