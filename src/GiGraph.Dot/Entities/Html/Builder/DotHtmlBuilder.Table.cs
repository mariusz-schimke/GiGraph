using GiGraph.Dot.Entities.Html.Table;

namespace GiGraph.Dot.Entities.Html.Builder;

public partial class DotHtmlBuilder
{
    /// <summary>
    ///     Appends a table to this instance and builds its content.
    /// </summary>
    /// <param name="init">
    ///     A table initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder AppendTable(Action<DotHtmlTable>? init) => AppendEntity([], init);
}