namespace Dotless.TextEscaping
{
    public class DotBackslashEscaper : IDotTextEscaper
    {
        public virtual string? Escape(string? value)
        {
            return value?.Replace(@"\", @"\\");
        }
    }
}
