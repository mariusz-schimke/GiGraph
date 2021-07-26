using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Converters
{
    /// <summary>
    ///     Converts an object to string.
    /// </summary>
    public interface IDotValueConverter
    {
        /// <summary>
        ///     Indicates if the converter supports the specified type to convert.
        /// </summary>
        /// <param name="type">
        ///     The type to check.
        /// </param>
        bool CanConvert(Type type);

        /// <summary>
        ///     Converts an object to string.
        /// </summary>
        /// <param name="value">
        ///     The object to convert.
        /// </param>
        /// <param name="options">
        ///     The syntax options to use for conversion.
        /// </param>
        /// <param name="syntaxRules">
        ///     The syntax rules to use for conversion.
        /// </param>
        string Convert(object value, DotSyntaxOptions options, DotSyntaxRules syntaxRules);
    }
}