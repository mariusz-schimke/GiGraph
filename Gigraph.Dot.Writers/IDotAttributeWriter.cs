namespace Gigraph.Dot.Writers
{
    public interface IDotAttributeWriter : IDotEntityWriter
    {
        void WriteAttribute(string key, bool quoteKey, string value, bool quoteValue);
        void WriteHtmlAttribute(string key, bool quoteKey, string value, bool braceValue);
    }
}