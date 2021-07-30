using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Extensions
{
    public static class DotStringExtension
    {
        /// <summary>
        ///     Converts the string to <see cref="DotEscapedString" /> without modifying it in any way. When assigned to a label of an
        ///     element, it will be rendered as is, without any extra processing (escaping).
        /// </summary>
        /// <param name="string">
        ///     The string to convert.
        /// </param>
        public static DotEscapedString AsEscapedString(this string @string)
        {
            return @string;
        }

        /// <summary>
        ///     Converts the string to <see cref="DotHtmlString" /> without modifying it in any way. When assigned to a label of an element,
        ///     it will be rendered as is, without any extra processing (escaping).
        /// </summary>
        /// <param name="string">
        ///     The string to convert.
        /// </param>
        public static DotHtmlString AsHtml(this string @string)
        {
            return @string;
        }
    }
}