namespace GiGraph.Dot.Output.Options;

public partial class DotSyntaxOptions
{
    public class SubgraphOptions
    {
        /// <summary>
        ///     When set, subgraphs will always be preceded with the 'subgraph' keyword, even when it is not required.
        /// </summary>
        public bool PreferExplicitDeclaration { get; set; } = false;

        /// <summary>
        ///     When true, subgraph attributes will be written as separate statements. When false, the "graph [attr_list]" format will be
        ///     used instead.
        /// </summary>
        public bool AttributesAsStatements { get; set; } = true;
    }
}