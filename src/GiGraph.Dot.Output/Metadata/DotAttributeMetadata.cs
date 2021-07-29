namespace GiGraph.Dot.Output.Metadata
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
        /// <param name="compatibleElements">
        ///     Determines what elements the attribute may be applied to.
        /// </param>
        /// <param name="compatibleLayoutEngines">
        ///     Determines what layout engines the attribute is supported by.
        /// </param>
        /// <param name="compatibleOutputs">
        ///     Determines what output formats the attribute is supported by.
        /// </param>
        public DotAttributeMetadata(string key, DotCompatibleElements compatibleElements, DotCompatibleLayoutEngines compatibleLayoutEngines, DotCompatibleOutputs compatibleOutputs)
        {
            Key = key;
            CompatibleElements = compatibleElements;
            CompatibleLayoutEngines = compatibleLayoutEngines;
            CompatibleOutputs = compatibleOutputs;
        }

        /// <summary>
        ///     The key of the attribute.
        /// </summary>
        public string Key { get; }

        /// <summary>
        ///     Indicates what elements the attribute may be applied to.
        /// </summary>
        public DotCompatibleElements CompatibleElements { get; }

        /// <summary>
        ///     Indicates what layout engines the attribute is supported by.
        /// </summary>
        public DotCompatibleLayoutEngines CompatibleLayoutEngines { get; }

        /// <summary>
        ///     Indicates what output formats the attribute is supported by.
        /// </summary>
        public DotCompatibleOutputs CompatibleOutputs { get; }
    }
}