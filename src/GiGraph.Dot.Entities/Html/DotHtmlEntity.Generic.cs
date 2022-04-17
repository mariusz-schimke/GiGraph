using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Html;

/// <summary>
///     Represents an HTML entity adapter. Useful for wrapping <see cref="IDotHtmlEntity" /> objects, which are not implicitly
///     convertible, so cannot be assigned directly to a label of a DOT element.
/// </summary>
/// <typeparam name="TEntity">
///     The type of entity to wrap.
/// </typeparam>
public class DotHtmlEntity<TEntity> : DotHtmlEntity
    where TEntity : IDotHtmlEntity
{
    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    /// <param name="entity">
    ///     The entity to assign to the instance.
    /// </param>
    public DotHtmlEntity(TEntity entity)
    {
        Entity = entity;
    }

    /// <summary>
    ///     The entity associated with the instance.
    /// </summary>
    public TEntity Entity { get; }

    protected internal override string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => Entity.ToHtml(options, syntaxRules);
}