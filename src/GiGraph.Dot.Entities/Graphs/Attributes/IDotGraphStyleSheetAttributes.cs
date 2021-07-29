using GiGraph.Dot.Entities.Attributes.Properties.Common;

namespace GiGraph.Dot.Entities.Graphs.Attributes
{
    public interface IDotGraphStyleSheetAttributes : IDotStyleSheetAttributes
    {
        /// <summary>
        ///     A URL or pathname specifying an XML style sheet, used in SVG output. Combine with
        ///     <see cref="IDotStyleSheetAttributes.Class" /> on this or other elements to style them using CSS selectors.
        /// </summary>
        string Url { get; set; }
    }
}