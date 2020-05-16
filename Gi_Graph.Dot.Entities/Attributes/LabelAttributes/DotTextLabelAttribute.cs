namespace GiGraph.Dot.Entities.Attributes.LabelAttributes
{
    /// <summary>
    /// Element label attribute. Supported by edges, nodes, graphs, and cluster subgraphs.
    /// </summary>
    public class DotTextLabelAttribute : DotLabelAttribute
    {
        public DotTextLabelAttribute(string value)
            : base(value)
        {
        }
    }
}
