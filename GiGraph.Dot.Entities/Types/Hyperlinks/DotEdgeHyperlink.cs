using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Types.Hyperlinks
{
    /// <summary>
    ///     Specifies hyperlink properties (edge specific).
    /// </summary>
    public class DotEdgeHyperlink : DotHyperlink
    {
        /// <summary>
        ///     The tooltip annotation.
        /// </summary>
        public DotEscapeString Tooltip { get; set; }
    }
}