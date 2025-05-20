namespace GiGraph.Dot.Types.Hyperlinks;

/// <summary>
///     Specifies where to open linked documents. See also the
///     <see href="https://www.w3.org/TR/html401/types.html#type-frame-target">
///         W3C documentation
///     </see>
///     .
/// </summary>
public class DotHyperlinkTargets
{
    /// <summary>
    ///     Opens a new window if it doesn't already exist, or reuses it if it does.
    /// </summary>
    public const string Graphviz = "_graphviz";

    /// <summary>
    ///     The user agent should load the designated document in a new, unnamed window.
    /// </summary>
    public const string Blank = "_blank";

    /// <summary>
    ///     The user agent should load the document in the same frame as the element that refers to this target.
    /// </summary>
    public const string Self = "_self";

    /// <summary>
    ///     The user agent should load the document into the immediate
    ///     <see href="https://www.w3.org/TR/html401/present/frames.html#edef-FRAMESET">
    ///         FRAMESET
    ///     </see>
    ///     parent of the current frame. This value is equivalent to <see cref="Self"/> if the current frame has no parent.
    /// </summary>
    public const string Parent = "_parent";

    /// <summary>
    ///     The user agent should load the document into the full, original window (thus canceling all other frames). This value is
    ///     equivalent to <see cref="Self"/> if the current frame has no parent.
    /// </summary>
    public const string Top = "_top";
}