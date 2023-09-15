namespace GiGraph.Dot.Types.EscapeString;

public abstract partial class DotEscapeString
{
    /// <summary>
    ///     An escape sequence replaced with graph identifier on graph visualization.
    /// </summary>
    public static readonly DotEscapeString GraphIdPlaceholder = (DotEscapedString) "\\G";

    /// <summary>
    ///     An escape sequence replaced with the identifier of the current node on graph visualization.
    /// </summary>
    public static readonly DotEscapeString NodeIdPlaceholder = (DotEscapedString) "\\N";

    /// <summary>
    ///     An escape sequence replaced with the definition of the current edge on graph visualization.
    /// </summary>
    public static readonly DotEscapeString EdgeDefinitionPlaceholder = (DotEscapedString) "\\E";

    /// <summary>
    ///     An escape sequence replaced with the identifier of the tail node of the current edge on graph visualization.
    /// </summary>
    public static readonly DotEscapeString TailNodeIdPlaceholder = (DotEscapedString) "\\T";

    /// <summary>
    ///     An escape sequence replaced with the identifier of the head node of the current edge on graph visualization.
    /// </summary>
    public static readonly DotEscapeString HeadNodeIdPlaceholder = (DotEscapedString) "\\H";

    /// <summary>
    ///     An escape sequence replaced with the label of the current element on graph visualization.
    /// </summary>
    public static readonly DotEscapeString LabelPlaceholder = (DotEscapedString) "\\L";

    /// <summary>
    ///     An escape sequence interpreted as a line break.
    /// </summary>
    public static readonly DotEscapeString LineBreak = (DotEscapedString) "\\n";

    /// <summary>
    ///     An escape sequence that causes the line of text that precedes it to be left-justified. It is treated as a line break at the
    ///     same time.
    /// </summary>
    public static readonly DotEscapeString LeftJustificationLineBreak = (DotEscapedString) "\\l";

    /// <summary>
    ///     An escape sequence that causes the line of text that precedes it to be right-justified. It is treated as a line break at the
    ///     same time.
    /// </summary>
    public static readonly DotEscapeString RightJustificationLineBreak = (DotEscapedString) "\\r";
}