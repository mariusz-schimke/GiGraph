using System;

namespace Dotless.DotBuilders
{
    public class TokenWriterOptions
    {
        public bool SingleLine { get; set; } = false;
        public bool Indent { get; set; } = true;
        public char IndentChar { get; set; } = ' ';
        public int Indentation { get; set; } = 4;
        public int BaseIndentation { get; set; } = 0;
        public int TokenSpacing { get; set; } = 1;
        public string LineBreak { get; set; } = Environment.NewLine;
    }
}
