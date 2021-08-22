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
        ///     Gets or sets the number of sides.
        /// </summary>
        public virtual int? Sides { get; init; } = Sides;

        /// <summary>
        ///     Gets or sets a value indicating whether the shape is regular.
        /// </summary>
        public virtual bool? Regular { get; init; } = Regular;

        /// <summary>
        ///     Gets or sets the number of peripheries.
        /// </summary>
        public virtual int? Peripheries { get; init; } = Peripheries;

        /// <summary>
        ///     Gets or sets rotation angle.
        /// </summary>
        public virtual double? Rotation { get; init; } = Rotation;

        /// <summary>
        ///     Gets or sets skew factor.
        /// </summary>
        public virtual double? Skew { get; init; } = Skew;

        /// <summary>
        ///     Gets or sets distortion factor.
        /// </summary>
        public virtual double? Distortion { get; init; } = Distortion;
    }
}