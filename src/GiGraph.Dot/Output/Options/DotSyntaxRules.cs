using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using GiGraph.Dot.Output.Text.Escaping;
using GiGraph.Dot.Output.Text.Escaping.Pipelines;

namespace GiGraph.Dot.Output.Options;

/// <summary>
///     The syntax rules used on DOT output generation.
/// </summary>
public partial class DotSyntaxRules
{
    /// <summary>
    ///     Gets the default syntax rules.
    /// </summary>
    public static DotSyntaxRules Default { get; } = new();

    /// <summary>
    ///     The collection of reserved words that cannot be used as identifiers/keys unless quoted.
    /// </summary>
    public ICollection<string> Keywords { get; set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "graph",
        "node",
        "edge",
        "subgraph",
        "strict",
        "digraph"
    };

    /// <summary>
    ///     The regex pattern to use in order to determine if an alphabetic identifier or attribute value can be used without quoting.
    /// </summary>
    public string AlphabeticIdentifierPattern { get; set; } = @"^[_a-zA-Z\200-\377]+[_0-9a-zA-Z\200-\377]*$";

    /// <summary>
    ///     The regex pattern to use in order to determine if a numeric identifier or attribute value can be used without quoting.
    /// </summary>
    public string NumericIdentifierPattern { get; set; } = @"^[-]?(\.[0-9]+|[0-9]+(\.[0-9]*)?)$";

    /// <summary>
    ///     A text escaper to use for identifiers (only quotation marks and trailing backslashes are escaped by default).
    /// </summary>
    public IDotTextEscaper IdentifierEscaper { get; set; } = DotTextEscapingPipeline.ForString();

    /// <summary>
    ///     The culture info to use for writing numbers, especially floating-point numbers.
    /// </summary>
    public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

    /// <summary>
    ///     Attribute-related syntax rules.
    /// </summary>
    public AttributeRules Attributes { get; } = new();

    /// <summary>
    ///     Determines if the specified word is a keyword.
    /// </summary>
    /// <param name="value">
    ///     The word to check.
    /// </param>
    public virtual bool IsKeyword(string value) => Keywords.Contains(value);

    /// <summary>
    ///     Determines if the specified value can be used as identifier without quoting.
    /// </summary>
    /// <param name="value">
    ///     The value to check.
    /// </param>
    public virtual bool IsValidIdentifier(string value) =>
        value is not null &&
        !IsKeyword(value) &&
        (
            Regex.Match(value, AlphabeticIdentifierPattern).Success ||
            Regex.Match(value, NumericIdentifierPattern).Success
        );
}