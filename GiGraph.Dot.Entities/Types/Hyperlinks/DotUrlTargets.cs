namespace GiGraph.Dot.Entities.Types.Hyperlinks
{
    /// <summary>
    ///     Provides URL targets for hyperlink attributes.
    /// </summary>
    public class DotUrlTargets
    {
        /// <summary>
        ///     Opens a new window if it doesn't already exist, or reuses it if it does.
        /// </summary>
        public static string NewWindow => "_graphviz";
    }
}