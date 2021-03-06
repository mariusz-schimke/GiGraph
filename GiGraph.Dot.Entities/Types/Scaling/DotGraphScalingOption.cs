using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Attributes.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Scaling
{
    /// <summary>
    ///     Scaling mode of the graph drawing.
    /// </summary>
    public class DotGraphScalingOption : DotGraphScalingDefinition
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="option">
        ///     The scaling option to initialize the instance with.
        /// </param>
        public DotGraphScalingOption(DotGraphScaling option)
        {
            Option = option;
        }

        /// <summary>
        ///     Gets or sets the scaling option.
        /// </summary>
        public virtual DotGraphScaling Option { get; set; }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return DotAttributeValue.TryGet(Option, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(Option), $"The specified graph scaling option '{Option}' is invalid.");
        }
    }
}