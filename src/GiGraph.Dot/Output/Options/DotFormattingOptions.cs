using GiGraph.Dot.Output.Text;

namespace GiGraph.Dot.Output.Options;

/// <summary>
///     Customizes DOT output formatting.
/// </summary>
public partial class DotFormattingOptions
{
    /// <summary>
    ///     Gets the default formatting options.
    /// </summary>
    public static DotFormattingOptions Default { get; } = new();

    /// <summary>
    ///     Indicates if the output should be generated without line breaks.
    /// </summary>
    public bool SingleLine { get; set; }

    /// <summary>
    ///     The base indentation level for the DOT output.
    /// </summary>
    public int IndentationLevel { get; set; }

    /// <summary>
    ///     The indentation size.
    /// </summary>
    public int IndentationSize { get; set; } = 4;

    /// <summary>
    ///     Determines what character to use for indentation (space by default).
    /// </summary>
    public char IndentationChar { get; set; } = ' ';

    /// <summary>
    ///     The line break sequence to use in the DOT output (a system-dependent line break sequence is used by default; see also
    ///     <see cref="DotNewLine" />).
    /// </summary>
    public string LineBreak { get; set; } = DotNewLine.SystemDefault;

    /// <summary>
    ///     Gets global attribute formatting options.
    /// </summary>
    public GlobalAttributesOptions GlobalAttributes { get; } = new();

    /// <summary>
    ///     Gets subgraph formatting options.
    /// </summary>
    public SubgraphOptions Subgraphs { get; } = new();

    /// <summary>
    ///     Gets cluster formatting options.
    /// </summary>
    public ClusterOptions Clusters { get; } = new();

    /// <summary>
    ///     Gets edge formatting options.
    /// </summary>
    public EdgeOptions Edges { get; } = new();

    /// <summary>
    ///     Gets node formatting options.
    /// </summary>
    public NodeOptions Nodes { get; } = new();

    /// <summary>
    ///     An optional text encoder to use when writing text to the output stream. May become useful when the DOT visualization tool you
    ///     use fails processing some special or national characters. In such case replacing them with their HTML-code equivalents might
    ///     help.
    /// </summary>
    public Func<string?, DotTokenType, string?>? TextEncoder { get; set; }

    /// <summary>
    ///     Causes attribute lists of all types of elements to be written inline.
    /// </summary>
    public virtual DotFormattingOptions SingleLineAttributeLists() => SingleLineAttributeLists(true);

    /// <summary>
    ///     Causes attribute lists of all types of elements to be written in multiple lines (one attribute per line).
    /// </summary>
    public virtual DotFormattingOptions MultilineAttributeLists() => SingleLineAttributeLists(false);

    protected virtual DotFormattingOptions SingleLineAttributeLists(bool value)
    {
        GlobalAttributes.SingleLineAttributeLists = value;
        Nodes.SingleLineAttributeLists = value;
        Edges.SingleLineAttributeLists = value;
        return this;
    }
}