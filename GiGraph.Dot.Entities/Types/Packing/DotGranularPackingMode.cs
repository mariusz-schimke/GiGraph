using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Packing
{
    /// <summary>
    ///     A graph packing mode based on a granularity option.
    /// </summary>
    public class DotGranularPackingMode : DotPackingModeDefinition
    {
        /// <summary>
        ///     Creates a new packing granularity instance.
        /// </summary>
        /// <param name="granularity">
        ///     The option to initialize the instance with.
        /// </param>
        public DotGranularPackingMode(DotPackingGranularity granularity)
        {
            Granularity = granularity;
        }

        /// <summary>
        ///     Gets or sets the granularity option.
        /// </summary>
        public virtual DotPackingGranularity Granularity { get; set; }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Granularity switch
            {
                DotPackingGranularity.Node => "node",
                DotPackingGranularity.Cluster => "clust",
                DotPackingGranularity.Graph => "graph",
                DotPackingGranularity.Array => "array",
                _ => throw new ArgumentOutOfRangeException(nameof(Granularity), $"The specified packing granularity option '{Granularity}' is not supported.")
            };
        }
    }
}