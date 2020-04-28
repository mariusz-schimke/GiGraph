using System;

namespace Dotless.DotBuilders
{
    public static class TokenWriterOptionsExtension
    {
        public static string Indentation(this TokenWriterOptions options, int level)
        {
            return string.Empty.PadRight(options.BaseIndentation + options.Indentation * level);
        }

        public static string TokenSpace(this TokenWriterOptions options)
        {
            return string.Empty.PadRight(options.TokenSpacing);
        }

        public static string MandatoryTokenSpace(this TokenWriterOptions options)
        {
            return options.TokenSpace().PadRight(1);
        }

        public static string NewLine(this TokenWriterOptions options, int level)
        {
            return options.SingleLine
                ? options.TokenSpace()
                : options.LineBreak + options.Indentation(level);
        }

        public static string? String(this TokenWriterOptions options, string? value)
        {
            if (!options.SingleLine || value is null)
            {
                return value;
            }

            var lines = value.Split(options.LineBreak, StringSplitOptions.None);

            return string.Join(options.MandatoryTokenSpace(), lines);
        }
    }
}
