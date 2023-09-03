namespace GiGraph.Dot.Output.Options;

public partial class DotSyntaxOptions
{
    public class EdgeOptions
    {
        /// <summary>
        ///     When set, subgraphs used as groups of endpoints will always be preceded with the 'subgraph' keyword, even when it is not
        ///     required.
        /// </summary>
        public bool PreferExplicitSubgraphDeclaration { get; set; } = false;
    }
}