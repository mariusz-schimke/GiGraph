using GiGraph.Dot.Entities.Types.Alignment;

namespace GiGraph.Dot.Entities.Types.Images
{
    /// <summary>
    ///     Image properties.
    /// </summary>
    public class DotImage
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="path">
        ///     Image path.
        /// </param>
        /// <param name="alignment">
        ///     Image alignment.
        /// </param>
        /// <param name="scaling">
        ///     Image scaling.
        /// </param>
        public DotImage(string path = null, DotAlignment? alignment = null, DotImageScaling? scaling = null)
        {
            Path = path;
            Alignment = alignment;
            Scaling = scaling;
        }

        /// <summary>
        ///     Gets or sets image path.
        /// </summary>
        public virtual string Path { get; set; }

        /// <summary>
        ///     Gets or sets image alignment.
        /// </summary>
        public virtual DotAlignment? Alignment { get; set; }

        /// <summary>
        ///     Gets or sets image scaling.
        /// </summary>
        public virtual DotImageScaling? Scaling { get; set; }
    }
}