namespace Dotless.DotWriters
{
    public interface IDotAttributeWriter : IDotWriter
    {
        void WriteAttribute(string key, bool quoteKey, string value, bool quoteValue);
        void WriteHtmlAttribute(string key, bool quoteKey, string value, bool braceValue);
    }
}