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
    ///         a list of doubles (see <see cref="SetRadialRankSeparation"/>).
    ///     </para>
    ///     <para>
    ///         Calling this method is equivalent to setting the <see cref="RankSeparation"/> property directly, using
    ///         <see cref="DotRankSeparation"/>.
    ///     </para>
    /// </summary>
    /// <param name="distance">
    ///     The minimum vertical distance in inches between the bottom of the nodes in one rank and the tops of nodes in the next.
    /// </param>
    /// <param name="equalSpacing">
    ///     Determines if the centers of all ranks should be spaced equally apart.
    /// </param>
    /// <remarks>
    ///     Rank separation may be set by calling this method, <see cref="SetRankSeparation(bool)"/>, or
    ///     <see cref="SetRadialRankSeparation"/>. Only one of them should be used, as they write the same graph attribute.
    /// </remarks>
    public void SetRankSeparation(double distance, bool equalSpacing = false)
    {
        RankSeparation = new DotRankSeparation(distance, equalSpacing);
    }

    /// <summary>
    ///     <para>
    ///         In dot, sets the desired rank separation, in inches (default: 0.5, minimum: 0.02). This is the minimum vertical distance
    ///         between the bottom of the nodes in one rank and the tops of nodes in the next.
    ///     </para>
    ///     <para>
    ///         In twopi, specifies the radial separation of concentric circles (default: 1, minimum: 0.02). For twopi, this can also be
    ///         a list of doubles (see <see cref="SetRadialRankSeparation"/>).
    ///     </para>
    ///     <para>
    ///         Calling this method is equivalent to setting the <see cref="RankSeparation"/> property directly, using
    ///         <see cref="DotRankSeparation"/>.
    ///     </para>
    /// </summary>
    /// <param name="equalSpacing">
    ///     Determines if the centers of all ranks should be spaced equally apart.
    /// </param>
    /// <remarks>
    ///     Rank separation may be set by calling this method, <see cref="SetRankSeparation(double,bool)"/>, or
    ///     <see cref="SetRadialRankSeparation"/>. Only one of them should be used, as they write the same graph attribute.
    /// </remarks>
    public void SetRankSeparation(bool equalSpacing)
    {
        RankSeparation = new DotRankSeparation(equalSpacing);
    }

    /// <summary>
    ///     <para>
    ///         In twopi, specifies the radial separation of concentric circles.
    ///     </para>
    ///     <para>
    ///         Calling this method is equivalent to setting the <see cref="RankSeparation"/> property directly, using
    ///         <see cref="DotRadialRankSeparation"/>.
    ///     </para>
    /// </summary>
    /// <param name="radii">
    ///     The first double specifies the radius of the inner circle; the second double specifies the increase in radius from the first
    ///     circle to the second; etc. If there are more circles than numbers, the last number is used as the increment for the
    ///     remainder.
    /// </param>
    /// <remarks>
    ///     Rank separation may be set by calling this method, <see cref="SetRankSeparation(double,bool)"/>, or
    ///     <see cref="SetRankSeparation(bool)"/>. Only one of them should be used, as they write the same graph attribute.
    /// </remarks>
    public void SetRadialRankSeparation(params IEnumerable<double> radii)
    {
        RankSeparation = new DotRadialRankSeparation(radii);
    }
}