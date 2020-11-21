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
        protected static readonly IDotTextEscaper DefaultStringEscaper = new DotTextEscapingPipeline
        (
            // backslash is an escape character, and has to be escaped to be interpreted as a backslash
            new DotBackslashEscaper(),
            // quotation mark would make a quoted string invalid, so has to be escaped
            new DotQuotationMarkEscaper()
        );

        /// <summary>
        ///     The collection of reserved words that cannot be used as identifiers/keys unless quoted.
        /// </summary>
        public virtual ICollection<string> Keywords { get; protected set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "node",
            "edge",
            "strict",
            "graph",
            "digraph",
            "subgraph"
        };

        /// <summary>
        ///     The regex pattern to use in order to determine if an alphabetic identifier or attribute value can be used without quoting.
        /// </summary>
        public virtual string AlphabeticIdentifierPattern { get; protected set; } = @"^[_a-zA-Z\200-\377]+[_0-9a-zA-Z\200-\377]*$";

        /// <summary>
        ///     The regex pattern to use in order to determine if a numeric identifier or attribute value can be used without quoting.
        /// </summary>
        public virtual string NumericIdentifierPattern { get; protected set; } = @"^[-]?(\.[0-9]+|[0-9]+(\.[0-9]*)?)$";

        /// <summary>
        ///     A text escaper to use for identifiers (only quotation marks and backslashes are escaped by default).
        /// </summary>
        public virtual IDotTextEscaper IdentifierEscaper { get; protected set; } = DefaultStringEscaper;

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