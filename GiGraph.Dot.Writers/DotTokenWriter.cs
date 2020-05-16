using GiGraph.Dot.Writers.Options;
using System.Collections.Generic;
using System.IO;

namespace GiGraph.Dot.Writers
{
    public class DotTokenWriter
    {
        protected readonly StreamWriter _writer;
        protected readonly Queue<string> _lingerBuffer = new Queue<string>();

        protected readonly DotFormattingOptions _options;

        public DotTokenWriter(StreamWriter writer, DotFormattingOptions options)
        {
            _writer = writer;
            _options = options;
        }

        public virtual DotTokenWriter Token(string token, bool linger = false)
        {
            return Append(token, linger);
        }

        public virtual DotTokenWriter Keyword(string keyword, bool linger = false)
        {
            return Token(keyword, linger);
        }

        public virtual DotTokenWriter Identifier(string id, bool quote = false, bool linger = false)
        {
            if (quote)
            {
                QuotationStart(linger);
                Token(_options.Text(id), linger);
                QuotationEnd(linger);
            }
            else
            {
                Token(id, linger);
            }

            return this;
        }

        public virtual DotTokenWriter ValueAssignmentOperator(bool linger = false)
        {
            return Token("=", linger);
        }

        public virtual DotTokenWriter SectionStart(bool linger = false)
        {
            return Token("{", linger);
        }

        public virtual DotTokenWriter SectionEnd(bool linger = false)
        {
            return Token("}", linger);
        }

        public virtual DotTokenWriter AttributeListStart(bool linger = false)
        {
            return Token("[", linger);
        }

        public virtual DotTokenWriter AttributeListEnd(bool linger = false)
        {
            return Token("]", linger);
        }

        public virtual DotTokenWriter AttributeSeparator(bool linger = false)
        {
            return Token(",", linger);
        }

        public virtual DotTokenWriter StatementEnd(bool linger = false)
        {
            return Token(";", linger);
        }

        public virtual DotTokenWriter QuotationStart(bool linger = false)
        {
            return Token("\"", linger);
        }

        public virtual DotTokenWriter QuotationEnd(bool linger = false)
        {
            return Token("\"", linger);
        }

        public virtual DotTokenWriter HtmlStartBrace(bool linger = false)
        {
            return Token("<", linger);
        }

        public virtual DotTokenWriter HtmlEndBrace(bool linger = false)
        {
            return Token(">", linger);
        }

        public virtual DotTokenWriter Edge(bool directed = false, bool linger = false)
        {
            return directed ? DirectedEdge(linger) : Token("--", linger);
        }

        public virtual DotTokenWriter DirectedEdge(bool linger = false)
        {
            return Token("->", linger);
        }

        public virtual DotTokenWriter TextValue(string text, bool quote = true, bool linger = false)
        {
            if (quote)
            {
                QuotationStart(linger);
                Token(_options.Text(text), linger);
                QuotationEnd(linger);
            }
            else
            {
                Token(text, linger);
            }

            return this;
        }

        public virtual DotTokenWriter HtmlValue(string html, bool brace = true, bool linger = false)
        {
            if (brace)
            {
                HtmlStartBrace(linger);
                Token(_options.Text(html), linger);
                HtmlEndBrace(linger);
            }
            else
            {
                Token(html, linger);
            }

            return this;
        }

        public virtual DotTokenWriter LineBreak(bool linger = false)
        {
            Append(_options.LineBreak(), linger);
            return this;
        }

        public virtual DotTokenWriter Space(bool linger = false)
        {
            Append(_options.Space(), linger);
            return this;
        }

        public virtual DotTokenWriter Indentation(int level, bool linger = false)
        {
            Append(_options.Indentation(level), linger);
            return this;
        }

        protected virtual DotTokenWriter Append(string value, bool linger = false)
        {
            if (linger)
            {
                _lingerBuffer.Enqueue(value);
            }
            else
            {
                FlushLingerBuffer();
                _writer.Write(value);
            }

            return this;
        }

        public virtual DotTokenWriter FlushLingerBuffer()
        {
            while (_lingerBuffer.Count > 0)
            {
                _writer.Write(_lingerBuffer.Dequeue());
            }

            return this;
        }

        public virtual DotTokenWriter ClearLingerBuffer()
        {
            _lingerBuffer.Clear();
            return this;
        }
    }
}
