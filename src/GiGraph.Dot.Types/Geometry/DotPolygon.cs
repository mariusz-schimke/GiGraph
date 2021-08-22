namespace GiGraph.Dot.Types.Geometry
{
    /// <summary>
    ///     Geometry properties of a polygonal shape.
    /// </summary>
    /// <param name="Sides">
    ///     Number of sides.
    /// </param>
    /// <param name="Regular">
    ///     Determines whether the shape is regular.
    /// </param>
    /// <param name="Peripheries">
    ///     Number of peripheries.
    /// </param>
    /// <param name="Rotation">
    ///     Rotation angle.
    /// </param>
    /// <param name="Skew">
    ///     Skew factor.
    /// </param>
    /// <param name="Distortion">
    ///     Distortion factor.
    /// </param>
    public record DotPolygon(
        int? Sides = null,
        bool? Regular = null,
        int? Peripheries = null,
        double? Rotation = null,
        double? Skew = null,
        double? Distortion = null
    )
    {
        /// <summary>
        ///     The number of sides.
        /// </summary>
        public virtual int? Sides { get; init; } = Sides;

        /// <summary>
        ///     Indicates whether the shape is regular.
        /// </summary>
        public virtual bool? Regular { get; init; } = Regular;

        /// <summary>
        ///     The number of peripheries.
        /// </summary>
        public virtual int? Peripheries { get; init; } = Peripheries;

        /// <summary>
        ///     The rotation angle.
        /// </summary>
        public virtual double? Rotation { get; init; } = Rotation;

        /// <summary>
        ///     The skew factor.
        /// </summary>
        public virtual double? Skew { get; init; } = Skew;

        /// <summary>
        ///     The distortion factor.
        /// </summary>
        public virtual double? Distortion { get; init; } = Distortion;
    }
}