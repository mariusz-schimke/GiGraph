using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities
{
    public interface IDotEncodableValue
    {
        /// <summary>
        /// Gets the value of the attribute in a format understood by DOT graph renderer.
        /// </summary>
        /// <param name="options">The DOT generation options to use.</param>
        string GetDotEncodedValue(DotGenerationOptions options);
    }
}