using System;

namespace GiGraph.Dot.Types.Text
{
    /// <summary>
    ///     An HTML string.
    /// </summary>
    public class DotHtmlString
    {
        protected readonly string _html;

        protected DotHtmlString(string html)
        {
            _html = html ?? throw new ArgumentNullException(nameof(html), "HTML string must not be null.");
        }

        public override string ToString()
        {
            return _html;
        }

        public static implicit operator DotHtmlString(string value)
        {
            return value is not null ? new DotHtmlString(value) : null;
        }

        public static implicit operator string(DotHtmlString value)
        {
            return value?._html;
        }

        public static implicit operator DotUnescapedString(DotHtmlString value)
        {
            return value?._html;
        }

        public static DotHtmlString operator +(DotHtmlString value1, DotHtmlString value2)
        {
            return $"{value1?._html}{value2?._html}";
        }
    }
}