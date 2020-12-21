namespace GiGraph.Dot.Entities.Types.Html
{
    /// <summary>
    ///     A generic-type attribute of an HTML tag.
    /// </summary>
    public abstract class DotHtmlAttribute<TValue> : DotHtmlAttribute
    {
        protected DotHtmlAttribute(TValue value)
        {
            Value = value;
        }

        /// <summary>
        ///     Gets or sets the value of the attribute.
        /// </summary>
        public TValue Value { get; set; }
    }
}