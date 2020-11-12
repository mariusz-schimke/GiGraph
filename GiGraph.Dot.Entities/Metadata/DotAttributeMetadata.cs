namespace GiGraph.Dot.Entities.Metadata
{
    /// <summary>
    ///     Attribute metadata.
    /// </summary>
    public class DotAttributeMetadata
    {
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
        public DotAttributeMetadata(string key, DotElementSupport elementSupport, DotLayoutEngineSupport layoutEngineSupport, DotOutputFormatSupport outputFormatSupport)
        {
            Key = key;
            ElementSupport = elementSupport;
            LayoutEngineSupport = layoutEngineSupport;
            OutputFormatSupport = outputFormatSupport;
        }

        /// <summary>
        ///     The key of the attribute.
        /// </summary>
        public string Key { get; }

        /// <summary>
        ///     Indicates what elements the attribute may be applied to.
        /// </summary>
        public DotElementSupport ElementSupport { get; }

        /// <summary>
        ///     Indicates what layout engines the attribute is supported by.
        /// </summary>
        public DotLayoutEngineSupport LayoutEngineSupport { get; }

        /// <summary>
        ///     Indicates what output formats the attribute is supported by.
        /// </summary>
        public DotOutputFormatSupport OutputFormatSupport { get; }
    }
}