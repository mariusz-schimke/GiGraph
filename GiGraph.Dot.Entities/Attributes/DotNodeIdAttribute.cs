namespace GiGraph.Dot.Entities.Attributes
{
    /// <summary>
    ///     Represents the identifier of a node.
    /// </summary>
    public class DotNodeIdAttribute : DotIdAttribute
    {
        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="key">
        ///     The key of the attribute.
        /// </param>
        /// <param name="id">
        ///     The identifier of the node.
        /// </param>
        public DotNodeIdAttribute(string key, string id)
            : base(key, id)
        {
        }
    }
}