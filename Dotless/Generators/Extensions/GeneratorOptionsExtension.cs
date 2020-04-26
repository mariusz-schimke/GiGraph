namespace Dotless.Generators.Extensions
{
    public static class GeneratorOptionsExtension
    {
        /// <summary>
        /// Returns as many spaces as defined by the <see cref="GeneratorOptions.TokenSpacing"/> property.
        /// </summary>
        public static string TS(this GeneratorOptions options)
        {
            return "".PadRight(options.TokenSpacing);
        }

        /// <summary>
        /// Returns as many spaces as defined by the <see cref="GeneratorOptions.TokenSpacing"/> property, but at least one.
        /// </summary>
        public static string TSoS(this GeneratorOptions options)
        {
            return options.TS().PadRight(1);
        }

        /// <summary>
        /// Returns spaces based on the indentation properties.
        /// </summary>
        public static string I(this GeneratorOptions options)
        {
            var indentation = options.BaseIndentation + options.Indentation;
            return "".PadRight(options.Indent && indentation > 0 ? indentation : 0, options.IndentChar);
        }

        /// <summary>
        /// Returns a line break unless <see cref="GeneratorOptions.SingleLine"/> is set, in which case an empty string is returned.
        /// </summary>
        public static string LB(this GeneratorOptions options)
        {
            return options.SingleLine ? "" : options.LineBreak;
        }

        /// <summary>
        /// Returns a line break unless <see cref="GeneratorOptions.SingleLine"/> is set, in which case <see cref="TS"/> is used as the result.
        /// </summary>
        public static string LBoS(this GeneratorOptions options)
        {
            return options.SingleLine ? options.TS() : options.LineBreak;
        }
    }
}
