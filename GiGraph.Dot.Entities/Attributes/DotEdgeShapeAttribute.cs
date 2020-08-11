using System;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Edge shape attribute.
    ///     <see href="http://www.graphviz.org/doc/info/attrs.html#d:splines">
    ///         View how individual shapes are visualized
    ///     </see>
    ///     .
    /// </summary>
    public class DotEdgeShapeAttribute : DotAttribute<DotEdgeShape>
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
        public DotEdgeShapeAttribute(string key, DotEdgeShape value)
            : base(key, value)
        {
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return Value switch
            {
                DotEdgeShape.None => "none",
                DotEdgeShape.Line => "line",
                DotEdgeShape.Polyline => "polyline",
                DotEdgeShape.Curved => "curved",
                DotEdgeShape.Orthogonal => "ortho",
                DotEdgeShape.Spline => "spline",
                DotEdgeShape.Compound => "compound",
                _ => throw new ArgumentOutOfRangeException(nameof(Value), $"The specified edge shape '{Value}' is not supported.")
            };
        }
    }
}