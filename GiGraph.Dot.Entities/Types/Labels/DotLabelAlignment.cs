using GiGraph.Dot.Entities.Types.Alignment;
using GiGraph.Dot.Entities.Types.Mappers;

namespace GiGraph.Dot.Entities.Types.Labels
{
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
            : this(
                DotPartialEnumMapper.ToPartial<DotAlignment, DotHorizontalAlignment>(alignment),
                DotPartialEnumMapper.ToPartial<DotAlignment, DotVerticalAlignment>(alignment)
            )
        {
        }

        /// <summary>
        ///     Horizontal label alignment.
        /// </summary>
        public virtual DotHorizontalAlignment? Horizontal { get; set; }

        /// <summary>
        ///     Vertical label alignment.
        /// </summary>
        public virtual DotVerticalAlignment? Vertical { get; set; }
    }
}