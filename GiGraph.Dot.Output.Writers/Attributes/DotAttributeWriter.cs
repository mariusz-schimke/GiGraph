using System.Linq;

namespace GiGraph.Dot.Output.Writers.Attributes
{
    public class DotAttributeWriter : DotEntityWriter, IDotAttributeWriter
    {
        public DotAttributeWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool enforceBlockComment)
            : base(tokenWriter, configuration, enforceBlockComment)
        {
        }

        public virtual void WriteAttribute(string key, bool quoteKey, string value, bool quoteValue)
        {
            InitializeAttribute(key, quoteKey);
            _tokenWriter.Identifier(value, quoteValue);
        }

        public virtual void WriteHtmlAttribute(string key, bool quoteKey, string value, bool writeInBrackets)
        {
            InitializeAttribute(key, quoteKey);

            // As HTML strings can contain newline characters, which are used solely for formatting, the language does not allow
            // escaped newlines or concatenation operators to be used within them.
            // https://graphviz.org/doc/info/lang.html
            _tokenWriter.Html(value, writeInBrackets);
        }

        public override void EndComment()
        {
            if (_enforceBlockComment)
            {
                _tokenWriter.Space();
            }
            else
            {
                base.EndComment();
            }
        }

        public virtual void WriteAttribute(string key, bool quoteKey, string[] valueParts, bool quoteValue)
        {
            if (_tokenWriter.Options.SingleLine)
            {
                var value = string.Join(string.Empty, valueParts);
                WriteAttribute(key, quoteKey, value, quoteValue);
                return;
            }

            WriteConcatenatedValueAttribute(key, quoteKey, valueParts, quoteValue);
        }

        protected virtual void WriteConcatenatedValueAttribute(string key, bool quoteKey, string[] valueParts, bool quoteValue)
        {
            quoteValue |= valueParts.Length > 1;
            WriteAttribute(key, quoteKey, valueParts.FirstOrDefault(), quoteValue);

            DotTokenWriter tokenWriter = null;
            foreach (var valuePart in valueParts.Skip(1))
            {
                tokenWriter ??= _tokenWriter.NextIndentationLevel();
                tokenWriter.Space(linger: true)
                   .StringConcatenationOperator(linger: true)
                   .NewLine(linger: true)
                   .Identifier(valuePart, quoteValue);
            }
        }

        protected virtual void InitializeAttribute(string key, bool quoteKey)
        {
            _tokenWriter.Identifier(key, quoteKey)
               .Space()
               .ValueAssignmentOperator()
               .Space();
        }
    }
}