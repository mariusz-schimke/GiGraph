namespace GiGraph.Dot.Entities.Types.Geometry
{
    /// <summary>
    ///     Geometry properties of a polygonal shape.
    /// </summary>
    public class DotPolygon
    {
        /// <summary>
        ///     Gets or sets the number of sides.
        /// </summary>
        public virtual int? Sides { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the shape is regular.
        /// </summary>
        public virtual bool? Regular { get; set; }

        /// <summary>
        ///     Gets or sets skew factor.
        /// </summary>
        public virtual double? Skew { get; set; }

        /// <summary>
        ///     Gets or sets distortion factor.
        /// </summary>
        public virtual double? Distortion { get; set; }

        /// <summary>
        ///     Gets or sets rotation angle.
        /// </summary>
        public virtual double? Rotation { get; set; }
    }
}