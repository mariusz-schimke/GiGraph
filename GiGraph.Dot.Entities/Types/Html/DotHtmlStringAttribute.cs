using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Html
{
    /// <summary>
    ///     A string-value attribute of an HTML tag.
    /// </summary>
    public class DotHtmlStringAttribute : DotHtmlAttribute<string>
    {
        public DotHtmlStringAttribute(string value)
            : base(value)
        {
        }

        public override DotHtml ToHtml()
        {
            return DotHtmlEscaper.Escape(Value);
        }
    }
}