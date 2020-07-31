using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Image alignment attribute.
    /// </summary>
    public class DotAlignmentAttribute : DotAttribute<DotAlignment>
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
        public DotAlignmentAttribute(string key, DotAlignment value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            switch (Value)
            {
                case DotAlignment.TopLeft:
                    return "tl";

                case DotAlignment.TopCenter:
                    return "tc";

                case DotAlignment.TopRight:
                    return "tr";


                case DotAlignment.MiddleLeft:
                    return "ml";

                case DotAlignment.MiddleCenter:
                    return "mc";

                case DotAlignment.MiddleRight:
                    return "mr";


                case DotAlignment.BottomLeft:
                    return "bl";

                case DotAlignment.BottomCenter:
                    return "bc";

                case DotAlignment.BottomRight:
                    return "br";

                default:
                    throw new ArgumentOutOfRangeException(nameof(Value), $"The specified alignment '{Value}' is not supported.");
            }
        }
    }
}