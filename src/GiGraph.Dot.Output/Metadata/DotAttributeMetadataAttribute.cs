using System;

namespace GiGraph.Dot.Output.Metadata
{
    /// <summary>
    ///     Assigns a value indicating what elements, layout engines, and output formats an attribute key is applicable to.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DotAttributeMetadataAttribute : Attribute
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="compatibleElements">
        ///     The entities the current attribute key is supported by.
        /// </param>
        /// <param name="compatibleLayoutEngines">
        ///     The layout engines the attribute key is supported by.
        /// </param>
        /// <param name="compatibleOutputs">
        ///     The output formats the attribute key is supported by.
        /// </param>
        /// <param name="isImplemented">
        ///     Indicates if the attribute is supported by the library.
        /// </param>
        public DotAttributeMetadataAttribute(
            DotCompatibleElements compatibleElements,
            DotCompatibleLayoutEngines compatibleLayoutEngines = DotCompatibleLayoutEngines.Any,
            DotCompatibleOutputs compatibleOutputs = DotCompatibleOutputs.Any,
            bool isImplemented = true
        )
        {
            CompatibleElements = compatibleElements;
            CompatibleLayoutEngines = compatibleLayoutEngines;
            CompatibleOutputs = compatibleOutputs;
            IsImplemented = isImplemented;
        }

        /// <summary>
        ///     Gets the entities the current attribute key is supported by.
        /// </summary>
        public DotCompatibleElements CompatibleElements { get; }

        /// <summary>
        ///     Gets the layout engines the attribute key is supported by.
        /// </summary>
        public DotCompatibleLayoutEngines CompatibleLayoutEngines { get; }

        /// <summary>
        ///     Gets the output formats the attribute key is supported by.
        /// </summary>
        public DotCompatibleOutputs CompatibleOutputs { get; }

        /// <summary>
        ///     Gets a value indicating if the attribute is supported by the library.
        /// </summary>
        public bool IsImplemented { get; }
    }
}