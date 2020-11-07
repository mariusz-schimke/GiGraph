using System;

namespace GiGraph.Dot.Output.Writers.Options
{
    public static class DotTokenWriterOptionsExtension
    {
        public static string Indentation(this DotTokenWriterOptions options)
        {
            return options.SingleLine
                ? string.Empty
                : string.Empty.PadRight(options.IndentationSize * options.IndentationLevel, options.IndentationChar);
        }

        public static string Space(this DotTokenWriterOptions options)
        {
            return string.Empty.PadRight(1);
        }

        public static string LineBreak(this DotTokenWriterOptions options)
        {
            return options.SingleLine
                ? options.Space()
                : options.LineBreak;
        }

        public static string[] SplitMultilineText(this DotTokenWriterOptions options, string text)
        {
            if (text is null)
            {
                return new string[0];
            }

            return text.Split(new[] { options.LineBreak }, StringSplitOptions.None);
        }
    }
}