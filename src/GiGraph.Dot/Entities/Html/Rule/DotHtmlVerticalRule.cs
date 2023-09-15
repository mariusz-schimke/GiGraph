namespace GiGraph.Dot.Entities.Html.Rule;

/// <summary>
///     An HTML vertical rule element (&lt;vr&gt;).
/// </summary>
public class DotHtmlVerticalRule : DotHtmlRule
{
    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public DotHtmlVerticalRule()
        : base("vr")
    {
    }

    /// <summary>
    ///     Gets a static instance of a vertical rule element.
    /// </summary>
    public static DotHtmlEntity Instance { get; } = new DotHtmlReadOnlyEntity<DotHtmlVerticalRule>(new());
}