using System;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Properties.Accessors
{
    public interface IDotEntityAttributesAccessor
    {
        /// <summary>
        ///     Gets the interface that exposes properties representing DOT attributes.
        /// </summary>
        Type InterfaceType { get; }

        /// <summary>
        ///     Gets the implementation that exposes properties representing DOT attributes.
        /// </summary>
        DotEntityAttributes Implementation { get; }

        /// <summary>
        ///     Gets an attribute key associated with the specified property of the current object.
        /// </summary>
        /// <param name="property">
        ///     The property to get a key for.
        /// </param>
        string GetPropertyKey(PropertyInfo property);
    }
}