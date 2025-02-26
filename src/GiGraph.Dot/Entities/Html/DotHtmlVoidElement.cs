using GiGraph.Dot.Entities.Html.Attributes.Collections;

namespace GiGraph.Dot.Entities.Html;

/// <summary>
///     Represents a void HTML element with optional attributes.
/// </summary>
public class DotHtmlVoidElement : DotHtmlTag
{
    /// <summary>
    ///     Initializes a void HTML element with the given name.
    /// </summary>
    /// <param name="name">
    ///     The tag name to use.
    /// </param>
    public DotHtmlVoidElement(string name)
        : this(name, new DotHtmlAttributeCollection())
    {
    }

    protected DotHtmlVoidElement(string name, DotHtmlAttributeCollection attributes)
        : base(name, attributes)
    {
    }

    protected sealed override bool IsVoid => true;
}