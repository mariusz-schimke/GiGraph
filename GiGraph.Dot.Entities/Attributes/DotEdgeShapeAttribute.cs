using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Edge shape attribute.
    ///     <see href="http://www.graphviz.org/doc/info/attrs.html#d:splines">
    ///         View how individual shapes are visualized
    ///     </see>
    ///     .
    /// </summary>
    public class DotEdgeShapeAttribute : DotAttribute<DotEdgeShape>
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
        public DotEdgeShapeAttribute(string key, DotEdgeShape value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return DotAttributeValue.TryGet(Value, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(Value), $"The specified edge shape '{Value}' is invalid.");
        }
    }
}