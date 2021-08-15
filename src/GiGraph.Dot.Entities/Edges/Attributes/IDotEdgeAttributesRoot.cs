using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public interface IDotEdgeAttributesRoot : IDotEdgeAttributes
    {
        /// <summary>
        ///     Hyperlink attributes.
        /// </summary>
        DotHyperlinkAttributes Hyperlink { get; }
    }
}