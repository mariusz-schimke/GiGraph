using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Output.Options
{
    /// <summary>
    ///     The syntax rules used on DOT output generation.
    /// </summary>
    public class DotSyntaxRules
    {
        protected static readonly IDotTextEscaper[] DefaultEscaper =
        {
            new DotBackslashEscaper(),
            new DotQuotationMarkEscaper(),
            new DotLineBreakEscaper()
        };

        /// <summary>
        ///     The collection of keywords that cannot be used as node identifiers unless quoted.
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
        ///     A text escaper to use for identifiers.
        /// </summary>
        public virtual IDotTextEscaper IdentifierEscaper { get; protected set; } = new DotTextEscapingPipeline(DefaultEscaper);

        /// <summary>
        ///     A text escaper to use for attribute keys (no escaping is used by default).
        /// </summary>
        public virtual IDotTextEscaper KeyEscaper { get; protected set; } = DotTextEscapingPipeline.None();

        /// <summary>
        ///     A text escaper to use for string values.
        /// </summary>
        public virtual IDotTextEscaper StringValueEscaper { get; protected set; } = new DotTextEscapingPipeline(DefaultEscaper);

        /// <summary>
        ///     A text escaper to use for record node fields.
        /// </summary>
        public virtual IDotTextEscaper RecordFieldEscaper { get; protected set; } = new DotTextEscapingPipeline(DefaultEscaper)
        {
            new DotAngleBracketsEscaper(),
            new DotCurlyBracketsEscaper(),
            new DotVerticalBarEscaper(),
            new DotSpaceHtmlEscaper()
        };

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

        /// <summary>
        ///     Escapes the specified identifier.
        /// </summary>
        public virtual string EscapeIdentifier(string value)
        {
            return IdentifierEscaper.Escape(value);
        }

        /// <summary>
        ///     Escapes the specified string as an attribute key.
        /// </summary>
        public virtual string EscapeKey(string key)
        {
            return KeyEscaper.Escape(key);
        }

        /// <summary>
        ///     Escapes the specified string as an attribute value.
        /// </summary>
        public virtual string EscapeStringValue(string value)
        {
            return StringValueEscaper.Escape(value);
        }

        /// <summary>
        ///     Escapes the specified string as a record-based node label.
        /// </summary>
        public virtual string EscapeRecordField(string value)
        {
            return RecordFieldEscaper.Escape(value);
        }
    }
}