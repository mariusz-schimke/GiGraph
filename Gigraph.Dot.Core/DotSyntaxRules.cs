using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Gigraph.Dot.Core
{
    public class DotSyntaxRules
    {
        protected readonly HashSet<string> _keywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "node",
            "edge",
            "strict",
            "graph",
            "digraph",
            "subgraph"
        };

        public virtual string AlphabeticIdentifierPattern => @"^[_a-zA-Z\200-\377]+[_0-9a-zA-Z\200-\377]*$";
        public virtual string NumericIdentifierPattern => @"^[-]?(\.[0-9]+|[0-9]+(\.[0-9]*)?)$";

        public virtual HashSet<string> Keywords => _keywords;

        public virtual bool IsKeyword(string value)
        {
            return Keywords.Contains(value);
        }

        public virtual bool IsValidIdentifier(string value)
        {
            return !IsKeyword(value) &&
                Regex.Match(value, AlphabeticIdentifierPattern).Success ||
                Regex.Match(value, NumericIdentifierPattern).Success;
        }
    }
}
