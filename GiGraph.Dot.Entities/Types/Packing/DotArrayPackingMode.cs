using System;
using System.Linq;
using System.Text;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Packing
{
    /// <summary>
    ///     Array packing mode parameters.
    /// </summary>
    public class DotArrayPackingMode : DotPackingModeDefinition
    {
        protected int? _rankCount;

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
        public virtual int? RankCount
        {
            get => _rankCount;
            set => _rankCount = !value.HasValue || value.Value >= 0
                ? value
                : throw new ArgumentOutOfRangeException(nameof(RankCount), RankCount, "The number of ranks must be greater than or equal to 0.");
        }

        protected internal override string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            var result = new StringBuilder("array");

            if (Options.HasValue)
            {
                var flags = Enum.GetValues(typeof(DotArrayPackingOptions))
                   .Cast<DotArrayPackingOptions>()
                   .Where(flag => Options.Value.HasFlag(flag))
                   .Select(flag => GetDotEncodedOption(flag, options, syntaxRules));

                result.Append("_");
                result.Append(string.Join(string.Empty, flags));
            }

            if (RankCount.HasValue)
            {
                result.Append(RankCount.Value);
            }

            return result.ToString();
        }

        protected virtual string GetDotEncodedOption(DotArrayPackingOptions option, DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return DotAttributeValueAttribute.TryGetValue(option, out var result)
                ? result
                : throw new ArgumentOutOfRangeException(nameof(option), $"The specified array packing option '{option}' is invalid.");
        }
    }
}