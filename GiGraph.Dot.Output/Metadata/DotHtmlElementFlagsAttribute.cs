using System;

namespace GiGraph.Dot.Output.Metadata
{
    /// <summary>
    ///     Provides information for a flags enumeration about how to join the flags to formulate a meaningful value for an attribute of
    ///     an HTML element.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum)]
    public class DotHtmlElementFlagsAttribute : Attribute, IDotFlagsAttribute
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="separator">
        ///     The separator to use in order to join the flags of the enumeration.
        /// </param>
        public DotHtmlElementFlagsAttribute(string separator)
        {
            Separator = separator;
        }

        /// <inheritdoc cref="IDotFlagsAttribute.Separator" />
        public virtual string Separator { get; }
    }
}