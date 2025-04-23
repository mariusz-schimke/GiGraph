using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphLayoutAttributes
{
    /// <summary>
    ///     <para>
    ///         In dot, sets the desired rank separation, in inches (default: 0.5, minimum: 0.02). This is the minimum vertical distance
    ///         between the bottom of the nodes in one rank and the tops of nodes in the next.
    ///     </para>
    ///     <para>
    ///         In twopi, specifies the radial separation of concentric circles (default: 1, minimum: 0.02). For twopi, this can also be
    ///         a list of doubles (see <see cref="SetRadialSpacing"/>).
    ///     </para>
    ///     <para>
    ///         Calling this method is equivalent to setting the <see cref="RankSpacing"/> property directly, using
    ///         <see cref="DotRankSpacing"/>.
    ///     </para>
    /// </summary>
    /// <param name="distance">
    ///     The minimum vertical distance in inches between the bottom of the nodes in one rank and the tops of nodes in the next.
    /// </param>
    /// <param name="equalSpacing">
    ///     Determines if the centers of all ranks should be spaced equally apart.
    /// </param>
    /// <remarks>
    ///     Rank separation may be set by calling this method, <see cref="SetRankSpacing(bool)"/>, or <see cref="SetRadialSpacing"/>.
    ///     Only one of them should be used, as they write the same graph attribute.
    /// </remarks>
    public void SetRankSpacing(double distance, bool equalSpacing = false)
    {
        RankSpacing = new DotRankSpacing(distance, equalSpacing);
    }

    /// <summary>
    ///     <para>
    ///         In dot, sets the desired rank separation, in inches (default: 0.5, minimum: 0.02). This is the minimum vertical distance
    ///         between the bottom of the nodes in one rank and the tops of nodes in the next.
    ///     </para>
    ///     <para>
    ///         In twopi, specifies the radial separation of concentric circles (default: 1, minimum: 0.02). For twopi, this can also be
    ///         a list of doubles (see <see cref="SetRadialSpacing"/>).
    ///     </para>
    ///     <para>
    ///         Calling this method is equivalent to setting the <see cref="RankSpacing"/> property directly, using
    ///         <see cref="DotRankSpacing"/>.
    ///     </para>
    /// </summary>
    /// <param name="equalSpacing">
    ///     Determines if the centers of all ranks should be spaced equally apart.
    /// </param>
    /// <remarks>
    ///     Rank separation may be set by calling this method, <see cref="SetRankSpacing(double,bool)"/>, or
    ///     <see cref="SetRadialSpacing"/>. Only one of them should be used, as they write the same graph attribute.
    /// </remarks>
    public void SetRankSpacing(bool equalSpacing)
    {
        RankSpacing = new DotRankSpacing(equalSpacing);
    }

    /// <summary>
    ///     <para>
    ///         In twopi, specifies the radial separation of concentric circles.
    ///     </para>
    ///     <para>
    ///         Calling this method is equivalent to setting the <see cref="RankSpacing"/> property directly, using
    ///         <see cref="DotRadialSpacing"/>.
    ///     </para>
    /// </summary>
    /// <param name="radii">
    ///     The first double specifies the radius of the inner circle; the second double specifies the increase in radius from the first
    ///     circle to the second; etc. If there are more circles than numbers, the last number is used as the increment for the
    ///     remainder.
    /// </param>
    /// <remarks>
    ///     Rank separation may be set by calling this method, <see cref="SetRankSpacing(double,bool)"/>, or
    ///     <see cref="SetRankSpacing(bool)"/>. Only one of them should be used, as they write the same graph attribute.
    /// </remarks>
    public void SetRadialSpacing(params IEnumerable<double> radii)
    {
        RankSpacing = new DotRadialSpacing(radii);
    }
}