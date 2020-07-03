namespace GiGraph.Dot.Output.Options
{
    public partial class DotGenerationOptions
    {
        public class CommentOptions
        {
            /// <summary>
            ///     Gets or sets the value indicating if the annotations (comments) of elements should be included in the output DOT script.
            /// </summary>
            public virtual bool Enabled { get; set; } = true;

            /// <summary>
            ///     When set, block comments are used (/* */) instead of single line comments (//). When the output DOT script is written as a
            ///     single line, block comments are used even if the property is not set.
            /// </summary>
            public virtual bool PreferBlockComments { get; set; } = false;
        }
    }
}