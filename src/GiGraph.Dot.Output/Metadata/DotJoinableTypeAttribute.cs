using System;

namespace GiGraph.Dot.Output.Metadata
{
    /// <summary>
    ///     Provides information for a flags enumeration or an array type about how to join the flags or array items to formulate a
    ///     meaningful value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Class)]
    public class DotJoinableTypeAttribute : Attribute, IDotJoinableTypeAttribute
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="separator">
        ///     The separator to use in order to join the flags of the enumeration.
        /// </param>
        public DotJoinableTypeAttribute(string separator)
        {
            Separator = separator;
        }

        /// <inheritdoc cref="IDotJoinableTypeAttribute.Separator" />
        public virtual string Separator { get; }
    }
}