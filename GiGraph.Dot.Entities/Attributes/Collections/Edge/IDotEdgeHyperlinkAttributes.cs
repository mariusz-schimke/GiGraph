using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public interface IDotEdgeHyperlinkAttributes : IDotEntityHyperlinkAttributes
    {
        /// <summary>
        ///     Tooltip annotation attached to the endpoint of the edge, to its label, or to its non-label part, depending on the context the
        ///     attribute is specified. Used only if <see cref="IDotEntityHyperlinkAttributes.Url" /> is specified, or if the edge has a
        ///     <see cref="DotEntityCommonAttributes{IDotEdgeAttributes}.Hyperlink" /> <see cref="IDotEntityHyperlinkAttributes.Url" />
        ///     specified.
        /// </summary>
        DotEscapeString Tooltip { get; set; }
    }
}