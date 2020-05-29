namespace GiGraph.Dot.Entities.Attributes
{
    public interface IDotAttribute : IDotEntity
    {
        /// <summary>
        /// Gets the value of the attribute in a format understood by DOT graph renderer.
        /// </summary>
        string GetDotEncodedValue();
    }
}