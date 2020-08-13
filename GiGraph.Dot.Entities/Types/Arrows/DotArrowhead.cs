using System;
using System.Text;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Arrows
{
    /// <summary>
    ///     Defines an arrowhead shape. See the
    ///     <see href="http://www.graphviz.org/doc/info/arrows.html">
    ///         documentation
    ///     </see>
    ///     to view what shape configurations are supported.
    /// </summary>
    public class DotArrowhead : DotArrowheadDefinition
    {
        /// <summary>
        ///     Creates and initializes a new arrowhead definition instance.
        /// </summary>
        /// <param name="shape">
        ///     Determines the shape of the arrowhead to use.
        /// </param>
        public DotArrowhead(DotArrowheadShape shape)
        {
            Shape = shape;
        }

        /// <summary>
        ///     Creates and initializes a new arrowhead definition instance.
        /// </summary>
        /// <param name="shape">
        ///     Determines the shape of the arrowhead to use.
        /// </param>
        /// <param name="isFilled">
        ///     Determines whether to use a filled version of the shape.
        /// </param>
        public DotArrowhead(DotArrowheadShape shape, bool isFilled)
            : this(shape)
        {
            IsFilled = isFilled;
        }

        /// <summary>
        ///     Creates and initializes a new arrowhead definition instance.
        /// </summary>
        /// <param name="shape">
        ///     Determines the shape of the arrowhead to use.
        /// </param>
        /// <param name="visibleParts">
        ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
        /// </param>
        public DotArrowhead(DotArrowheadShape shape, DotArrowheadPart visibleParts)
            : this(shape)
        {
            VisibleParts = visibleParts;
        }

        /// <summary>
        ///     Creates and initializes a new arrowhead definition instance.
        /// </summary>
        /// <param name="shape">
        ///     Determines the shape of the arrowhead to use.
        /// </param>
        /// <param name="isFilled">
        ///     Determines whether to use a filled version of the shape.
        /// </param>
        /// <param name="visibleParts">
        ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
        /// </param>
        public DotArrowhead(DotArrowheadShape shape, bool isFilled, DotArrowheadPart visibleParts)
            : this(shape)
        {
            IsFilled = isFilled;
            VisibleParts = visibleParts;
        }

        /// <summary>
        ///     Gets or sets the shape of the arrowhead.
        /// </summary>
        public virtual DotArrowheadShape Shape { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether to use a filled version of the shape.
        /// </summary>
        public virtual bool IsFilled { get; set; } = true;

        /// <summary>
        ///     Gets or sets a value indicating whether and how to clip the shape, leaving visible only the part to the left or to the right
        ///     of the edge.
        /// </summary>
        public virtual DotArrowheadPart VisibleParts { get; set; } = DotArrowheadPart.Both;

        protected internal override string GetDotEncoded(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            var result = new StringBuilder();

            if (!IsFilled)
            {
                result.Append("o");
            }

            // clips the shape, leaving visible only the part to the left or to the right of the edge
            result.Append(GetDotEncodedArrowheadPart(VisibleParts));

            result.Append(GetDotEncodedShape(Shape));

            return result.ToString();
        }

        protected virtual string GetDotEncodedShape(DotArrowheadShape shape)
        {
            return DotAttributeValueAttribute.TryGetValue(shape, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(shape), $"The specified arrowhead shape '{shape}' is invalid.");
        }

        protected virtual string GetDotEncodedArrowheadPart(DotArrowheadPart visibleParts)
        {
            return DotAttributeValueAttribute.TryGetValue(visibleParts, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(visibleParts), $"The specified arrowhead part '{visibleParts}' is invalid.");
        }

        /// <summary>
        ///     Creates a filled arrowhead with the <see cref="DotArrowheadShape.Normal" /> shape.
        /// </summary>
        /// <param name="visibleParts">
        ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
        /// </param>
        public static DotArrowhead Filled(DotArrowheadPart visibleParts = DotArrowheadPart.Both)
        {
            return Filled(DotArrowheadShape.Normal, visibleParts);
        }

        /// <summary>
        ///     Creates a filled arrowhead with the specified shape.
        /// </summary>
        /// <param name="shape">
        ///     Determines the shape of the arrowhead to use.
        /// </param>
        /// <param name="visibleParts">
        ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
        /// </param>
        public static DotArrowhead Filled(DotArrowheadShape shape, DotArrowheadPart visibleParts = DotArrowheadPart.Both)
        {
            return new DotArrowhead(shape, isFilled: true, visibleParts);
        }

        /// <summary>
        ///     Creates a non-filled arrowhead with the <see cref="DotArrowheadShape.Normal" /> shape.
        /// </summary>
        /// <param name="visibleParts">
        ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
        /// </param>
        public static DotArrowhead Empty(DotArrowheadPart visibleParts = DotArrowheadPart.Both)
        {
            return Empty(DotArrowheadShape.Normal, visibleParts);
        }

        /// <summary>
        ///     Creates a non-filled arrowhead with the specified shape.
        /// </summary>
        /// <param name="shape">
        ///     Determines the shape of the arrowhead to use.
        /// </param>
        /// <param name="visibleParts">
        ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
        /// </param>
        public static DotArrowhead Empty(DotArrowheadShape shape, DotArrowheadPart visibleParts = DotArrowheadPart.Both)
        {
            return new DotArrowhead(shape, isFilled: false, visibleParts);
        }

        public static implicit operator DotArrowhead(DotArrowheadShape? shape)
        {
            return shape.HasValue ? new DotArrowhead(shape.Value) : null;
        }
    }
}