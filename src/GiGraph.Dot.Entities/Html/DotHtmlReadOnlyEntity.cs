using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     A wrapper for HTML entities for the purpose of memory optimization when an entity may be reused.
    /// </summary>
    /// <typeparam name="TEntity">
    ///     The type of entity.
    /// </typeparam>
    public class DotHtmlReadOnlyEntity<TEntity> : DotHtmlEntity
        where TEntity : IDotHtmlEntity
    {
        protected readonly TEntity _entity;

        /// <summary>
        ///     Initializes a new instance.
        /// </summary>
        /// <param name="entity">
        ///     The entity to assign to the instance.
        /// </param>
        public DotHtmlReadOnlyEntity(TEntity entity)
        {
            _entity = entity;
        }

        protected internal override string ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => _entity.ToHtml(options, syntaxRules);
    }
}