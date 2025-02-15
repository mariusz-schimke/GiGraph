using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html;

namespace GiGraph.Dot.Entities.Html;

/// <summary>
///     Represents an HTML entity collection.
/// </summary>
public class DotHtmlEntityCollection : List<IDotHtmlEntity>, IDotHtmlContentEntity
{
    /// <summary>
    ///     Creates a new entity collection.
    /// </summary>
    /// <param name="entities">
    ///     The entities to initialize the collection with.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when a null collection is passed.
    /// </exception>
    public DotHtmlEntityCollection(params IDotHtmlEntity[] entities)
        : base(entities)
    {
    }

    /// <summary>
    ///     Creates a new entity collection.
    /// </summary>
    /// <param name="entities">
    ///     The entities to initialize the collection with.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when a null collection is passed.
    /// </exception>
    public DotHtmlEntityCollection(IEnumerable<IDotHtmlEntity> entities)
        : base(entities)
    {
    }

    /// <inheritdoc cref="IDotHtmlEntity.ToHtml()" />
    public virtual DotHtmlString ToHtml() => ToHtml(DotSyntaxOptions.Default, DotSyntaxRules.Default);

    string IDotHtmlEncodable.ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => ToHtml(options, syntaxRules);

    DotHtmlEntityCollection IDotHtmlContentEntity.Content => this;

    void IDotHtmlContentEntity.SetContent(IDotHtmlEntity entity)
    {
        Clear();
        Add(entity);
    }

    void IDotHtmlContentEntity.SetContent(string text, DotHorizontalAlignment? lineAlignment)
    {
        ((IDotHtmlContentEntity) this).SetContent(new DotHtmlText(text, lineAlignment));
    }

    void IDotHtmlContentEntity.SetHtmlContent(string html)
    {
        ((IDotHtmlContentEntity) this).SetContent(new DotHtml(html));
    }

    void IDotHtmlContentEntity.SetContent(Action<DotHtmlBuilder>? build)
    {
        var builder = new DotHtmlBuilder();

        // checked for null because this method is used from HTML builder where initialization is optional
        build?.Invoke(builder);

        Clear();

        if (builder.Count > 0)
        {
            Add(builder.Build());
        }
    }

    /// <summary>
    ///     Adds a new HTML entity to the collection.
    /// </summary>
    /// <param name="entity">
    ///     The entity to add.
    /// </param>
    /// <param name="init">
    ///     An optional entity initializer.
    /// </param>
    public virtual TEntity Add<TEntity>(TEntity entity, Action<TEntity>? init = null)
        where TEntity : IDotHtmlEntity
    {
        init?.Invoke(entity);
        base.Add(entity);
        return entity;
    }

    /// <summary>
    ///     Adds new HTML entities to the collection.
    /// </summary>
    /// <param name="entities">
    ///     The entities to add.
    /// </param>
    public virtual IDotHtmlEntity[] AddRange(params IDotHtmlEntity[] entities)
    {
        base.AddRange(entities);
        return entities;
    }

    /// <summary>
    ///     Appends the specified HTML to the content of the element.
    /// </summary>
    /// <param name="html">
    ///     The html to add to the content of the element.
    /// </param>
    public virtual void AddHtml(string html)
    {
        Add(new DotHtml(html), init: null);
    }

    public override string ToString() => ToHtml();

    protected virtual string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        return string.Join(string.Empty, this.Select(entity => entity.ToHtml(options, syntaxRules)));
    }
}