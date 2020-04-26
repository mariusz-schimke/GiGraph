using System;

namespace Dotless.Generators
{

    public class GeneratorOptions
    {
        public bool SingleLine { get; set; } = false;
        public bool Indent { get; set; } = true;
        public char IndentChar { get; set; } = ' ';
        public int Indentation { get; set; } = 2;
        public int BaseIndentation { get; set; } = 0;
        public int TokenSpacing { get; set; } = 1;
        public string LineBreak { get; set; } = Environment.NewLine;

        public GeneratorOptions()
        {
        }

        public GeneratorOptions(bool singleLine, bool indent, char indentChar, int indentation, int baseIndentation, int tokenSpacing, string lineBreak)
        {
            SingleLine = singleLine;
            Indent = indent;
            IndentChar = indentChar;
            Indentation = indentation;
            BaseIndentation = baseIndentation;
            TokenSpacing = tokenSpacing;
            LineBreak = lineBreak;
        }

        public GeneratorOptions IncreaseBaseIndentation()
        {
            return new GeneratorOptions(SingleLine, Indent, IndentChar, Indentation, BaseIndentation + Indentation, TokenSpacing, LineBreak);
        }
    }
}
