namespace GiGraph.Dot.Types.Text
{
    /// <summary>
    ///     An HTML DOM string.
    /// </summary>
    public class DotHtmlString : DotEscapedString
    {
        protected DotHtmlString(string value)
            : base(value)
        {
        }

        public static implicit operator DotHtmlString(string value)
        {
            return value is not null ? new DotHtmlString(value) : null;
        }
    }
}