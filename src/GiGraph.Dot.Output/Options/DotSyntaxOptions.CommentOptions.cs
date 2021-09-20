namespace GiGraph.Dot.Output.Options
{
    public partial class DotSyntaxOptions
    {
        public class CommentOptions
        {
            /// <summary>
            ///     Gets or sets the value indicating if the annotations (comments) of elements should be included in the output DOT script.
            /// </summary>
            public bool Enabled { get; set; } = true;

            /// <summary>
            ///     When set, block comments are used (/* */) instead of single line comments (//). When the output DOT script is written as a
            ///     single line, block comments are used even if the property is not set.
            /// </summary>
            public bool PreferBlockComments { get; set; } = false;

            /// <summary>
            ///     When set, a hash (#) is used for single line comments instead of a double slash (//).
            /// </summary>
            public bool PreferHashForSingleLineComments { get; set; } = false;
        }
    }
}