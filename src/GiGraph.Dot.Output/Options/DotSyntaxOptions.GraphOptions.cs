namespace GiGraph.Dot.Output.Options
{
    public partial class DotSyntaxOptions
    {
        public class GraphOptions
        {
            /// <summary>
            ///     When true, graph attributes will be written as separate statements. When false, the "graph [attr_list]" format will be used
            ///     instead.
            /// </summary>
            public virtual bool AttributesAsStatements { get; set; } = true;
        }
    }
}