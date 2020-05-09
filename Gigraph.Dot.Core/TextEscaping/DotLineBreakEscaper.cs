using System;

namespace Gigraph.Dot.Core.TextEscaping
{
    public class DotLineBreakEscaper : IDotTextEscaper
    {
        protected static readonly char CR = '\r';
        protected static readonly char LF = '\n';

        public virtual string Escape(string value)
        {
            return value
                ?.Replace($"{CR}{LF}", @"\n")
                ?.Replace($"{CR}", @"\n")
                ?.Replace($"{LF}", @"\n");
        }
    }
}
