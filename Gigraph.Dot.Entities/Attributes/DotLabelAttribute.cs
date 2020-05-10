namespace Gigraph.Dot.Entities.Attributes
{
    /// <summary>
    /// Element label attribute (textual or HTML). Supported by edges, nodes, graphs, and cluster subgraphs.
    /// </summary>
    public abstract class DotLabelAttribute : DotAttribute<string>
    {
        public static string AttributeKey => "label";

        public DotLabelAttribute(string value)
            : base(AttributeKey, value)
        {
        }

        public static implicit operator DotLabelAttribute(string value)
        {
            return value is { } ? new DotTextLabelAttribute(value) : null;
        }
    }
}
