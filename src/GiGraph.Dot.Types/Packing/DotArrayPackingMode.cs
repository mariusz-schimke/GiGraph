using System.Text;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Packing
{
    /// <summary>
    ///     Array packing mode parameters.
    /// </summary>
    public class DotArrayPackingMode : DotPackingModeDefinition
    {
        /// <summary>
        ///     Creates a new array packing mode instance.
        /// </summary>
        /// <param name="options">
        ///     The options to initialize the instance with.
        /// </param>
        public DotArrayPackingMode(DotArrayPackingOptions? options)
        {
            Options = options;
        }

        /// <summary>
        ///     Creates a new array packing mode instance.
        /// </summary>
        /// <param name="rankCount">
        ///     Specifies the number of columns for row-major component ordering or the number of rows for column-major component ordering.
        /// </param>
        public DotArrayPackingMode(int? rankCount)
        {
            RankCount = rankCount;
        }

        /// <summary>
        ///     Creates a new array packing mode instance.
        /// </summary>
        /// <param name="options">
        ///     The options to initialize the instance with.
        /// </param>
        /// <param name="rankCount">
        ///     Specifies the number of columns for row-major component ordering or the number of rows for column-major component ordering.
        /// </param>
        public DotArrayPackingMode(DotArrayPackingOptions? options, int? rankCount)
            : this(rankCount)
        {
            Options = options;
        }

        /// <summary>
        ///     Gets or sets the granularity option.
        /// </summary>
        public virtual DotArrayPackingOptions? Options { get; set; }

        /// <summary>
        ///     Gets or sets the number of columns for row-major component ordering or the number of rows for column-major component ordering
        ///     (see <see cref="DotArrayPackingOptions.ColumnMajorOrder" />).
        /// </summary>
        public virtual int? RankCount { get; set; }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            var result = new StringBuilder("array");

            if (Options.HasValue)
            {
                result.Append("_");
                result.Append(DotAttributeValue.GetAsFlags(Options.Value));
            }

            if (RankCount.HasValue)
            {
                result.Append(RankCount.Value);
            }

            return result.ToString();
        }
    }
}