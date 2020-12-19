using GiGraph.Dot.Entities.Types.Geometry;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     A rectangle value attribute.
    /// </summary>
    public class DotRectangleAttribute : DotAttribute<DotRectangle>
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
        public DotRectangleAttribute(string key, DotRectangle value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncodedValue(options, syntaxRules);
        }
    }
}