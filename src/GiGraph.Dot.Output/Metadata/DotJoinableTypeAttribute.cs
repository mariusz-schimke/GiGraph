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
        /// <param name="order">
        ///     Determines whether the values should be ordered before joining.
        /// </param>
        public DotJoinableTypeAttribute(string separator, bool order = true)
        {
            Separator = separator;
            Sort = order;
        }

        /// <inheritdoc cref="IDotJoinableTypeAttribute.Separator" />
        public virtual string Separator { get; }

        /// <inheritdoc cref="IDotJoinableTypeAttribute.Sort" />
        public bool Sort { get; }
    }
}