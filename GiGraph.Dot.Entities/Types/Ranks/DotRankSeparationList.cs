using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Types.Double;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Ranks
{
    /// <summary>
    ///     Radial separation of concentric circles in twopi.
    /// </summary>
    public class DotRankSeparationList : DotRankSeparationDefinition
    {
        /// <summary>
        ///     Creates a new rank separation instance.
        /// </summary>
        /// <param name="values">
        ///     The first double specifies the radius of the inner circle; the second double specifies the increase in radius from the first
        ///     circle to the second; etc. If there are more circles than numbers, the last number is used as the increment for the
        ///     remainder.
        /// </param>
        public DotRankSeparationList(params double[] values)
        {
            Values = values ?? throw new ArgumentNullException(nameof(values), "Values collection cannot be null.");
        }

        /// <summary>
        ///     Creates a new rank separation instance.
        /// </summary>
        /// <param name="value">
        ///     The first double specifies the radius of the inner circle; the second double specifies the increase in radius from the first
        ///     circle to the second; etc. If there are more circles than numbers, the last number is used as the increment for the
        ///     remainder.
        /// </param>
        public DotRankSeparationList(IEnumerable<double> value)
            : this(value?.ToArray())
        {
        }

        /// <summary>
        ///     Gets or sets the minimum vertical distance in inches between the bottom of the nodes in one rank and the tops of nodes in the
        ///     next.
        /// </summary>
        public double[] Values { get; }

        public static implicit operator DotRankSeparationList(double[] value)
        {
            return value is {} ? new DotRankSeparationList(value) : null;
        }

        protected internal override string GetDotEncoded(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return DotDoubleListConverter.Convert(Values);
        }
    }
}