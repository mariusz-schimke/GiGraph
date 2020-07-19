using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     A point value attribute.
    /// </summary>
    public class DotPointAttribute : DotAttribute<DotPoint>
    {
        /// <summary>
        ///     Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotPointAttribute(string key, DotPoint value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncodedValue(options, syntaxRules);
        }
    }
}