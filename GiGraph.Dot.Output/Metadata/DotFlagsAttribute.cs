using System;

namespace GiGraph.Dot.Output.Metadata
{
    /// <summary>
    ///     Provides information for a flags enumeration about how to join the flags to formulate a meaningful value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum)]
    public class DotFlagsAttribute : Attribute, IDotFlagsAttribute
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="separator">
        ///     The separator to use in order to join the flags of the enumeration.
        /// </param>
        public DotFlagsAttribute(string separator)
        {
            Separator = separator;
        }

        /// <inheritdoc cref="IDotFlagsAttribute.Separator" />
        public virtual string Separator { get; }
    }
}