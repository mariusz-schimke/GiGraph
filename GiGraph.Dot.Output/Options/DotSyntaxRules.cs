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
        public virtual HashSet<string> Keywords { get; }

        public virtual string AlphabeticIdentifierPattern { get; }
        public virtual string NumericIdentifierPattern { get; }

        public virtual IDotTextEscaper IdentifierEscaper { get; }
        public virtual IDotTextEscaper StringEscaper { get; }
        public virtual IDotTextEscaper RecordFieldEscaper { get; }

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

            IdentifierEscaper = DotTextEscapingPipeline.ForIdentifier();
            StringEscaper = DotTextEscapingPipeline.ForString();
            RecordFieldEscaper = DotTextEscapingPipeline.ForRecordNodeField();
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