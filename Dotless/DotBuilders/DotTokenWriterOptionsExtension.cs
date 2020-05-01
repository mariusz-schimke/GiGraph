using System;

namespace Dotless.DotBuilders
{
    public static class DotTokenWriterOptionsExtension
    {
        public static string Indentation(this DotTokenWriterOptions options, int level)
        {
            return options.Indent
                ? string.Empty.PadRight(options.BaseIndentation + options.Indentation * level)
                : string.Empty;
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
            return options.SingleLineOutput
                ? options.TokenSpace()
                : options.LineBreak + options.Indentation(level);
        }

        public static string LineBreak(this DotTokenWriterOptions options)
        {
            return options.SingleLineOutput
                ? options.TokenSpace()
                : options.LineBreak;
        }

        public static string? String(this DotTokenWriterOptions options, string? value)
        {
            if (!options.SingleLineOutput || value is null)
            {
                return value;
            }

            var lines = value.Split(options.LineBreak, StringSplitOptions.None);
            return string.Join(options.SingleLineOutputLineBreakReplacement, lines);
        }
    }
}
