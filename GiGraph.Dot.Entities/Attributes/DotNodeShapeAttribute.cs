using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     A node shape attribute. Assignable to nodes only.
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html">
    ///         View how individual shapes are visualized
    ///     </see>
    ///     .
    /// </summary>
    public class DotNodeShapeAttribute : DotAttribute<DotNodeShape>
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
        public DotNodeShapeAttribute(string key, DotNodeShape value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return DotAttributeValueAttribute.TryGetValue(Value, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(Value), $"The specified node shape '{Value}' is invalid.");
        }
    }
}