using Dotless.DotWriters.Options;
using System.IO;

namespace Dotless.DotWriters
{
    public partial class DotStringWriter
    {
        public abstract class AttributeListContext : DotWriterContext
        {
            protected readonly bool _preferExplicitAttributeDelimiter;

            public AttributeListContext(StreamWriter writer, DotFormattingOptions options, int level, bool preferExplicitAttributeDelimiter)
                : base(writer, options, level)
            {
                _preferExplicitAttributeDelimiter = preferExplicitAttributeDelimiter;
            }

            public virtual AttributeListContext WriteAttribute(string key, bool quoteKey, string value, bool quoteValue)
            {
                WriteIdentifier(key, quoteKey);
                WriteValueAssignmentOperator();
                WriteTextValue(value, quoteValue);

                return WriteAttributeDelimiter();
            }

            public virtual AttributeListContext WriteHtmlAttribute(string key, bool quoteKey, string value, bool braceValue)
            {
                WriteIdentifier(key, quoteKey);
                WriteValueAssignmentOperator();
                WriteHtmlValue(value, braceValue);

                return WriteAttributeDelimiter();
            }

            protected virtual AttributeListContext WriteAttributeDelimiter()
            {
                return this;
            }
        }
    }
}
