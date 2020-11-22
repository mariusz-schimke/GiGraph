namespace GiGraph.Dot.Output.Writers.Attributes
{
    public interface IDotAttributeWriter : IDotEntityWriter
    {
        void WriteAttribute(string key, bool quoteKey, string value, bool quoteValue);
        void WriteAttribute(string key, bool quoteKey, string[] valueParts, bool quoteValue);
        void WriteHtmlAttribute(string key, bool quoteKey, string value, bool writeInBrackets);
    }
}