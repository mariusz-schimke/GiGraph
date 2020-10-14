using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public interface IDotEdgeHyperlinkAttributes : IDotEntityHyperlinkAttributes
    {
        /// <summary>
        ///     Tooltip annotation attached to the endpoint of the edge. Used only if the edge has a <see cref="Url" /> attribute specified
        ///     for the endpoint.
        /// </summary>
        DotEscapeString Tooltip { get; set; }
    }
}