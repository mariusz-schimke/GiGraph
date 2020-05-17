namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    /// An HTML string attribute that can be used as element label.
    /// For details what HTML grammar is supported, please refer to <see cref="https://www.graphviz.org/doc/info/shapes.html#html"/>.
    /// </summary>
    public class DotHtmlAttribute : DotAttribute<string>
    {
        /// <summary>
        /// Creates a new HTML attribute with a key of "label".
        /// </summary>
        /// <param name="html">The HTML text of the attribute.
        /// For details what HTML grammar is supported, please refer to
        /// <see cref="https://www.graphviz.org/doc/info/shapes.html#html"/>.</param>
        public DotHtmlAttribute(string html)
            : base("label", html)
        {
        }

        /// <summary>
        /// Creates a new HTML attribute.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="html">The HTML text of the attribute.
        /// For details what HTML grammar is supported, please refer to
        /// <see cref="https://www.graphviz.org/doc/info/shapes.html#html"/>.</param>
        public DotHtmlAttribute(string key, string html)
            : base(key, html)
        {
        }
    }
}
