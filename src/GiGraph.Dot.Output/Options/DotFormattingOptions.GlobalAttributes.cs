namespace GiGraph.Dot.Output.Options
{
    public partial class DotFormattingOptions
    {
        public class GlobalAttributesOptions
        {
            /// <summary>
            ///     Gets or sets a value indicating if global graph attributes should be written inline (assuming that the
            ///     <see cref="DotSyntaxOptions.AttributeOptions.PreferGraphAttributesAsStatements" /> option of <see cref="DotSyntaxOptions" />
            ///     is false).
            /// </summary>
            public virtual bool SingleLineGraphAttributeList { get; set; } = true;

            /// <summary>
            ///     Gets or sets a value indicating if global node attributes should be written in a single line.
            /// </summary>
            public virtual bool SingleLineNodeAttributeList { get; set; } = true;

            /// <summary>
            ///     Gets or sets a value indicating if global edge attributes should be written in a single line.
            /// </summary>
            public virtual bool SingleLineEdgeAttributeList { get; set; } = true;

            /// <summary>
            ///     Gets or sets a value indicating if global graph, node, and edge attributes should be written in single lines.
            /// </summary>
            public virtual bool SingleLineAttributeLists
            {
                get => SingleLineGraphAttributeList && SingleLineNodeAttributeList && SingleLineEdgeAttributeList;
                set => SingleLineGraphAttributeList = SingleLineNodeAttributeList = SingleLineEdgeAttributeList = value;
            }
        }
    }
}