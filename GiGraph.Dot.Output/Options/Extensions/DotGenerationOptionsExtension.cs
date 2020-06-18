namespace GiGraph.Dot.Output.Options.Extensions
{
    public static class DotGenerationOptionsExtension
    {
        /// <summary>
        /// Formats the specified by the specified <see cref="DotGenerationOptions.TextFormatter"/>.
        /// </summary>
        /// <param name="options">The current options instance.</param>
        /// <param name="text">The text to format.</param>
        public static string FormatText(this DotGenerationOptions options, string text)
        {
            return options.TextFormatter is {}
                ? options.TextFormatter.Invoke(text)
                : text;
        }
    }
}