using System.Web;

namespace Gigraph.Dot.Core.TextEscaping
{
    public class DotHtmlEscaper : IDotTextEscaper
    {
        public virtual string Escape(string value)
        {
            return value is { } ? HttpUtility.HtmlEncode(value) : value;
        }
    }
}
