using System;

namespace GiGraph.Dot.Output.Options
{
    public static class DotFormattingOptionsExtension
    {
        public static string Indentation(this DotFormattingOptions options, int level = 0)
        {
            return options.SingleLine
                ? string.Empty
                : string.Empty.PadRight(options.Indentation * level, options.IndentChar);
        }

        public static string Space(this DotFormattingOptions options)
        {
            return string.Empty.PadRight(1);
        }

        public static string LineBreak(this DotFormattingOptions options)
        {
            return options.SingleLine
                ? options.Space()
                : options.LineBreak;
        }

        public static string[] SplitMultilineText(this DotFormattingOptions options, string text)
        {
            if (text is null)
            {
                return new string[0];
            }

            return text.Split(new[] { options.LineBreak }, StringSplitOptions.None);
        }
    }
}