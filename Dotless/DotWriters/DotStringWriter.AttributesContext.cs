using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public abstract class AttributesContext : DotWriterContext, IDotAttributeCollectionWriter
        {
            protected readonly bool _preferExplicitAttributesDelimiter;

            public AttributesContext(StreamWriter writer, DotFormattingOptions options, int level, bool preferExplicitAttributesDelimiter)
                : base(writer, options, level)
            {
                _preferExplicitAttributesDelimiter = preferExplicitAttributesDelimiter;
            }

            public virtual void WriteAttribute(string key, bool quoteKey, string value, bool quoteValue)
            {
                WriteIdentifier(key, quoteKey);
                WriteValueAssignmentOperator();
                WriteTextValue(value, quoteValue);

                WriteAttributeDelimiter();
            }

            public virtual void WriteHtmlAttribute(string key, bool quoteKey, string value, bool braceValue)
            {
                WriteIdentifier(key, quoteKey);
                WriteValueAssignmentOperator();
                WriteHtmlValue(value, braceValue);

                WriteAttributeDelimiter();
            }

            protected virtual void WriteAttributeDelimiter()
            {
            }
        }
    }
}
