using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html;

/// <summary>
///     An HTML element with optional attributes and child elements.
/// </summary>
public partial class DotHtmlElement : DotHtmlTag, IDotHtmlContentEntity
{
    /// <summary>
    ///     Initializes an HTML element with the given name.
    /// </summary>
    /// <param name="name">
    ///     The tag name to use for the element.
    /// </param>
    public DotHtmlElement(string name)
        : this(name, new())
    {
    }

    protected DotHtmlElement(string name, DotHtmlAttributeCollection attributes)
        : this(name, attributes, [])
    {
    }

    protected DotHtmlElement(string name, DotHtmlAttributeCollection attributes, DotHtmlEntityCollection content)
        : base(name, attributes)
    {
        Content = content;
    }

    protected sealed override bool IsVoid => false;

    /// <summary>
    ///     Gets the content items of the element.
    /// </summary>
    public DotHtmlEntityCollection Content { get; }

    /// <inheritdoc cref="IDotHtmlContentEntity.SetContent(GiGraph.Dot.Entities.Html.IDotHtmlEntity)" />
    public virtual void SetContent(IDotHtmlEntity entity)
    {
        ((IDotHtmlContentEntity) Content).SetContent(entity);
    }

    /// <inheritdoc cref="IDotHtmlContentEntity.SetContent(string,System.Nullable{GiGraph.Dot.Types.Alignment.DotHorizontalAlignment})" />
    public virtual void SetContent(string text, DotHorizontalAlignment? lineAlignment = null)
    {
        ((IDotHtmlContentEntity) Content).SetContent(text, lineAlignment);
    }

    /// <inheritdoc cref="IDotHtmlContentEntity.SetContent(System.Action{GiGraph.Dot.Entities.Html.Builder.DotHtmlBuilder})" />
    public virtual void SetContent(Action<DotHtmlBuilder>? build)
    {
        ((IDotHtmlContentEntity) Content).SetContent(build);
    }

    /// <inheritdoc cref="IDotHtmlContentEntity.SetHtmlContent" />
    public virtual void SetHtmlContent(string html)
    {
        ((IDotHtmlContentEntity) Content).SetHtmlContent(html);
    }

    protected override IEnumerable<IDotHtmlEntity> GetContent() => Content;
}