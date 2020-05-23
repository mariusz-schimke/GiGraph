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
