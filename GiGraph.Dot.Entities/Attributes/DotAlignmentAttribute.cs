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
            return Value switch
            {
                DotAlignment.TopLeft => "tl",
                DotAlignment.TopCenter => "tc",
                DotAlignment.TopRight => "tr",

                DotAlignment.MiddleLeft => "ml",
                DotAlignment.MiddleCenter => "mc",
                DotAlignment.MiddleRight => "mr",

                DotAlignment.BottomLeft => "bl",
                DotAlignment.BottomCenter => "bc",
                DotAlignment.BottomRight => "br",

                _ => throw new ArgumentOutOfRangeException(nameof(Value), $"The specified alignment option '{Value}' is not supported.")
            };
        }
    }
}