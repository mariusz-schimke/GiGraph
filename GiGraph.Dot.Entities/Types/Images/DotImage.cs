using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Types.Images
{
    /// <summary>
    ///     Image properties.
    /// </summary>
    public class DotImage
    {
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