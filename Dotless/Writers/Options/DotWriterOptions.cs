namespace Dotless.Writers.Options
{
    public class DotWriterOptions
    {
        public DotAttributeWriterOptions Attributes { get; } = new DotAttributeWriterOptions();
        public DotNodeWriterOptions Nodes { get; } = new DotNodeWriterOptions();

        /// <summary>
        /// When set, all statements within the graph will be followed by a delimiter (;).
        /// </summary>
        public bool PreferStatementDelimiter { get; set; } = true;
    }
}
