﻿namespace GiGraph.Dot.Output.Options
{
    public partial class DotSyntaxOptions
    {
        public class SubgraphOptions
        {
            /// <summary>
            ///     When set, subgraphs will always be preceded with the 'subgraph' keyword, even when it is not required.
            /// </summary>
            public virtual bool PreferExplicitDeclaration { get; set; } = false;
        }
    }
}