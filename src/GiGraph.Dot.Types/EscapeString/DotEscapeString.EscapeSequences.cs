namespace GiGraph.Dot.Types.EscapeString
{
    public abstract partial class DotEscapeString
    {
        /// <summary>
        ///     An escape sequence replaced with graph identifier on graph visualization.
        /// </summary>
        public static readonly DotEscapeString GraphId = (DotEscapedString) "\\G";

        /// <summary>
        ///     An escape sequence replaced with the identifier of the current node on graph visualization.
        /// </summary>
        public static readonly DotEscapeString NodeId = (DotEscapedString) "\\N";

        /// <summary>
        ///     An escape sequence replaced with the definition of the current edge on graph visualization.
        /// </summary>
        public static readonly DotEscapeString EdgeDefinition = (DotEscapedString) "\\E";

        /// <summary>
        ///     An escape sequence replaced with the identifier of the tail node of the current edge on graph visualization.
        /// </summary>
        public static readonly DotEscapeString TailNodeId = (DotEscapedString) "\\T";

        /// <summary>
        ///     An escape sequence replaced with the identifier of the head node of the current edge on graph visualization.
        /// </summary>
        public static readonly DotEscapeString HeadNodeId = (DotEscapedString) "\\H";

        /// <summary>
        ///     An escape sequence replaced with the label of the current element on graph visualization.
        /// </summary>
        public static readonly DotEscapeString Label = (DotEscapedString) "\\L";

        /// <summary>
        ///     An escape sequence interpreted as a line break.
        /// </summary>
        public static readonly DotEscapeString LineBreak = (DotEscapedString) "\\n";

        /// <summary>
        ///     An escape sequence that causes the line of text that precedes it to be left-justified.
        /// </summary>
        public static readonly DotEscapeString LeftJustification = (DotEscapedString) "\\l";

        /// <summary>
        ///     An escape sequence that causes the line of text that precedes it to be right-justified.
        /// </summary>
        public static readonly DotEscapeString RightJustification = (DotEscapedString) "\\r";
    }
}