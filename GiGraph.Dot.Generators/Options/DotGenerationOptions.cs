using System;

namespace GiGraph.Dot.Generators.Options
{
    public partial class DotGenerationOptions
    {
        /// <summary>
        /// The generation options for attributes.
        /// </summary>
        public virtual AttributeOptions Attributes { get; }

        /// <summary>
        /// The generation options for subgraphs, including clusters.
        /// </summary>
        public virtual SubgraphOptions Subgraphs { get; }

        /// <summary>
        /// When set, identifiers will always be quoted, even if it is not required.
        /// </summary>
        public virtual bool PreferQuotedIdentifiers { get; set; } = false;

        /// <summary>
        /// When set, all statements within the graph will be followed by a delimiter (;).
        /// </summary>
        public virtual bool PreferStatementDelimiter { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating if graph elements should be ordered alphabetically in the output DOT script.
        /// This setting affects attributes, nodes, edges, subgraphs, and clusters.
        /// If false, all elements will be rendered in the order they were added to individual graph element collections.
        /// <para>
        ///     Useful when the output DOT script is going to be compared to its other versions, so that there are
        ///     as few differences between the scripts as possible. However, this option should be used with care
        ///     because the order of elements in the script may affect the order they are visualized, if that matters.
        /// </para>
        /// </summary>
        public virtual bool OrderElements { get; set; } = false;

        protected DotGenerationOptions(AttributeOptions attributes, SubgraphOptions subgraphs)
        {
            Attributes = attributes;
            Subgraphs = subgraphs;
        }

        public DotGenerationOptions()
            : this(new AttributeOptions(), new SubgraphOptions())
        {
        }

        public static DotGenerationOptions Custom(Action<DotGenerationOptions> init)
        {
            var result = new DotGenerationOptions();
            init?.Invoke(result);
            return result;
        }
    }
}
