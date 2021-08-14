using System.Text.RegularExpressions;

namespace GiGraph.Dot.Output.Text.Escaping
{
    /// <summary>
    ///     Escapes leading and trailing spaces with the &#32; HTML code. Used because escaping a leading space with a backslash seems to
    ///     be ignored, and, on the other hand, escaping trailing spaces with a backslash causes the extra separator space added at the
    ///     end to be interpreted as part of text.
    /// </summary>
    public class DotSpacePaddingEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value is not null
                ? Regex.Replace(value, "(?<=^[ ]*)[ ]|[ ](?=[ ]*$)", "&#32;")
                : null;
        }
    }
}