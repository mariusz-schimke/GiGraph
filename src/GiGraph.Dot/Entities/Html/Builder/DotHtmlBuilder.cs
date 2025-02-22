using System.Diagnostics.Contracts;

namespace GiGraph.Dot.Entities.Html.Builder;

/// <summary>
///     HTML builder.
/// </summary>
public partial class DotHtmlBuilder
{
    protected readonly DotHtmlEntityCollection _entities;

    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    public DotHtmlBuilder()
    {
        _entities = [];
    }

    /// <summary>
    ///     Gets the number of entities in this builder.
    /// </summary>
    public virtual int Count => _entities.Count;

    /// <summary>
    ///     Appends an entity with customizable content to this instance.
    /// </summary>
    /// <param name="entity">
    ///     The entity to append.
    /// </param>
    /// <param name="init">
    ///     A content initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder Append<TContentEntity>(TContentEntity entity, Action<DotHtmlBuilder>? init = null)
        where TContentEntity : IDotHtmlContentEntity
    {
        entity.SetContent(init);
        _entities.Add(entity);
        return this;
    }

    /// <summary>
    ///     Appends an entity to this instance.
    /// </summary>
    /// <param name="entity">
    ///     The entity to append.
    /// </param>
    /// <param name="init">
    ///     An entity initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder AppendEntity<TEntity>(TEntity entity, Action<TEntity>? init = null)
        where TEntity : IDotHtmlEntity
    {
        init?.Invoke(entity);
        _entities.Add(entity);
        return this;
    }

    /// <summary>
    ///     Appends custom HTML to this instance.
    /// </summary>
    /// <param name="html">
    ///     The HTML to append.
    /// </param>
    public virtual DotHtmlBuilder AppendHtml(string html)
    {
        _entities.Add(new DotHtml(html));
        return this;
    }

    /// <summary>
    ///     Builds output HTML from the content of the builder.
    /// </summary>
    [Pure]
    public virtual DotHtmlEntity Build() =>
        new DotHtmlEntity<DotHtmlEntityCollection>(
            new((IEnumerable<IDotHtmlEntity>) _entities)
        );
}