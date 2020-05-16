namespace GiGraph.Dot.Entities.Attributes
{
    public interface IDotAttribute : IDotEntity
    {
        /// <summary>
        /// The key of the attribute.
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the value of the attribute in a format understood by DOT graph renderer.
        /// </summary>
        string Value { get; }
    }
}