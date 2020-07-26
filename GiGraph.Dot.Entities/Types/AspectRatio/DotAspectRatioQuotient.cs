using System.Globalization;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.AspectRatio
{
    /// <summary>
    ///     A numeric aspect ratio of the graph. If ratio = x where x is a floating point number, then the drawing is scaled up in one
    ///     dimension to achieve the requested ratio expressed as drawing height/width. For example, ratio = 2.0 makes the drawing twice
    ///     as high as it is wide.
    /// </summary>
    public class DotAspectRatioQuotient : DotAspectRatioDefinition
    {
        /// <summary>
        ///     Creates a new numeric aspect ratio instance.
        /// </summary>
        /// <param name="value">
        ///     The value to initialize the instance with.
        /// </param>
        public DotAspectRatioQuotient(double value)
        {
            Value = value;
        }

        /// <summary>
        ///     Gets or sets the aspect ratio.
        /// </summary>
        public virtual double Value { get; set; }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}