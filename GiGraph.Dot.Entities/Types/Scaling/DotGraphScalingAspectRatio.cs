using System.Globalization;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Scaling
{
    /// <summary>
    ///     The aspect ratio of the graph. If ratio = x where x is a floating point number, then the drawing is scaled up in one
    ///     dimension to achieve the requested ratio expressed as drawing height/width. For example, ratio = 2.0 makes the drawing twice
    ///     as high as it is wide.
    /// </summary>
    public class DotGraphScalingAspectRatio : DotGraphScalingDefinition
    {
        /// <summary>
        ///     Creates a new numeric aspect ratio instance.
        /// </summary>
        /// <param name="ratio">
        ///     The aspect ratio to initialize the instance with.
        /// </param>
        public DotGraphScalingAspectRatio(double ratio)
        {
            Ratio = ratio;
        }

        /// <summary>
        ///     Gets or sets the aspect ratio.
        /// </summary>
        public virtual double Ratio { get; set; }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Ratio.ToString(syntaxRules.Culture);
        }
    }
}