using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Graphs
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
            return DotAttributeValue.Get(Option);
        }
    }
}