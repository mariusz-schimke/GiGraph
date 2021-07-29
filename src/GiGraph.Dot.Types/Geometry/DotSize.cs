namespace GiGraph.Dot.Types.Geometry
{
    /// <summary>
    ///     Size properties.
    /// </summary>
    public class DotSize
    {
        /// <summary>
        ///     Creates a new size instance.
        /// </summary>
        /// <param name="width">
        ///     The width to set.
        /// </param>
        /// <param name="height">
        ///     The height to set.
        /// </param>
        public DotSize(double? width = null, double? height = null)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        ///     Gets or sets the width.
        /// </summary>
        public virtual double? Width { get; set; }

        /// <summary>
        ///     Gets or sets the height.
        /// </summary>
        public virtual double? Height { get; set; }
    }
}