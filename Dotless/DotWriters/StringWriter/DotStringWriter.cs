using Dotless.DotWriters.Options;
using System.Collections.Generic;
using System.IO;

namespace Dotless.DotWriters.StringWriter
{
    // TODO: dać możliwość przekazania strumienia, żeby do niego zapisywało
    // TODO: uściślić, gdzie mają być dodawane w poniżych metodach separatory za tokenem, a gdzie nie (gdzie ma być odpowiedzialność za to)
    // TODO: czy te metody powinny być publiczne? Może jednak prywatne, z dostępem tylko z poziomu kontekstów?
    // TODO: bazując na punkcie wyżej, sprawdzić, czy dostępność wszystkich metod jest spójna
    public class DotStringWriter
    {
        protected readonly StreamWriter _writer;
        protected readonly Queue<string> _lingerBuffer = new Queue<string>();

        protected readonly DotFormattingOptions _options;

        public DotStringWriter(StreamWriter writer, DotFormattingOptions options)
        {
            _writer = writer;
            _options = options;
        }

        public virtual DotStringWriter Token(string token, bool linger = false)
        {
            return Append(token, linger);
        }

        public virtual DotStringWriter Keyword(string keyword, bool linger = false)
        {
            return Token(keyword, linger);
        }

        public virtual DotStringWriter Identifier(string id, bool quote = false, bool linger = false)
        {
            if (quote)
            {
                QuotationStart(linger);
                Token(_options.Text(id)!, linger);
                QuotationEnd(linger);
            }
            else
            {
                Token(id, linger);
            }

            return this;
        }

        public virtual DotStringWriter ValueAssignmentOperator(bool linger = false)
        {
            return Token("=", linger);
        }

        public virtual DotStringWriter SectionStart(bool linger = false)
        {
            return Token("{", linger);
        }

        public virtual DotStringWriter SectionEnd(bool linger = false)
        {
            return Token("}", linger);
        }

        public virtual DotStringWriter AttributeListStart(bool linger = false)
        {
            return Token("[", linger);
        }

        public virtual DotStringWriter AttributeListEnd(bool linger = false)
        {
            return Token("]", linger);
        }

        public virtual DotStringWriter AttributeSeparator(bool linger = false)
        {
            return Token(",", linger);
        }

        public virtual DotStringWriter StatementEnd(bool linger = false)
        {
            return Token(";", linger);
        }

        public virtual DotStringWriter QuotationStart(bool linger = false)
        {
            return Token("\"", linger);
        }

        public virtual DotStringWriter QuotationEnd(bool linger = false)
        {
            return Token("\"", linger);
        }

        public virtual DotStringWriter HtmlStartBrace(bool linger = false)
        {
            return Token("<", linger);
        }

        public virtual DotStringWriter HtmlEndBrace(bool linger = false)
        {
            return Token(">", linger);
        }

        public virtual DotStringWriter Edge(bool linger = false)
        {
            return Token("--", linger);
        }

        public virtual DotStringWriter DirectedEdge(bool linger = false)
        {
            return Token("->", linger);
        }

        public virtual DotStringWriter TextValue(string text, bool quote = true, bool linger = false)
        {
            if (quote)
            {
                QuotationStart(linger);
                Token(_options.Text(text)!, linger);
                QuotationEnd(linger);
            }
            else
            {
                Token(text, linger);
            }

            return this;
        }

        public virtual DotStringWriter HtmlValue(string html, bool brace = true, bool linger = false)
        {
            if (brace)
            {
                HtmlStartBrace(linger);
                Token(_options.Text(html)!, linger);
                HtmlEndBrace(linger);
            }
            else
            {
                Token(html, linger);
            }

            return this;
        }

        public virtual DotStringWriter LineBreak(bool linger = false)
        {
            Append(_options.LineBreak(), linger);
            return this;
        }

        public virtual DotStringWriter Space(bool linger = false)
        {
            Append(_options.Space(), linger);
            return this;
        }

        public virtual DotStringWriter Indentation(int level, bool linger = false)
        {
            Append(_options.Indentation(level), linger);
            return this;
        }

        protected virtual DotStringWriter Append(string value, bool linger = false)
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

        public virtual DotStringWriter FlushLingerBuffer()
        {
            while (_lingerBuffer.TryDequeue(out var value))
            {
                _writer.Write(value);
            }

            return this;
        }

        public virtual DotStringWriter ClearLingerBuffer()
        {
            _lingerBuffer.Clear();
            return this;
        }
    }
}
