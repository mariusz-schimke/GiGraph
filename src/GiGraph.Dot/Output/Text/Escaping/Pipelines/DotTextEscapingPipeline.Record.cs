namespace GiGraph.Dot.Output.Text.Escaping.Pipelines;

public partial class DotTextEscapingPipeline
{
    /// <summary>
    ///     Creates a new pipeline that escapes fields of record labels (backslashes, quotation marks, line breaks; angle and curly
    ///     brackets, vertical bars, and spaces).
    /// </summary>
    public static DotTextEscapingPipeline ForRecordLabelField() => new(ForEscapeString(), CommonForRecordLabel());

    /// <summary>
    ///     Creates a new pipeline that escapes ports of record labels (backslashes, quotation marks; angle and curly brackets, vertical
    ///     bars, and spaces).
    /// </summary>
    public static DotTextEscapingPipeline ForRecordLabelPort()
    {
        return new(
            // when a port string ends with a backslash (<...\>), the closing angle bracket is interpreted as a content character,
            // so the backslash has to be escaped
            ForString(),
            CommonForRecordLabel()
        );
    }

    protected static DotTextEscapingPipeline CommonForRecordLabel()
    {
        return new(
            new DotAngleBracketsEscaper(),
            new DotCurlyBracketsEscaper(),
            new DotVerticalBarEscaper(),
            new DotSpacePaddingEscaper(),
            new DotSpaceEscaper()
        );
    }
}