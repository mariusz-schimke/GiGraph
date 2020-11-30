﻿namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    ///     Escapes line feed characters (LF == \x000A == \n).
    /// </summary>
    public class DotLineFeedEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value?.Replace("\n", "\\n");
        }
    }
}