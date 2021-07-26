using System;
using System.Text;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Metadata;
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
        /// <param name="filled">
        ///     Determines whether to use a filled version of the shape.
        /// </param>
        public DotArrowhead(DotArrowheadShape shape, bool filled)
            : this(shape)
        {
            IsFilled = filled;
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
        public DotArrowhead(DotArrowheadShape shape, DotArrowheadParts visibleParts)
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
        /// <param name="filled">
        ///     Determines whether to use a filled version of the shape.
        /// </param>
        /// <param name="visibleParts">
        ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
        /// </param>
        public DotArrowhead(DotArrowheadShape shape, bool filled, DotArrowheadParts visibleParts)
            : this(shape)
        {
            IsFilled = filled;
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
        public virtual DotArrowheadParts VisibleParts { get; set; } = DotArrowheadParts.Both;

        protected internal override string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
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
            return DotAttributeValue.TryGet(shape, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(shape), $"The specified arrowhead shape '{shape}' is invalid.");
        }

        protected virtual string GetDotEncodedArrowheadPart(DotArrowheadParts visibleParts)
        {
            return DotAttributeValue.TryGet(visibleParts, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(visibleParts), $"The specified arrowhead part '{visibleParts}' is invalid.");
        }

        /// <summary>
        ///     Creates a filled arrowhead with the <see cref="DotArrowheadShape.Normal" /> shape.
        /// </summary>
        /// <param name="visibleParts">
        ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
        /// </param>
        public static DotArrowhead Filled(DotArrowheadParts visibleParts = DotArrowheadParts.Both)
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
        public static DotArrowhead Filled(DotArrowheadShape shape, DotArrowheadParts visibleParts = DotArrowheadParts.Both)
        {
            return new DotArrowhead(shape, filled: true, visibleParts);
        }

        /// <summary>
        ///     Creates a non-filled arrowhead with the <see cref="DotArrowheadShape.Normal" /> shape.
        /// </summary>
        /// <param name="visibleParts">
        ///     Determines whether and how to clip the shape, leaving visible only the part to the left or to the right of the edge.
        /// </param>
        public static DotArrowhead Empty(DotArrowheadParts visibleParts = DotArrowheadParts.Both)
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
        public static DotArrowhead Empty(DotArrowheadShape shape, DotArrowheadParts visibleParts = DotArrowheadParts.Both)
        {
            return new DotArrowhead(shape, filled: false, visibleParts);
        }

        public static implicit operator DotArrowhead(DotArrowheadShape? shape)
        {
            return shape.HasValue ? new DotArrowhead(shape.Value) : null;
        }
    }
}