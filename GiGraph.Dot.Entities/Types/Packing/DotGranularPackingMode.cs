using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
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

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return DotAttributeValueAttribute.TryGetValue(Granularity, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(Granularity), $"The specified packing granularity option '{Granularity}' is invalid.");
        }
    }
}