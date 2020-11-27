using GiGraph.Dot.Entities.Attributes.Collections.Common;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public interface IDotGraphStyleSheetAttributes : IDotEntityStyleSheetAttributes
    {
        /// <summary>
        ///     A URL or pathname specifying an XML style sheet, used in SVG output. Combine with
        ///     <see cref="IDotEntityStyleSheetAttributes.Class" /> on this or other elements to style them using CSS selectors.
        /// </summary>
        string Url { get; set; }
    }
}