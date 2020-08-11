using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.AspectRatio
{
    /// <summary>
    ///     An enumerable aspect ratio of the graph.
    /// </summary>
    public class DotAspectRatioOption : DotAspectRatioDefinition
    {
        /// <summary>
        ///     Creates a new enumerable aspect ratio instance.
        /// </summary>
        /// <param name="option">
        ///     The option to initialize the instance with.
        /// </param>
        public DotAspectRatioOption(DotAspectRatio option)
        {
            Option = option;
        }

        /// <summary>
        ///     Gets or sets the aspect ratio.
        /// </summary>
        public virtual DotAspectRatio Option { get; set; }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Option switch
            {
                DotAspectRatio.Auto => "auto",
                DotAspectRatio.Compress => "compress",
                DotAspectRatio.Expand => "expand",
                DotAspectRatio.Fill => "fill",
                _ => throw new ArgumentOutOfRangeException(nameof(Option), $"The specified aspect ratio '{Option}' is not supported.")
            };
        }
    }
}