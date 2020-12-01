namespace GiGraph.Dot.Output.Options
{
    public partial class DotFormattingOptions
    {
        public class EdgeOptions
        {
            /// <summary>
            ///     Gets or sets a value indicating if subgraphs representing groups of endpoints should be written in single lines.
            /// </summary>
            public virtual bool SingleLineSubgraphs { get; set; } = true;

            /// <summary>
            ///     Gets or sets a value indicating if edge attributes should be written in a single line.
            /// </summary>
            public virtual bool SingleLineAttributeLists { get; set; } = true;
        }
    }
}