using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.LineBreak.Attributes
{
    /// <summary>
    ///     The attributes of an HTML line break.
    /// </summary>
    public interface IDotHtmlLineBreakAttributes
    {
        /// <summary>
        ///     Specifies horizontal placement of the line.
        /// </summary>
        DotHorizontalAlignment? HorizontalAlignment { get; set; }
    }
}