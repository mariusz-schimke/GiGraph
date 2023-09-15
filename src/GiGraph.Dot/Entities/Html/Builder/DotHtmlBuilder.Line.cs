using GiGraph.Dot.Entities.Html.LineBreak;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Builder;

public partial class DotHtmlBuilder
{
    /// <summary>
    ///     Appends a line of text to this instance and optionally sets alignment for its individual lines if the text is composed of
    ///     multiple lines.
    /// </summary>
    /// <param name="text">
    ///     The text to append.
    /// </param>
    /// <param name="lineAlignment">
    ///     Specifies horizontal placement of the line.
    /// </param>
    public virtual DotHtmlBuilder AppendLine(string text, DotHorizontalAlignment? lineAlignment = null)
    {
        AppendText(text, lineAlignment);
        return AppendLine(lineAlignment);
    }

    /// <summary>
    ///     Appends a line break to this instance.
    /// </summary>
    /// <param name="lineAlignment">
    ///     Specifies horizontal placement of the preceding line of text.
    /// </param>
    public virtual DotHtmlBuilder AppendLine(DotHorizontalAlignment? lineAlignment = null) => AppendEntity(DotHtmlLineBreak.Instance(lineAlignment));
}