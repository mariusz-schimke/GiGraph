using GiGraph.Dot.Entities.Graphs.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common
{
    public interface IDotStyleSheetAttributes
    {
        /// <summary>
        ///     Classnames to attach to the element in SVG output. Specify a style sheet <see cref="IDotGraphStyleSheetAttributes.Url" /> on
        ///     the graph for styling SVG output using CSS classnames. Multiple space-separated classes are supported.
        /// </summary>
        string Class { get; set; }
    }
}