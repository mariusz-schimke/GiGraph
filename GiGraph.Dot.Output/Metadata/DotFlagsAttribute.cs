using System;

namespace GiGraph.Dot.Output.Metadata
{
    /// <summary>
    ///     Provides information for a flags enumeration about how to join the flags to formulate a meaningful value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum)]
    public class DotFlagsAttribute : Attribute
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

        /// <summary>
        ///     The separator to use in order to join the flags of the enumeration.
        /// </summary>
        public virtual string Separator { get; }
    }
}