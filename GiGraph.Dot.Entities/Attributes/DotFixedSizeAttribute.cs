using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// The fixed size attribute of a node.
    /// </summary>
    public class DotFixedSizeAttribute : DotAttribute<DotFixedSize>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotFixedSizeAttribute(string key, DotFixedSize value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            switch (Value)
            {
                case DotFixedSize.Yes:
                    return "true";

                case DotFixedSize.No:
                    return "false";

                case DotFixedSize.Shape:
                    return "shape";

                default:
                    throw new ArgumentOutOfRangeException(nameof(Value), $"The specified fixed size attribute value '{Value}' is not supported.");
            }
        }
    }
}