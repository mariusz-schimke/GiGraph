using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Arrow type attribute. Assignable to edges only.
    ///     <see href="https://www.graphviz.org/doc/info/attrs.html#k:arrowType">
    ///         View how individual arrow types are visualized
    ///     </see>
    ///     .
    /// </summary>
    public class DotArrowShapeAttribute : DotAttribute<DotArrowShape>
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
        public DotArrowShapeAttribute(string key, DotArrowShape value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            switch (Value)
            {
                case DotArrowShape.None:
                    return "none";

                case DotArrowShape.Normal:
                    return "normal";

                case DotArrowShape.InvertedNormal:
                    return "inv";

                case DotArrowShape.Box:
                    return "box";

                case DotArrowShape.Crow:
                    return "crow";

                case DotArrowShape.Curve:
                    return "curve";

                case DotArrowShape.InvertedCurve:
                    return "icurve";

                case DotArrowShape.Diamond:
                    return "diamond";

                case DotArrowShape.Dot:
                    return "dot";

                case DotArrowShape.Tee:
                    return "tee";

                case DotArrowShape.Vee:
                    return "vee";

                default:
                    throw new ArgumentOutOfRangeException(nameof(Value), $"The specified arrow type '{Value}' is not supported.");
            }
        }
    }
}