using System;

namespace Dotless.DotBuilders
{
    public static class DotTokenWriterOptionsExtension
    {
        public static string Indentation(this DotTokenWriterOptions options, int level)
        {
            return string.Empty.PadRight(options.BaseIndentation + options.Indentation * level);
        }

        public static string TokenSpace(this DotTokenWriterOptions options)
        {
            return string.Empty.PadRight(options.TokenSpacing);
        }

        public static string MandatoryTokenSpace(this DotTokenWriterOptions options)
        {
            return options.TokenSpace().PadRight(1);
        }

        public static string NewLine(this DotTokenWriterOptions options, int level)
        {
            return options.SingleLine
                ? options.TokenSpace()
                : options.LineBreak + options.Indentation(level);
        }

        public static string? String(this DotTokenWriterOptions options, string? value)
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
