using System;

namespace Dotless.DotWriters.Options
{
    public static class DotFormattingOptionsExtension
    {
        public static string Indentation(this DotFormattingOptions options)
        {
            return options.Indent
                ? string.Empty.PadRight(options.Indentation)
                : string.Empty;
        }

        public static string TokenSpace(this DotFormattingOptions options)
        {
            return string.Empty.PadRight(1);
        }

        public static string KeywordSpace(this DotFormattingOptions options)
        {
            return options.TokenSpace().PadRight(1);
        }

        public static string NewLine(this DotFormattingOptions options)
        {
            return options.SingleLineOutput
                ? options.TokenSpace()
                : options.LineBreak + options.Indentation();
        }

        public static string LineBreak(this DotFormattingOptions options)
        {
            return options.SingleLineOutput
                ? options.TokenSpace()
                : options.LineBreak;
        }

        public static string? String(this DotFormattingOptions options, string? value)
        {
            if (!options.SingleLineOutput || value is null)
            {
                return value;
            }

            var lines = value.Split(options.LineBreak, StringSplitOptions.None);
            return string.Join(" ", lines);
        }
    }
}
