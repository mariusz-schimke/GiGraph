using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Output.Options
{
    /// <summary>
    /// The syntax rules used on DOT output generation.
    /// </summary>
    public class DotSyntaxRules
    {
        protected virtual HashSet<string> Keywords { get; }

        protected virtual string AlphabeticIdentifierPattern { get; }
        protected virtual string NumericIdentifierPattern { get; }

        protected virtual IDotTextEscaper IdentifierEscaper { get; }
        protected virtual IDotTextEscaper StringEscaper { get; }
        protected virtual IDotTextEscaper RecordFieldEscaper { get; }

        /// <summary>
        /// Creates a default instance.
        /// </summary>
        public DotSyntaxRules()
        {
            Keywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "node",
                "edge",
                "strict",
                "graph",
                "digraph",
                "subgraph"
            };

            AlphabeticIdentifierPattern = @"^[_a-zA-Z\200-\377]+[_0-9a-zA-Z\200-\377]*$";
            NumericIdentifierPattern = @"^[-]?(\.[0-9]+|[0-9]+(\.[0-9]*)?)$";

            StringEscaper = IdentifierEscaper = new DotTextEscapingPipeline
            {
                new DotBackslashEscaper(),
                new DotQuotationMarkEscaper(),
                new DotLineBreakEscaper()
            };

            RecordFieldEscaper = new DotTextEscapingPipeline((IEnumerable<IDotTextEscaper>) StringEscaper)
            {
                new DotAngleBracketsEscaper(),
                new DotCurlyBracketsEscaper(),
                new DotVerticalBarEscaper(),
                new DotSpaceHtmlEscaper()
            };
        }

        /// <summary>
        /// Determines if the specified word is a keyword.
        /// </summary>
        /// <param name="value">The word to check.</param>
        public virtual bool IsKeyword(string value)
        {
            return Keywords.Contains(value);
        }

        /// <summary>
        /// Determines if the specified value can be used as identifier without quoting.
        /// </summary>
        /// <param name="value">The value to check.</param>
        public virtual bool IsValidIdentifier(string value)
        {
            return value is { } && !IsKeyword(value) &&
                   (
                       Regex.Match(value, AlphabeticIdentifierPattern).Success ||
                       Regex.Match(value, NumericIdentifierPattern).Success
                   );
        }

        /// <summary>
        /// Escapes the specified identifier.
        /// </summary>
        public virtual string EscapeIdentifier(string value)
        {
            return IdentifierEscaper.Escape(value);
        }

        /// <summary>
        /// Escapes the specified string as an attribute value.
        /// </summary>
        public virtual string EscapeString(string value)
        {
            return StringEscaper.Escape(value);
        }

        /// <summary>
        /// Escapes the specified string as a record-based node label.
        /// </summary>
        public virtual string EscapeRecordField(string value)
        {
            return RecordFieldEscaper.Escape(value);
        }
    }
}