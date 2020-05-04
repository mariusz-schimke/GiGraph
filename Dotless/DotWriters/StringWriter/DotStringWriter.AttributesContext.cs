using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters.StringWriter
{
    public partial class DotStringWriter
    {
        public abstract class AttributesContext : DotWriterContext, IDotAttributeCollectionWriter, IDotAttributeWriter
        {
            protected readonly bool _preferExplicitAttributesDelimiter;

            protected abstract void WriteAttributeDelimiter();

            public AttributesContext(StreamWriter writer, DotFormattingOptions options, int level, bool preferExplicitAttributesDelimiter)
                : base(writer, options, level)
            {
                _preferExplicitAttributesDelimiter = preferExplicitAttributesDelimiter;
            }

            public IDotAttributeWriter BeginAttribute()
            {
                return this;
            }

            public void EndAttribute()
            {
                WriteAttributeDelimiter();
            }

            public virtual void WriteAttribute(string key, bool quoteKey, string value, bool quoteValue)
            {
                WriteIdentifier(key, quoteKey);
                WriteValueAssignmentOperator();
                WriteTextValue(value, quoteValue);
            }

            public virtual void WriteHtmlAttribute(string key, bool quoteKey, string value, bool braceValue)
            {
                WriteIdentifier(key, quoteKey);
                WriteValueAssignmentOperator();
                WriteHtmlValue(value, braceValue);
            }
        }
    }
}
