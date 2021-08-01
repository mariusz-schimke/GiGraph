using System;

namespace GiGraph.Dot.Types.Fonts
{
    /// <summary>
    ///     Font styles.
    /// </summary>
    [Flags]
    public enum DotFontStyles
    {
        /// <summary>
        ///     Normal style.
        /// </summary>
        Normal = 0,

        /// <summary>
        ///     Bold style.
        /// </summary>
        Bold = 1 << 0,

        /// <summary>
        ///     Italic style.
        /// </summary>
        Italic = 1 << 1,

        /// <summary>
        ///     Underlined style.
        /// </summary>
        Underline = 1 << 2,

        /// <summary>
        ///     Overline style.
        /// </summary>
        Overline = 1 << 3,

        /// <summary>
        ///     Subscript style.
        /// </summary>
        Subscript = 1 << 4,

        /// <summary>
        ///     Superscript style.
        /// </summary>
        Superscript = 1 << 5
    }
}