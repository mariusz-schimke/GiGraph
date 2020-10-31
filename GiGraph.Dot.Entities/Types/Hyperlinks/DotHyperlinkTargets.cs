namespace GiGraph.Dot.Entities.Types.Hyperlinks
{
    /// <summary>
    ///     Specifies where to open linked documents.
    /// </summary>
    public class DotHyperlinkTargets
    {
        /// <summary>
        ///     Opens a new window if it doesn't already exist, or reuses it if it does.
        /// </summary>
        public static string NewWindow => "_graphviz";
    }
}