using System;

namespace GiGraph.Dot.Output.Text
{
    /// <summary>
    ///     Operating system-based new line constants.
    /// </summary>
    public static class DotNewLine
    {
        /// <summary>
        ///     Windows new line string (carriage return and line feed: \r\n).
        /// </summary>
        public const string Windows = "\r\n";

        /// <summary>
        ///     Unix and Unix-like systems new line string (line feed: \n).
        /// </summary>
        public const string Unix = "\n";

        /// <summary>
        ///     Gets the newline string defined for this environment.
        /// </summary>
        public static string SystemDefault => Environment.NewLine;
    }
}