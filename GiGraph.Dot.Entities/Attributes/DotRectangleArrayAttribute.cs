using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Types.Geometry;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     A rectangle array value attribute.
    /// </summary>
    public class DotRectangleArrayAttribute : DotAttribute<DotRectangle[]>
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
        public DotRectangleArrayAttribute(string key, DotRectangle[] value)
            : base(key, value)
        {
        }

        /// <summary>
        ///     Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="value">
        ///     The value of the attribute.
        /// </param>
        public DotRectangleArrayAttribute(string key, IEnumerable<DotRectangle> value)
            : base(key, value?.ToArray())
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return string.Join(
                " ",
                (Value ?? Enumerable.Empty<DotRectangle>()).Select(value => value.GetDotEncodedValue(options, syntaxRules))
            );
        }
    }
}