using GiGraph.Dot.Output.Writers.CommonEntityWriters;

namespace GiGraph.Dot.Output.Writers.AttributeWriters
{
    public interface IDotAttributeWriter : IDotEntityWriter
    {
        void WriteAttribute(string key, bool quoteKey, string value, bool quoteValue);
        void WriteHtmlAttribute(string key, bool quoteKey, string value, bool braceValue);
    }
}