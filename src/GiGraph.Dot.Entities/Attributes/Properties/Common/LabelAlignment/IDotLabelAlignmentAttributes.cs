using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.LabelAlignment
{
    public interface IDotLabelAlignmentAttributes
    {
        /// <summary>
        ///     Justification for the label. Note that clusters inherit attributes from their parent. Thus, if the root graph sets this
        ///     attribute to <see cref="DotHorizontalAlignment.Left" />, clusters inherit this value. Default:
        ///     <see cref="DotHorizontalAlignment.Center" />.
        /// </summary>
        DotHorizontalAlignment? Horizontal { get; set; }

        /// <summary>
        ///     Vertical placement of the label (default: <see cref="DotVerticalAlignment.Top" />; only
        ///     <see cref="DotVerticalAlignment.Top" /> and <see cref="DotVerticalAlignment.Bottom" /> are allowed). Note that clusters
        ///     inherit attributes from their parent. Thus, if the root graph sets this attribute to
        ///     <see cref="DotVerticalAlignment.Bottom" />, clusters inherits this value.
        /// </summary>
        DotVerticalAlignment? Vertical { get; set; }
    }
}