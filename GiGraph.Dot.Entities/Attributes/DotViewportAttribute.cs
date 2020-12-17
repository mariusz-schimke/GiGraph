using GiGraph.Dot.Entities.Types.Viewport;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Graph viewport attribute.
    /// </summary>
    public class DotViewportAttribute : DotAttribute<DotViewport>
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
        public DotViewportAttribute(string key, DotViewport value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncodedValue(options, syntaxRules);
        }
    }
}