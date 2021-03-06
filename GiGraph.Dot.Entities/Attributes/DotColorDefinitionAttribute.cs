﻿using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Represents a simple (<see cref="DotColor" />) or a complex (<see cref="DotMultiColor" />) color definition. If the value
    ///     specifies multiple colors, with no weights (<see cref="DotMultiColor" /> with <see cref="DotColor" /> items), and a
    ///     <see cref="DotStyles.Filled" /> style is specified, a linear gradient fill is done using the first two colors. If weights are
    ///     present (<see cref="DotMultiColor" /> with <see cref="DotWeightedColor" /> items), a degenerate linear gradient fill is done.
    ///     This essentially does a fill using two colors, with the weights specifying how much of region is filled with each color. If
    ///     the style attribute of the element contains the value <see cref="DotStyles.Radial" />, then a radial gradient fill is done.
    ///     These fills work with any shape.
    /// </summary>
    public class DotColorDefinitionAttribute : DotAttribute<DotColorDefinition>
    {
        /// <summary>
        ///     Creates a new color definition attribute.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute, for example "color", "bgcolor", or "fillcolor".
        /// </param>
        /// <param name="colorDefinition">
        ///     The value of the attribute as a color definition. Use <see cref="DotColor" /> or <see cref="DotMultiColor" />.
        /// </param>
        public DotColorDefinitionAttribute(string key, DotColorDefinition colorDefinition)
            : base(key, colorDefinition)
        {
        }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Value?.GetDotEncodedColor(options, syntaxRules);
        }
    }
}