namespace GiGraph.Dot.Types.Text
{
    /// <summary>
    ///     An HTML string.
    /// </summary>
    public class DotHtml : DotEscapedString
    {
        protected DotHtml(string value)
            : base(value)
        {
        }

        public static implicit operator DotHtml(string value)
        {
            return value is not null ? new DotHtml(value) : null;
        }
    }
}