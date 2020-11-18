using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Rank constraints for the nodes in a subgraph. Assignable to non-cluster subgraphs only.
    /// </summary>
    public class DotRankAttribute : DotAttribute<DotRank>
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
        public DotRankAttribute(string key, DotRank value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return DotAttributeValueAttribute.TryGetValue(Value, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(Value), $"The specified rank '{Value}' is invalid.");
        }
    }
}