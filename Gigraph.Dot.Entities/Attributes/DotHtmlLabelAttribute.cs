namespace Gigraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Element label attribute in the HTML format. Supported by edges, nodes, graphs, and cluster subgraphs.
    /// </summary>
    public class DotHtmlLabelAttribute : DotLabelAttribute
    {
        public DotHtmlLabelAttribute(string value)
            : base(value)
        {
        }

        public static implicit operator DotHtmlLabelAttribute(string value)
        {
            return value is { } ? new DotHtmlLabelAttribute(value) : null;
        }
    }
}
