using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public interface IDotEdgeHyperlinkAttributes : IDotHyperlinkAttributes
{
    /// <summary>
    ///     Tooltip annotation attached to the endpoint of the edge, to its label, or to its non-label part, depending on the context the
    ///     attribute is specified. Used only if <see cref="IDotHyperlinkAttributes.Url" /> is specified, or if the edge has a
    ///     <see cref="IDotEdgeRootAttributes.Hyperlink" /> <see cref="IDotHyperlinkAttributes.Url" /> specified.
    /// </summary>
    DotEscapeString? Tooltip { get; set; }
}