namespace GiGraph.Dot.Output.Options;

/// <summary>
///     Determines how to mark subgraphs as clusters in the DOT output.
/// </summary>
[Flags]
public enum DotClusterDiscriminators
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