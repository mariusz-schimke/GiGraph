using System;

namespace Dotless.TextEscaping
{
    public class LineBreakEscaper : ITextEscaper
    {
        protected static readonly char CR = Convert.ToChar(0xD);
        protected static readonly char LF = Convert.ToChar(0xA);

        public virtual string? Escape(string? value)
        {
            return value
                ?.Replace($"{CR}{LF}", @"\n")
                ?.Replace($"{CR}", @"\n")
                ?.Replace($"{LF}", @"\n");
        }
    }
}
