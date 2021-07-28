namespace GiGraph.Dot.Entities.Html
{
    /// <summary>
    ///     An HTML line break (&lt;br/&gt;).
    /// </summary>
    public class DotHtmlLineBreak : DotHtmlTag
    {
        public DotHtmlLineBreak()
            : base("br", isVoid: true)
        {
        }
    }
}