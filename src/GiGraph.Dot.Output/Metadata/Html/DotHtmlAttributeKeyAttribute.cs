using System;

namespace GiGraph.Dot.Output.Metadata.Html
{
    /// <summary>
    ///     Assigns an HTML attribute key to a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DotHtmlAttributeKeyAttribute : Attribute
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="key">
        ///     The key of the HTML attribute.
        /// </param>
        public DotHtmlAttributeKeyAttribute(string key)
        {
            Key = key;
        }

        /// <summary>
        ///     Gets the key of the HTML attribute.
        /// </summary>
        public virtual string Key { get; }
    }
}