namespace GiGraph.Dot.Entities.Types.Html
{
    /// <summary>
    ///     An HTML line break (&lt;br /&gt;).
    /// </summary>
    public class DotHtmlLineBreak : DotHtmlTag
    {
        public DotHtmlLineBreak()
            : base("BR", contentAllowed: false)
        {
        }
    }
}