using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// The fixed size attribute of a node.
    /// </summary>
    public class DotNodeFixedSizeAttribute : DotAttribute<DotNodeSizing>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotNodeFixedSizeAttribute(string key, DotNodeSizing value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            switch (Value)
            {
                case DotNodeSizing.Fixed:
                    return "true";

                case DotNodeSizing.Automatic:
                    return "false";

                case DotNodeSizing.Shape:
                    return "shape";

                default:
                    throw new ArgumentOutOfRangeException(nameof(Value), $"The specified fixed size attribute value '{Value}' is not supported.");
            }
        }
    }
}