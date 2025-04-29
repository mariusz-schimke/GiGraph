namespace GiGraph.Dot.Types.Fonts;

/// <summary>
///     Font styles.
/// </summary>
[Flags]
public enum DotFontStyles
{
    /// <summary>
    ///     Regular (default) font style.
    /// </summary>
    Regular = 0,

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
    Superscript = 1 << 5,

    /// <summary>
    ///     Strikethrough style.
    /// </summary>
    Strikethrough = 1 << 6,

    /// <summary>
    ///     Bold italic style.
    /// </summary>
    BoldItalic = Bold | Italic,

    /// <summary>
    ///     Bold underlined style.
    /// </summary>
    BoldUnderline = Bold | Underline,

    /// <summary>
    ///     Italic underlined style.
    /// </summary>
    ItalicUnderline = Italic | Underline,

    /// <summary>
    ///     Bold italic underlined style.
    /// </summary>
    BoldItalicUnderline = Bold | Italic | Underline
}