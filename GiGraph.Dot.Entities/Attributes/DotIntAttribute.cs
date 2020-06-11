using System.Globalization;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// An integer value attribute.
    /// </summary>
    public class DotIntAttribute : DotAttribute<int>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotIntAttribute(string key, int value)
            : base(key, value)
        {
        }

        protected override string GetDotEncodedValue(DotGenerationOptions options)
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
