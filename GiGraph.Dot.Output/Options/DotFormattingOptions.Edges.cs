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
        }
    }
}