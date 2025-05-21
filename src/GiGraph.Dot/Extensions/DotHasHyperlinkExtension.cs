using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Extensions;

public static class IDotHasHyperlinkExtension
{
    /// <summary>
    ///     Sets hyperlink attributes.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
    /// </param>
    /// <param name="href">
    ///     The URL of the hyperlink.
    /// </param>
    /// <param name="target">
    ///     Determines which window of the browser is used for the URL. See <see cref="DotHyperlinkTargets"/> for special values.
    /// </param>
    public static T Set<T>(this T entity, DotEscapeString? href, DotEscapeString? target)
        where T : IDotHasHyperlink
    {
        entity.Href = href;
        entity.Target = target;
        return entity;
    }

    /// <summary>
    ///     Sets hyperlink attributes.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
    /// </param>
    /// <param name="href">
    ///     The URL of the hyperlink.
    /// </param>
    /// <param name="target">
    ///     Determines which window of the browser is used for the URL. See <see cref="DotHyperlinkTargets"/> for special values.
    /// </param>
    /// <param name="tooltip">
    ///     The tooltip to set on the element.
    /// </param>
    public static T Set<T>(this T entity, DotEscapeString? href, DotEscapeString? target, DotEscapeString? tooltip)
        where T : IDotHasHyperlinkWithTooltip
    {
        entity.Tooltip = tooltip;
        return entity.Set(href, target);
    }

    /// <summary>
    ///     Sets hyperlink attributes.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
    /// </param>
    /// <param name="href">
    ///     The URL of the hyperlink.
    /// </param>
    /// <param name="tooltip">
    ///     The tooltip to set on the element.
    /// </param>
    public static T SetWithTooltip<T>(this T entity, DotEscapeString? href, DotEscapeString? tooltip)
        where T : IDotHasHyperlinkWithTooltip
    {
        entity.Href = href;
        entity.Tooltip = tooltip;
        return entity;
    }

    /// <summary>
    ///     Sets hyperlink attributes with the <see cref="IDotHasHyperlink.Target"/> as <see cref="DotHyperlinkTargets.Blank"/>.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
    /// </param>
    /// <param name="href">
    ///     The URL of the hyperlink.
    /// </param>
    public static T SetWithNewWindowTarget<T>(this T entity, DotEscapeString? href)
        where T : IDotHasHyperlink =>
        entity.Set(href, target: DotHyperlinkTargets.Blank);

    /// <summary>
    ///     Sets hyperlink attributes with the <see cref="IDotHasHyperlink.Target"/> as <see cref="DotHyperlinkTargets.Blank"/>.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
    /// </param>
    /// <param name="href">
    ///     The URL of the hyperlink.
    /// </param>
    /// <param name="tooltip">
    ///     The tooltip to set on the element.
    /// </param>
    public static T SetWithNewWindowTarget<T>(this T entity, DotEscapeString? href, DotEscapeString? tooltip)
        where T : IDotHasHyperlinkWithTooltip
    {
        entity.SetWithTooltip(href, tooltip);
        return entity.SetNewWindowTarget();
    }

    /// <summary>
    ///     Sets the <see cref="IDotHasHyperlink.Target"/> property as <see cref="DotHyperlinkTargets.Blank"/>.
    /// </summary>
    public static T SetNewWindowTarget<T>(this T entity)
        where T : IDotHasHyperlink
    {
        entity.Target = DotHyperlinkTargets.Blank;
        return entity;
    }
}