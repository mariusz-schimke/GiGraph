using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Arrows
{
    /// <summary>
    ///     Defines an arrow composed of multiple shapes.
    /// </summary>
    public class DotCompositeArrowEnd : DotArrowEndDefinition
    {
        /// <summary>
        ///     Creates a new arrow definition and initializes it with a collection of arrows.
        /// </summary>
        /// <param name="arrows">
        ///     The consecutive arrows to use.
        /// </param>
        public DotCompositeArrowEnd(params DotArrowEnd[] arrows)
        {
            Arrows = arrows ?? throw new ArgumentNullException(nameof(arrows), "Arrow collection cannot be null.");
        }

        /// <summary>
        ///     Creates a new arrow definition and initializes it with a collection of arrows.
        /// </summary>
        /// <param name="arrows">
        ///     The consecutive arrows to use.
        /// </param>
        public DotCompositeArrowEnd(IEnumerable<DotArrowEnd> arrows)
            : this(arrows?.ToArray())
        {
        }

        /// <summary>
        ///     Creates a new arrow definition and initializes it with a collection of arrows with the specified shapes.
        /// </summary>
        /// <param name="shapes">
        ///     The consecutive shapes of the arrows to use.
        /// </param>
        public DotCompositeArrowEnd(params DotArrowShape[] shapes)
            : this((IEnumerable<DotArrowShape>) shapes)
        {
        }

        /// <summary>
        ///     Creates a new arrow definition and initializes it with a collection of arrows with the specified shapes.
        /// </summary>
        /// <param name="shapes">
        ///     The consecutive shapes of the arrows to use.
        /// </param>
        public DotCompositeArrowEnd(IEnumerable<DotArrowShape> shapes)
            : this(shapes?.Select(shape => new DotArrowEnd(shape)).ToArray())
        {
        }

        /// <summary>
        ///     Gets the component arrows.
        /// </summary>
        public virtual DotArrowEnd[] Arrows { get; }

        protected internal override string GetDotEncoded(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            var result = new StringBuilder();

            foreach (var arrow in Arrows)
            {
                result.Append(arrow.GetDotEncoded(options, syntaxRules));
            }

            return result.ToString();
        }
    }
}