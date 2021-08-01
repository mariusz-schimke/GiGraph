using System;

namespace GiGraph.Dot.Output.Metadata.Html
{
    /// <summary>
    ///     Assigns an HTML attribute value to an enumeration value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DotHtmlElementAttributeValueAttribute : Attribute, IDotAttributeValueAttribute
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="value">
        ///     The value of the HTML attribute.
        /// </param>
        public DotHtmlElementAttributeValueAttribute(string value)
        {
            Value = value;
        }

        /// <inheritdoc cref="IDotAttributeValueAttribute.Value" />
        public virtual string Value { get; }
    }
}