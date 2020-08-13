using System.Globalization;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Ranks
{
    /// <summary>
    ///     Rank separation, in inches.
    /// </summary>
    public class DotRankSeparation : DotRankSeparationDefinition
    {
        /// <summary>
        ///     Creates a new rank separation instance.
        /// </summary>
        /// <param name="value">
        ///     The minimum vertical distance in inches between the bottom of the nodes in one rank and the tops of nodes in the next.
        /// </param>
        /// <param name="equal">
        ///     Determines if the centers of all ranks should be spaced equally apart.
        /// </param>
        public DotRankSeparation(double value, bool equal = false)
        {
            Value = value;
            Equal = equal;
        }

        /// <summary>
        ///     Creates a new rank separation instance.
        /// </summary>
        /// <param name="equal">
        ///     Determines if the centers of all ranks should be spaced equally apart.
        /// </param>
        public DotRankSeparation(bool equal)
        {
            Equal = equal;
        }

        /// <summary>
        ///     Gets or sets the minimum vertical distance in inches between the bottom of the nodes in one rank and the tops of nodes in the
        ///     next.
        /// </summary>
        public virtual double? Value { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating if the centers of all ranks should be spaced equally apart.
        /// </summary>
        public virtual bool Equal { get; set; }

        protected internal override string GetDotEncoded(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            const string equally = "equally";
            var result = Value?.ToString(CultureInfo.InvariantCulture);

            if (Equal)
            {
                return result is {} ? $"{result} {equally}" : equally;
            }

            return result;
        }
    }
}