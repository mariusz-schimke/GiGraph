using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Mappers;

namespace GiGraph.Dot.Entities.Labels
{
    // TODO: Change from class to record?
    // Should properties remain settable then?

    /// <summary>
    ///     Label alignment properties.
    /// </summary>
    public class DotLabelAlignment
    {
        /// <summary>
        ///     Initializes a new label alignment instance.
        /// </summary>
        public DotLabelAlignment()
        {
        }

        /// <summary>
        ///     Initializes a new label alignment instance.
        /// </summary>
        /// <param name="horizontal">
        ///     The horizontal alignment to set.
        /// </param>
        /// <param name="vertical">
        ///     The vertical alignment to set.
        /// </param>
        public DotLabelAlignment(DotHorizontalAlignment? horizontal, DotVerticalAlignment? vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }

        /// <summary>
        ///     Initializes a new label alignment instance.
        /// </summary>
        /// <param name="alignment">
        ///     The alignment to set.
        /// </param>
        public DotLabelAlignment(DotAlignment alignment)
        {
            Set(alignment);
        }

        /// <summary>
        ///     Horizontal label alignment.
        /// </summary>
        public virtual DotHorizontalAlignment? Horizontal { get; set; }

        /// <summary>
        ///     Vertical label alignment.
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