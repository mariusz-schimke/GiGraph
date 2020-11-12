using System;

namespace GiGraph.Dot.Entities.Metadata
{
    /// <summary>
    ///     Assigns a value indicating what elements, layout engines, and output formats an attribute key is supported by.
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
        /// <param name="layoutEngines">
        ///     The layout engines the attribute key is supported by.
        /// </param>
        /// <param name="outputFormats">
        ///     The output formats the attribute key is supported by.
        /// </param>
        public DotAttributeSupportAttribute(
            DotEntityTypes entities,
            DotLayoutEngineSupport layoutEngines = DotLayoutEngineSupport.Any,
            DotOutputFormatSupport outputFormats = DotOutputFormatSupport.Any
        )
        {
            Entities = entities;
            LayoutEngines = layoutEngines;
            OutputFormats = outputFormats;
        }

        /// <summary>
        ///     Gets the entities the current attribute key is supported by.
        /// </summary>
        public virtual DotEntityTypes Entities { get; }

        /// <summary>
        ///     Gets the layout engines the attribute key is supported by.
        /// </summary>
        public virtual DotLayoutEngineSupport LayoutEngines { get; }

        /// <summary>
        ///     Gets the output formats the attribute key is supported by.
        /// </summary>
        public virtual DotOutputFormatSupport OutputFormats { get; }
    }
}