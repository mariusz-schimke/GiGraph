using System.Web;

namespace Dotless.TextEscaping
{
    public class HtmlEscaper : ITextEscaper
    {
        public virtual string? Escape(string? value)
        {
            return value is { } ? HttpUtility.HtmlEncode(value) : value;
        }
    }
}
