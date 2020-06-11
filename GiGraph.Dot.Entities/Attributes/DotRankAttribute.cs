using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Rank constraints for the nodes in a subgraph. Assignable to non-cluster subgraphs only.
    /// </summary>
    public class DotRankAttribute : DotAttribute<DotRank>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotRankAttribute(string key, DotRank value)
            : base(key, value)
        {
        }

        protected override string GetDotEncodedValue(DotGenerationOptions options)
        {
            switch (Value)
            {
                case DotRank.Same:
                    return "same";

                case DotRank.Min:
                    return "min";

                case DotRank.Max:
                    return "max";

                case DotRank.Source:
                    return "source";

                case DotRank.Sink:
                    return "sink";

                default:
                    throw new ArgumentOutOfRangeException(nameof(IDotAttribute.GetDotEncodedValue), $"The specified rank '{Value}' is not supported.");
            }
        }
    }
}
