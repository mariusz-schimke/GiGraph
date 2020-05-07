using System;

namespace Dotless.DotWriters.Options
{
    public static class DotFormattingOptionsExtension
    {
        public static string Indentation(this DotFormattingOptions options, int level = 0)
        {
            return options.SingleLineOutput
                ? string.Empty
                : string.Empty.PadRight(options.Indentation * level, options.IndentChar);
        }

        public static string Space(this DotFormattingOptions options)
        {
            return string.Empty.PadRight(1);
        }

        public static string LineBreak(this DotFormattingOptions options)
        {
            return options.SingleLineOutput
                ? options.Space()
                : options.LineBreak;
        }

        public static string? Text(this DotFormattingOptions options, string? text)
        {
            if (!options.SingleLineOutput || text is null)
            {
                return text;
            }

            var lines = text.Split(options.LineBreak, StringSplitOptions.None);
            return string.Join(options.Space(), lines);
        }
    }
}
