using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public abstract class AttributesContext : DotWriterContext
        {
            protected readonly bool _preferExplicitAttributeDelimiter;

            public AttributesContext(StreamWriter writer, DotFormattingOptions options, int level, bool preferExplicitAttributeDelimiter)
                : base(writer, options, level)
            {
                _preferExplicitAttributeDelimiter = preferExplicitAttributeDelimiter;
            }

            public virtual AttributesContext WriteAttribute(string key, bool quoteKey, string value, bool quoteValue)
            {
                WriteIdentifier(key, quoteKey);
                WriteValueAssignmentOperator();
                WriteTextValue(value, quoteValue);

                return WriteAttributeDelimiter();
            }

            public virtual AttributesContext WriteHtmlAttribute(string key, bool quoteKey, string value, bool braceValue)
            {
                WriteIdentifier(key, quoteKey);
                WriteValueAssignmentOperator();
                WriteHtmlValue(value, braceValue);

                return WriteAttributeDelimiter();
            }

            protected virtual AttributesContext WriteAttributeDelimiter()
            {
                return this;
            }
        }
    }
}
