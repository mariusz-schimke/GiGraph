using GiGraph.Dot.Types.Graphs.Canvas.Scaling;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphCanvasAttributes
{
    /// <summary>
    ///     <para>
    ///         Sets the aspect ratio (drawing height / drawing width) for the drawing. Note that this is adjusted before the
    ///         <see cref="Size"/> attribute constraints are enforced. In addition, the calculations usually ignore the node sizes, so
    ///         the final drawing size may only approximate what is desired.
    ///     </para>
    ///     <para>
    ///         The ratio specified is taken as the desired aspect ratio. Then, if the actual aspect ratio is less than the desired
    ///         ratio, the drawing height is scaled up to achieve the desired ratio; if the actual ratio is greater than that desired
    ///         ratio, the drawing width is scaled up.
    ///     </para>
    ///     <para>
    ///         See also <see cref="SetScalingMode"/> for non-numeric options of the ratio.
    ///     </para>
    ///     <para>
    ///         Calling this method is equivalent to setting the <see cref="Scaling"/> property directly, using
    ///         <see cref="DotGraphAspectRatio"/>.
    ///     </para>
    /// </summary>
    /// <param name="aspectRatio">
    ///     The aspect ratio of the graph. If ratio = x where x is a floating point number, then the drawing is scaled up in one
    ///     dimension to achieve the requested ratio expressed as drawing height/width. For example, ratio = 2.0 makes the drawing twice
    ///     as high as it is wide.
    /// </param>
    /// <remarks>
    ///     Scaling may be set by calling this method or <see cref="SetScalingMode"/>. Only one of them should be used, as both of them
    ///     write the same graph attribute.
    /// </remarks>
    public void SetAspectRatio(double aspectRatio)
    {
        Scaling = new DotGraphAspectRatio(aspectRatio);
    }

    /// <summary>
    ///     <para>
    ///         Sets the scaling mode for the drawing. Note that this is adjusted before the <see cref="Size"/> attribute constraints are
    ///         enforced.
    ///     </para>
    ///     <para>
    ///         Calling this method is equivalent to setting the <see cref="Scaling"/> property directly, using
    ///         <see cref="DotGraphScalingMode"/>.
    ///     </para>
    /// </summary>
    /// <param name="mode">
    ///     The scaling mode of the graph drawing to use.
    /// </param>
    /// <remarks>
    ///     Scaling may be set by calling this method or <see cref="SetAspectRatio"/>. Only one of them should be used, as both of them
    ///     write the same graph attribute.
    /// </remarks>
    public void SetScalingMode(DotGraphScaling mode)
    {
        Scaling = new DotGraphScalingMode(mode);
    }
}