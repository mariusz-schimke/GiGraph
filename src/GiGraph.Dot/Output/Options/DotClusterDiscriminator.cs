namespace GiGraph.Dot.Output.Options;

/// <summary>
///     Determines how to mark subgraphs as clusters in the output DOT script.
/// </summary>
[Flags]
public enum DotClusterDiscriminator
{
    /// <summary>
    ///     Use a "cluster" prefix in the ID.
    /// </summary>
    IdPrefix = 1 << 0,

    /// <summary>
    ///     Use a "cluster" attribute set to <see langword="true"/>.
    /// </summary>
    Attribute = 1 << 1,

    /// <summary>
    ///     Use both a "cluster" prefix in the ID, and a "cluster" attribute set to <see langword="true"/>.
    /// </summary>
    IdPrefixAndAttribute = IdPrefix | Attribute
}