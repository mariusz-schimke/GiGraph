using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Arrow type attribute. Assignable to edges only.
    /// <see href="https://www.graphviz.org/doc/info/attrs.html#k:arrowType">View how individual arrow types are visualized</see>.
    /// </summary>
    public class DotArrowTypeAttribute : DotAttribute<DotArrowType>
    {
        /// <summary>
        /// Creates a new instance of the attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of the attribute.</param>
        public DotArrowTypeAttribute(string key, DotArrowType value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            switch (Value)
            {
                case DotArrowType.None:
                    return "none";

                case DotArrowType.Normal:
                    return "normal";

                case DotArrowType.Dot:
                    return "dot";

                case DotArrowType.OpenDot:
                    return "odot";

                case DotArrowType.Empty:
                    return "empty";

                case DotArrowType.Diamond:
                    return "diamond";

                case DotArrowType.EmptyDiamond:
                    return "ediamond";

                case DotArrowType.Box:
                    return "box";

                case DotArrowType.Open:
                    return "open";

                case DotArrowType.Vee:
                    return "vee";

                case DotArrowType.Inverted:
                    return "inv";

                case DotArrowType.InvertedDot:
                    return "invdot";

                case DotArrowType.InvertedOpenDot:
                    return "invodot";

                case DotArrowType.Tee:
                    return "tee";

                case DotArrowType.InvertedEmpty:
                    return "invempty";

                case DotArrowType.OpenDiamond:
                    return "odiamond";

                case DotArrowType.Crow:
                    return "crow";

                case DotArrowType.OpenBox:
                    return "obox";

                case DotArrowType.HalfOpen:
                    return "halfopen";

                default:
                    throw new ArgumentOutOfRangeException(nameof(Value), $"The specified arrow type '{Value}' is not supported.");
            }
        }
    }
}