namespace Gigraph.Dot.Generators.Options
{
    public partial class DotGenerationOptions
    {
        public AttributeOptions Attributes { get; } = new AttributeOptions();

        /// <summary>
        /// When set, identifiers will always be quoted, even if it is not required.
        /// </summary>
        public virtual bool PreferQuotedIdentifiers { get; set; } = false;

        /// <summary>
        /// When set, all statements within the graph will be followed by a delimiter (;).
        /// </summary>
        public virtual bool PreferStatementDelimiter { get; set; } = true;
    }
}
