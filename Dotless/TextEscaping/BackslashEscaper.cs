namespace Dotless.TextEscaping
{
    public class BackslashEscaper : ITextEscaper
    {
        public virtual string? Escape(string? value)
        {
            return value?.Replace(@"\", @"\\");
        }
    }
}
