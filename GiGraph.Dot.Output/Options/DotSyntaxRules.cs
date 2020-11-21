using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Output.Options
{
    /// <summary>
    ///     The syntax rules used on DOT output generation.
    /// </summary>
    public partial class DotSyntaxRules
    {
        public static readonly IDotTextEscaper DefaultStringEscaper = new DotTextEscapingPipeline
        (
            // When a single backslash is quoted ("\"), it is misinterpreted as an escape character for the closing quotation mark,
            // so it has to be escaped ("\\"). Escaping backslashes seems to be redundant apart from that specific case
            // (unless this is an escString type attribute).
            new DotBackslashEscaper(),
            // quotation mark would make a quoted string invalid, so has to be escaped
            new DotQuotationMarkEscaper()
        );

        /// <summary>
        ///     The collection of reserved words that cannot be used as identifiers/keys unless quoted.
        /// </summary>
        public virtual ICollection<string> Keywords { get; set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
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
        public virtual string AlphabeticIdentifierPattern { get; set; } = @"^[_a-zA-Z\200-\377]+[_0-9a-zA-Z\200-\377]*$";

        /// <summary>
        ///     The regex pattern to use in order to determine if a numeric identifier or attribute value can be used without quoting.
        /// </summary>
        public virtual string NumericIdentifierPattern { get; set; } = @"^[-]?(\.[0-9]+|[0-9]+(\.[0-9]*)?)$";

        /// <summary>
        ///     A text escaper to use for identifiers (only quotation marks and backslashes are escaped by default).
        /// </summary>
        public virtual IDotTextEscaper IdentifierEscaper { get; set; } = DefaultStringEscaper;

        /// <summary>
        ///     Attribute-related syntax rules.
        /// </summary>
        public virtual AttributeRules Attributes { get; } = new AttributeRules();

        /// <summary>
        ///     Determines if the specified word is a keyword.
        /// </summary>
        /// <param name="value">
        ///     The word to check.
        /// </param>
        public virtual bool IsKeyword(string value)
        {
            return Keywords.Contains(value);
        }

        /// <summary>
        ///     Determines if the specified value can be used as identifier without quoting.
        /// </summary>
        /// <param name="value">
        ///     The value to check.
        /// </param>
        public virtual bool IsValidIdentifier(string value)
        {
            return value is { } && !IsKeyword(value) &&
                   (
                       Regex.Match(value, AlphabeticIdentifierPattern).Success ||
                       Regex.Match(value, NumericIdentifierPattern).Success
                   );
        }
    }
}