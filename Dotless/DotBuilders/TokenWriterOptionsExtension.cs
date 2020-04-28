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
            return options.LineBreak + options.Indentation(level);
        }
    }
}
