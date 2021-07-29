namespace GiGraph.Dot.Types.Geometry
{
    /// <summary>
    ///     Geometry properties of a polygonal shape.
    /// </summary>
    public class DotPolygon
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="sides">
        ///     Number of sides.
        /// </param>
        /// <param name="regular">
        ///     Determines whether the shape is regular.
        /// </param>
        /// <param name="peripheries">
        ///     Number of peripheries.
        /// </param>
        /// <param name="rotation">
        ///     Rotation angle.
        /// </param>
        /// <param name="skew">
        ///     Skew factor.
        /// </param>
        /// <param name="distortion">
        ///     Distortion factor.
        /// </param>
        public DotPolygon(
            int? sides = null,
            bool? regular = null,
            int? peripheries = null,
            double? rotation = null,
            double? skew = null,
            double? distortion = null)
        {
            Sides = sides;
            Regular = regular;
            Peripheries = peripheries;
            Rotation = rotation;
            Skew = skew;
            Distortion = distortion;
        }

        /// <summary>
        ///     Gets or sets the number of sides.
        /// </summary>
        public virtual int? Sides { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the shape is regular.
        /// </summary>
        public virtual bool? Regular { get; set; }

        /// <summary>
        ///     Gets or sets the number of peripheries.
        /// </summary>
        public virtual int? Peripheries { get; set; }

        /// <summary>
        ///     Gets or sets rotation angle.
        /// </summary>
        public virtual double? Rotation { get; set; }

        /// <summary>
        ///     Gets or sets skew factor.
        /// </summary>
        public virtual double? Skew { get; set; }

        /// <summary>
        ///     Gets or sets distortion factor.
        /// </summary>
        public virtual double? Distortion { get; set; }
    }
}