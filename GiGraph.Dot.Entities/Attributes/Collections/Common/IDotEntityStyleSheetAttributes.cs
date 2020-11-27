using GiGraph.Dot.Entities.Attributes.Collections.Graph;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public interface IDotEntityStyleSheetAttributes
    {
        /// <summary>
        ///     Classnames to attach to the element in SVG output. Specify a style sheet <see cref="IDotGraphStyleSheetAttributes.Url" /> on
        ///     the graph for styling SVG output using CSS classnames. Multiple space-separated classes are supported.
        /// </summary>
        string Class { get; set; }
    }
}