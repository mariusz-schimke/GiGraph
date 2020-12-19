namespace GiGraph.Dot.Entities.Types.Strings
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
            return value is { } ? new DotHtml(value) : null;
        }
    }
}