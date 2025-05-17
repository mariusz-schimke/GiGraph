using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Text;

/// <summary>
///     Modifies text casing.
/// </summary>
public static class DotTextCasing
{
    /// <summary>
    ///     Sets text casing.
    /// </summary>
    /// <param name="text">
    ///     The text whose casing to set.
    /// </param>
    /// <param name="casing">
    ///     The casing to set.
    /// </param>
    public static string? SetCasing(string? text, DotTextCase casing)
    {
        return casing switch
        {
            DotTextCase.Default => text,
            DotTextCase.Lower => text?.ToLowerInvariant(),
            DotTextCase.Upper => text?.ToUpperInvariant(),
            _ => throw new ArgumentException($"The '{casing}' text casing option is invalid.", nameof(casing))
        };
    }
}