namespace GiGraph.Dot.Types.Graphs.Charset;

/// <summary>
///     Specifies the charsets supported by Graphviz.
/// </summary>
public class DotCharsets
{
    /// <summary>
    ///     The UTF-8 charset. The legal equivalent values are: "utf-8", "utf8".
    /// </summary>
    public const string Utf8 = "utf-8";

    /// <summary>
    ///     The Latin-1 charset. The legal equivalent values are: "iso-8859-1", "ISO_8859-1", "ISO8859-1", "ISO-IR-100", "Latin1", "l1",
    ///     "latin-1".
    /// </summary>
    public const string Latin1 = "latin-1";

    /// <summary>
    ///     <see href="https://en.wikipedia.org/wiki/Big5">
    ///         The Big-5 Chinese encoding
    ///     </see>
    ///     . The legal equivalent values are: "big-5", "big5".
    /// </summary>
    public const string Big5 = "big-5";
}