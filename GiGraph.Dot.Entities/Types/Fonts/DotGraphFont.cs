namespace GiGraph.Dot.Entities.Types.Fonts
{
    /// <summary>
    ///     Font properties (graph specific).
    /// </summary>
    public class DotGraphFont : DotFont
    {
        /// <summary>
        ///     Gets or sets the directory list to search for fonts.
        /// </summary>
        public string Directories { get; set; }
    }
}