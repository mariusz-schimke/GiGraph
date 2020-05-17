using System.Globalization;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// A double value attribute.
    /// </summary>
    public class DotDoubleAttribute : DotAttribute<double>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotDoubleAttribute(string key, double value)
            : base(key, value)
        {
        }

        protected override string GetDotEncodedValue()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
