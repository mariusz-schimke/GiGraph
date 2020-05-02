namespace Dotless.Writers.Options
{
    public class DotWriterOptions
    {
        public DotAttributeWriterOptions Attributes { get; } = new DotAttributeWriterOptions();
        public DotNodeWriterOptions Nodes { get; } = new DotNodeWriterOptions();
    }
}
