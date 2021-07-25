using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Types.Html
{
    /// <summary>
    ///     A string-value attribute of an HTML tag.
    /// </summary>
    public class DotHtmlStringAttribute : DotHtmlAttribute<string>
    {
        protected readonly bool _isEscaped;

        public DotHtmlStringAttribute(string value, bool isEscaped = false)
            : base(value)
        {
            _isEscaped = isEscaped;
        }

        public override DotHtml ToHtml()
        {
            return _isEscaped
                ? Value
                : DotHtmlEscaper.Escape(Value);
        }
    }
}