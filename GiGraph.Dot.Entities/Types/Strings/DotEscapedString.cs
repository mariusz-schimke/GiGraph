namespace GiGraph.Dot.Entities.Types.Strings
{
    public class DotEscapedString : DotString
    {
        public DotEscapedString(string value)
            : base(value)
        {
        }

        public static implicit operator DotEscapedString(string value)
        {
            return value is {} ? new DotEscapedString(value) : null;
        }
    }
}