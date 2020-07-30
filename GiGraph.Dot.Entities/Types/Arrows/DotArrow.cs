using System;
using System.Text;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Arrows
{
    /// <summary>
    ///     The arrow shape definition.
    /// </summary>
    public class DotArrow : DotArrowDefinition
    {
        /// <summary>
        ///     Creates and initializes a new arrow definition instance.
        /// </summary>
        /// <param name="shape">
        ///     The shape of the arrow to use.
        /// </param>
        /// <param name="fill">
        ///     Determines whether to use a filled version of the shape.
        /// </param>
        /// <param name="clip">
        ///     Determines whether to clip the shape, leaving only the part to the left or to the right of the edge.
        /// </param>
        public DotArrow(DotArrowShape shape, bool fill = true, DotArrowShapeClipping clip = DotArrowShapeClipping.None)
        {
            Shape = shape;
            Fill = fill;
            Clip = clip;
        }

        /// <summary>
        ///     Gets or sets the shape of the arrow.
        /// </summary>
        public virtual DotArrowShape Shape { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether to use a filled version of the shape.
        /// </summary>
        public virtual bool Fill { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether to clip the shape, leaving only the part to the left or to the right of the edge.
        /// </summary>
        public virtual DotArrowShapeClipping Clip { get; set; }

        protected internal override string GetDotEncoded(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            var result = new StringBuilder();

            if (!Fill)
            {
                result.Append("o");
            }

            switch (Clip)
            {
                case DotArrowShapeClipping.Left:
                    // clips the shape, leaving only the part to the right of the edge
                    result.Append("r");
                    break;

                case DotArrowShapeClipping.Right:
                    // clips the shape, leaving only the part to the left of the edge
                    result.Append("l");
                    break;
            }

            result.Append(GetDotEncodedShape(Shape));

            return result.ToString();
        }

        protected virtual string GetDotEncodedShape(DotArrowShape shape)
        {
            switch (shape)
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
                    throw new ArgumentOutOfRangeException(nameof(shape), $"The specified arrow type '{shape}' is not supported.");
            }
        }

        public static implicit operator DotArrow(DotArrowShape? shape)
        {
            return shape.HasValue ? new DotArrow(shape.Value) : null;
        }
    }
}