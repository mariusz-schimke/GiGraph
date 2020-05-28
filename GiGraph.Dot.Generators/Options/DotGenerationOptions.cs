using System;

namespace GiGraph.Dot.Generators.Options
{
    public partial class DotGenerationOptions
    {
        public virtual AttributeOptions Attributes { get; }
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
        /// Gets or sets a value indicating if graph elements should be ordered.
        /// This includes nodes, edges, subgraphs, clusters, and attributes.
        /// Useful when the output is going to be compared to its other version.
        /// If false, all elements will be rendered in the output script in the order
        /// they were added to graph element collections.
        /// </summary>
        public virtual bool OrderElements { get; set; } = true;

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
