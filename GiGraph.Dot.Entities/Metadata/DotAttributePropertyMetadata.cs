using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Metadata
{
    /// <summary>
    ///     Attribute property metadata.
    /// </summary>
    public class DotAttributePropertyMetadata : DotAttributeMetadata
    {
        protected readonly PropertyInfo[] _propertyPath;

        /// <summary>
        ///     Creates and initializes a new attribute metadata instance.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="elementSupport">
        ///     Determines what elements the attribute may be applied to.
        /// </param>
        /// <param name="layoutEngineSupport">
        ///     Determines what layout engines the attribute is supported by.
        /// </param>
        /// <param name="outputFormatSupport">
        ///     Determines what output formats the attribute is supported by.
        /// </param>
        /// <param name="propertyPath">
        ///     The property path as an array of property info, where the last item is the actual property associated with the attribute key.
        /// </param>
        public DotAttributePropertyMetadata(
            string key,
            DotElementSupport elementSupport,
            DotLayoutEngineSupport layoutEngineSupport,
            DotOutputFormatSupport outputFormatSupport,
            PropertyInfo[] propertyPath
        )
            : base(key, elementSupport, layoutEngineSupport, outputFormatSupport)
        {
            _propertyPath = propertyPath;
            PropertyPath = string.Join(".", propertyPath.Select(property => property.Name));
        }

        /// <summary>
        ///     The path to the property.
        /// </summary>
        public string PropertyPath { get; }

        /// <summary>
        ///     Gets property path as an array of property info (the last item is the actual property associated with the attribute key).
        /// </summary>
        public virtual PropertyInfo[] GetPropertyInfoPath()
        {
            return _propertyPath;
        }
    }
}