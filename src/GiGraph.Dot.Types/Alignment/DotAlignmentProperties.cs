using GiGraph.Dot.Types.Mappers;

namespace GiGraph.Dot.Types.Alignment
{
    // TODO: Change from class to record?
    // Should properties remain settable then?

    /// <summary>
    ///     Alignment properties.
    /// </summary>
    public class DotAlignmentProperties
    {
        /// <summary>
        ///     Initializes a new alignment instance.
        /// </summary>
        public DotAlignmentProperties()
        {
        }

        /// <summary>
        ///     Initializes a new instance.
        /// </summary>
        /// <param name="horizontal">
        ///     The horizontal alignment to set.
        /// </param>
        /// <param name="vertical">
        ///     The vertical alignment to set.
        /// </param>
        public DotAlignmentProperties(DotHorizontalAlignment? horizontal, DotVerticalAlignment? vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }

        /// <summary>
        ///     Initializes a new instance.
        /// </summary>
        /// <param name="alignment">
        ///     The alignment to set.
        /// </param>
        public DotAlignmentProperties(DotAlignment alignment)
        {
            Set(alignment);
        }

        /// <summary>
        ///     Horizontal alignment.
        /// </summary>
        public virtual DotHorizontalAlignment? Horizontal { get; set; }

        /// <summary>
        ///     Vertical alignment.
        /// </summary>
        public virtual DotVerticalAlignment? Vertical { get; set; }

        /// <summary>
        ///     Sets horizontal and vertical alignment.
        /// </summary>
        /// <param name="alignment">
        ///     The alignment to set.
        /// </param>
        public virtual void Set(DotAlignment alignment)
        {
            Horizontal = DotPartialEnumMapper.ToPartial<DotAlignment, DotHorizontalAlignment>(alignment);
            Vertical = DotPartialEnumMapper.ToPartial<DotAlignment, DotVerticalAlignment>(alignment);
        }
    }
}