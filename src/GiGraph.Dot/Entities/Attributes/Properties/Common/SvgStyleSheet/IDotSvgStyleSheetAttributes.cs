using GiGraph.Dot.Entities.Graphs.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet;

public interface IDotSvgStyleSheetAttributes
{
    /// <summary>
    ///     Classnames to attach to the element in SVG output. Specify a style sheet <see cref="IDotGraphSvgStyleSheetAttributes.Url" />
    ///     on the graph for styling SVG output using CSS classnames. Multiple space-separated classes are supported.
    /// </summary>
    string? Class { get; set; }
}