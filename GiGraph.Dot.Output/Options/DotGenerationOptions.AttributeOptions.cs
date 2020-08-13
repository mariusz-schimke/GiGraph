namespace GiGraph.Dot.Output.Options
{
    public partial class DotGenerationOptions
    {
        public class AttributeOptions
        {
            /// <summary>
            ///     When set, keys will always be quoted, even if it is not required.
            /// </summary>
            public virtual bool PreferQuotedKey { get; set; } = false;

            /// <summary>
            ///     When set, attribute value will always be quoted, even if it is not required.
            /// </summary>
            public virtual bool PreferQuotedValue { get; set; } = false;

            /// <summary>
            ///     When true, attributes enclosed in square brackets (e.g. node attributes), will be separated with colons (,). When false, they
            ///     will be separated with spaces.
            /// </summary>
            public virtual bool PreferExplicitSeparator { get; set; } = true;

            /// <summary>
            ///     When true, graph, subgraph, and cluster attributes will be written as separate statements. When false, the "graph
            ///     [attr_list]" format will be used instead.
            /// </summary>
            public virtual bool PreferGraphAttributesAsStatements { get; set; } = true;
        }
    }
}