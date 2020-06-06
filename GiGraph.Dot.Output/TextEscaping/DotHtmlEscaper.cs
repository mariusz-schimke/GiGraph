using System.Web;

namespace GiGraph.Dot.Generators.TextEscaping
{
    public class DotHtmlEscaper : IDotTextEscaper
    {
        public virtual string Escape(string value)
        {
            return value is { } ? HttpUtility.HtmlEncode(value) : value;
        }
    }
}
