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

        public static string Alignment(this DotTokenWriterOptions options, int width)
        {
            return options.SingleLine
                ? string.Empty
                : options.Space(width);
        }

        public static string Space(this DotTokenWriterOptions options)
        {
            return options.Space(1);
        }

        private static string Space(this DotTokenWriterOptions options, int count)
        {
            return string.Empty.PadRight(count);
        }

        public static string LineBreak(this DotTokenWriterOptions options)
        {
            return options.SingleLine
                ? options.Space()
                : options.LineBreak;
        }

        public static string[] SplitMultilineText(this DotTokenWriterOptions options, string text)
        {
            return text is null
                ? Array.Empty<string>()
                : text.Split(new[] { options.LineBreak }, StringSplitOptions.None);
        }
    }
}