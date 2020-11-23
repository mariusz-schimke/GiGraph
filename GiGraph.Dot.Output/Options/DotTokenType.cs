namespace GiGraph.Dot.Output.Options
{
    /// <summary>
    ///     DOT token type.
    /// </summary>
    public enum DotTokenType
    {
        Keyword,
        Identifier,
        Value,
        ValueAssignmentOperator,
        StringConcatenationOperator,
        StatementDelimiter,
        BlockStart,
        BlockEnd,
        AttributeListStart,
        AttributeListEnd,
        AttributeSeparator,
        QuotationStart,
        QuotationEnd,
        HtmlValueStart,
        HtmlValueEnd,
        HtmlValue,
        DirectedEdge,
        UndirectedEdge,
        NodeSeparator,
        NodePortSeparator,
        CommentStart,
        CommentText,
        BlockCommentStart,
        BlockCommentEnd,
        BlockCommentText,
        LineBreak,
        Space,
        Indentation
    }
}