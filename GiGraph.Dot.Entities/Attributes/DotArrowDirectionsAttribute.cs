using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Arrow directions attribute. Assignable to edges only. See the
    ///     <see href="https://www.graphviz.org/doc/info/attrs.html#k:dirType">
    ///         documentation
    ///     </see>
    ///     to view how individual arrow directions are visualized.
    /// </summary>
    public class DotArrowDirectionsAttribute : DotAttribute<DotArrowDirections>
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
        public DotArrowDirectionsAttribute(string key, DotArrowDirections value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return DotAttributeValueAttribute.TryGetValue(Value, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(Value), $"The specified arrow direction '{Value}' is invalid.");
        }
    }
}