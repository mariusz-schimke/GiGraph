using System;

namespace GiGraph.Dot.Output.Metadata
{
    /// <summary>
    ///     Assigns a DOT attribute value to an enumeration value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DotAttributeValueAttribute : Attribute, IDotAttributeValueAttribute
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="value">
        ///     The value of the DOT attribute.
        /// </param>
        public DotAttributeValueAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        ///     Gets the value of the DOT attribute.
        /// </summary>
        public virtual string Value { get; }
    }
}