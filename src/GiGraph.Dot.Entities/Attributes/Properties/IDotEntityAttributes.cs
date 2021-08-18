using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public interface IDotEntityAttributes
    {
        /// <summary>
        ///     Returns the paths to properties that get or set DOT attributes.
        /// </summary>
        (DotEntityAttributes EntityAttributes, PropertyInfo Property)[][] GetPathsToAttributeProperties();
    }
}