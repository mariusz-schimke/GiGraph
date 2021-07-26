using System;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Edge directions attribute. Assignable to edges only. See the
    ///     <see href="https://www.graphviz.org/doc/info/attrs.html#k:dirType">
    ///         documentation
    ///     </see>
    ///     to view how individual directions are visualized.
    /// </summary>
    public class DotEdgeDirectionsAttribute : DotAttribute<DotEdgeDirections>
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
        public DotEdgeDirectionsAttribute(string key, DotEdgeDirections value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return DotAttributeValue.TryGet(Value, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(Value), $"The specified edge directions option '{Value}' is invalid.");
        }
    }
}