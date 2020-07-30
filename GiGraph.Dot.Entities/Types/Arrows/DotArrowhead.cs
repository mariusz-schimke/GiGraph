using System;
using System.Text;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Arrows
{
    /// <summary>
    ///     Defines an arrowhead shape.
    /// </summary>
    public class DotArrowhead : DotArrowheadDefinition
    {
        /// <summary>
        ///     Creates and initializes a new arrowhead definition instance.
        /// </summary>
        /// <param name="shape">
        ///     Determines the shape of the arrowhead to use.
        /// </param>
        /// <param name="isFilled">
        ///     Determines whether to use a filled version of the shape.
        /// </param>
        /// <param name="clipping">
        ///     Determines whether and how to clip the shape, leaving only the part to the left or to the right of the edge.
        /// </param>
        public DotArrowhead(DotArrowheadShape shape, bool isFilled = true, DotArrowheadClipping clipping = DotArrowheadClipping.None)
        {
            Shape = shape;
            IsFilled = isFilled;
            Clipping = clipping;
        }

        /// <summary>
        ///     Gets or sets the shape of the arrowhead.
        /// </summary>
        public virtual DotArrowheadShape Shape { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether to use a filled version of the shape.
        /// </summary>
        public virtual bool IsFilled { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether and how to clip the shape, leaving only the part to the left or to the right of the
        ///     edge.
        /// </summary>
        public virtual DotArrowheadClipping Clipping { get; set; }

        protected internal override string GetDotEncoded(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            var result = new StringBuilder();

            if (!IsFilled)
            {
                result.Append("o");
            }

            switch (Clipping)
            {
                case DotArrowheadClipping.Left:
                    // clips the shape, leaving only the part to the right of the edge
                    result.Append("r");
                    break;

                case DotArrowheadClipping.Right:
                    // clips the shape, leaving only the part to the left of the edge
                    result.Append("l");
                    break;
            }

            result.Append(GetDotEncodedShape(Shape));

            return result.ToString();
        }

        protected virtual string GetDotEncodedShape(DotArrowheadShape shape)
        {
            switch (shape)
            {
                case DotArrowheadShape.None:
                    return "none";

                case DotArrowheadShape.Normal:
                    return "normal";

                case DotArrowheadShape.InvertedNormal:
                    return "inv";

                case DotArrowheadShape.Box:
                    return "box";

                case DotArrowheadShape.Crow:
                    return "crow";

                case DotArrowheadShape.Curve:
                    return "curve";

                case DotArrowheadShape.InvertedCurve:
                    return "icurve";

                case DotArrowheadShape.Diamond:
                    return "diamond";

                case DotArrowheadShape.Dot:
                    return "dot";

                case DotArrowheadShape.Tee:
                    return "tee";

                case DotArrowheadShape.Vee:
                    return "vee";

                default:
                    throw new ArgumentOutOfRangeException(nameof(shape), $"The specified arrowhead shape '{shape}' is not supported.");
            }
        }

        public static implicit operator DotArrowhead(DotArrowheadShape? shape)
        {
            return shape.HasValue ? new DotArrowhead(shape.Value) : null;
        }
    }
}