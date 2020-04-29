using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dotless.Core
{
    public class DotSyntaxRules
    {
        public string AlphabeticIdentifierPattern { get; set; } = @"^[_a-zA-Z\200-\377]+[_0-9a-zA-Z\200-\377]*$";
        public string NumericIdentifierPattern { get; set; } = @"^[-]?(\.[0-9]+|[0-9]+(\.[0-9]*)?)$";

        public HashSet<string> Keywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            // TODO: verify all keywords
            "node",
            "strict",
            "graph",
            "subgraph"
        };

        public virtual bool IsKeyword(string value)
        {
            return Keywords.Contains(value);
        }

        public virtual bool IsValidIdentifier(string value)
        {
            return !IsKeyword(value) &&
                Regex.Match(value, AlphabeticIdentifierPattern, RegexOptions.IgnoreCase).Success ||
                Regex.Match(value, NumericIdentifierPattern, RegexOptions.IgnoreCase).Success;
        }
    }
}
