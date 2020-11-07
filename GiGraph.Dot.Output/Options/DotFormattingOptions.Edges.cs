namespace GiGraph.Dot.Output.Options
{
    /// <summary>
    ///     Customizes output DOT script formatting.
    /// </summary>
    public partial class DotFormattingOptions
    {
        public class EdgeOptions
        {
            /// <summary>
            ///     Gets or sets a value indicating if subgraphs representing a group of endpoints should be written in a single line.
            /// </summary>
            public virtual bool SingleLineSubgraphs { get; set; } = true;
        }
    }
}