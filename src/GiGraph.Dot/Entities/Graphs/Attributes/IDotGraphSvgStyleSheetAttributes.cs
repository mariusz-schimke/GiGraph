using GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public interface IDotGraphSvgStyleSheetAttributes : IDotSvgStyleSheetAttributes
{
    /// <summary>
    ///     A URL or pathname specifying an XML style sheet, used in SVG output. Combine with
    ///     <see cref="IDotSvgStyleSheetAttributes.Class" /> on this or other elements to style them using CSS selectors.
    /// </summary>
    string? Url { get; set; }
}