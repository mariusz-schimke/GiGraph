using System;

namespace GiGraph.Dot.Entities.Types.Attributes
{
    /// <summary>
    ///     Assigns a value indicating what elements an attribute key is supported by.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DotAttributeSupportAttribute : Attribute
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="entities">
        ///     The entities the current attribute key is supported by.
        /// </param>
        public DotAttributeSupportAttribute(DotEntityTypes entities)
        {
            Entities = entities;
        }

        /// <summary>
        ///     Gets the entities the current attribute key is supported by.
        /// </summary>
        public virtual DotEntityTypes Entities { get; }
    }
}