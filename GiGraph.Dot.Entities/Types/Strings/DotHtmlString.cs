namespace GiGraph.Dot.Entities.Types.Strings
{
    public class DotHtmlString : DotString
    {
        public DotHtmlString(string value)
            : base(value)
        {
        }

        public static implicit operator DotHtmlString(string value)
        {
            return value is {} ? new DotHtmlString(value) : null;
        }
    }
}